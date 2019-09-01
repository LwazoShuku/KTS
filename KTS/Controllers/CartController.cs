using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using KTS.Models;
using System.Data.Entity;
using System.Data;
using KTS.data;
using Postal;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Text;
using Postal;
using PayPal.Api;

using PayPal.Log;
using log4net.Repository.Hierarchy;

namespace KTS.Controllers
{    [Authorize]
    public class CartController : Controller
    {
        private ktsContext db = new ktsContext();
        private string strCart = "Cart";
        private string shippingCharge;

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }



        // GET: Cart
        public ActionResult mail()
        {

            dynamic email = new Email("Order");

            email.To = "samir77@outlook.com";
            email.Subject = "You have a new order";
            email.Message = "Please check you PayPal Business Account user:"+Session.SessionID.ToString()+" has placed an order";

            email.Send();
            return View();
        }



        public ActionResult OrderingItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session[strCart] == null)
            {



                List<Cart> lst = new List<Cart>
                {
                    new Cart (db.product.Find(id),1)

               
             
                    
                };

            

                Session[strCart] = lst;
            }
            else
            {



                List<Cart> lst = (List<Cart>)Session[strCart];

                int check = isExistingCheck(id);

                if (check == -1)
                {

             
                    

                    lst.Add(new Cart(db.product.Find(id), 1));
                    

                   
                  
                }

                else
                {
                    lst[check].Quantity++;

                    int q = db.product.Find(id).StockAmt - 1;
                  
                    db.SaveChanges();



                    Session[strCart] = lst;


                }



            }

            return View("Index");
        }

        private int isExistingCheck(int? id)
        {
            List<Cart> lst = (List<Cart>)Session[strCart];

            for (int i = 0; i < lst.Count; i++)
            {

                if (lst[i].Products.ProductId == id) return i;


            }
            return -1;



        }


        public ActionResult deleteCartItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int check = isExistingCheck(id);
            List<Cart> lst = (List<Cart>)Session[strCart];

            lst.RemoveAt(check);

            int q = db.product.Find(id).StockAmt +1;
            db.SaveChanges();
            return View("Index");

        }
        double Total = 0;
        [HttpGet]
        public ActionResult checkout()
        {
            foreach (var cart in (List<Cart>)Session["Cart"])
            {

                Total = (cart.Products.Price * cart.Quantity) + Total;
            }
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "No shipping", Value = "No shipping", Selected= true });

            items.Add(new SelectListItem { Text = "Shipping", Value = "Ship" ,  });

            ViewBag.shipping = items;

            return View("Checkout");
        }

 
        [HttpPost]
        public ActionResult Checkout(Cart ca)
        {
            
            string ship = Request.Form["Shipping"].ToString();
            if (ca.shipping == "Shipping")
            {
                shippingCharge = "5";
                return RedirectToAction("PaymentWithPaypal");
            }

            else
            {

                shippingCharge = "0";
                return RedirectToAction("PaymentWithPaypal");
                

            }


        }

       

        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("Quantity");

            List<Cart> lst = (List<Cart>)Session[strCart];

            for (int i = 0; i < lst.Count(); i++)
            {

                lst[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lst;
            return View("Index");

        }

        private Payment payment;
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {

            //similar to credit card create itemlist and add item objects to it
            var ListItems = new ItemList { items = new List<Item>()};


            List<Cart> listCarts = (List<Cart>)Session[strCart];
            foreach (var cart in listCarts)
            {

                ListItems.items.Add(new Item()
                {


                    name = cart.Products.ProductName,
                    currency = "USD",
                    price = cart.Products.Price.ToString(),
                    quantity = cart.Quantity.ToString(),
                    sku = "sku",




                });


            }

          

            var payer = new Payer() { payment_method = "paypal" };

            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            //  create details object

           
            var details = new Details()
            {
                tax = "1",
                shipping = shippingCharge,
                subtotal = listCarts.Sum(x => x.Quantity * x.Products.Price).ToString()
            };

            // create amount object
            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(), // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };

            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Kts Tyres sales",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = ListItems
            });



            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext
            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            payment = new Payment() { id = paymentId };

            return payment.Execute(apiContext, paymentExecution);
        }



        public ActionResult PaymentWithPaypal()
        {
            //getting the apiContext as earlier
            APIContext apiContext = Configuration.GetAPIContext();

            
                string payerId = Request.Params["PayerID"];

                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist
                    //it is returned by the create function call of the payment class

                    // Creating a payment
                    // baseURL is the url on which paypal sendsback the data.
                    // So we have provided URL of this controller only
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                "/Cart/PaymentWithPayPal?";

                    //guid we are generating for storing the paymentID received in session
                    //after calling the create function and it is used in the payment execution

                    var guid = Convert.ToString((new Random()).Next(100000));

                    //CreatePayment function gives us the payment approval url
                    //on which payer is redirected for paypal account payment

                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                    //get links returned from paypal in response to Create function call

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;

                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment
                            paypalRedirectUrl = link.href;
                        }
                    }

                    // saving the paymentID in the key guid
                    Session.Add(guid, createdPayment.id);

                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This section is executed when we have received all the payments parameters

                    // from the previous call to the function Create

                    // Executing a payment

                    var guid = Request.Params["guid"];


                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("failure");
                    }
                }



            return RedirectToAction("mail");

           
            
        }

     

        

        
    }

   
}