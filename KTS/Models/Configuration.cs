﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace KTS.Models
{
    public class Configuration
    {
       
        //these variables will store the clientID and clientSecret
        //by reading them from the web.config
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static Configuration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            // getting accesstocken from paypal                
            string accessToken = new OAuthTokenCredential
        (ClientId, ClientSecret, GetConfig()).GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }

    }
}