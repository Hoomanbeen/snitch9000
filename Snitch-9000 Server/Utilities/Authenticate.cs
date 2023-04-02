using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using snitch_9000.Models;
using snitch_9000.Data;

namespace snitch_9000.Utilities
{
    public class Authenticate
    {
        public static User AuthenticateUser(ISnitchRepo repo, HttpContext context)
        {
            if(!context.Request.Cookies.ContainsKey("user_token")) return null;

            // var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            // return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            string b64 = context.Request.Cookies["user_token"];
            string[] data = Encoding.UTF8.GetString(Convert.FromBase64String(b64)).Split(':');

            try {
                
                string email = data[0];
                string password_hash = data[1];
                User u = repo.GetUserByEmail(email);
                if (u == null) return null;
                if (u.email != email || u.password != password_hash) return null;

                return u;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}