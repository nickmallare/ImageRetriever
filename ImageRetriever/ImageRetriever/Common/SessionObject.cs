using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Common
{
    public static class SessionObjects
    {
        public static string BaseURL { get; set; }
        public static string Tenant { get; set; }
        public static string BaseImageURL { get; set; }
        public static string AppURL
        {
            get
            {
                string rtnUrl = "";
                if (!BaseURL.EndsWith(@"/"))
                    BaseURL = BaseURL + @"/";
                if (!BaseURL.StartsWith("https://"))
                    BaseURL = "https://" + BaseURL;
                rtnUrl = BaseURL + Tenant;
                return rtnUrl;
            }
        }

        public static string ApiURL
        {
            get
            {
                if(BaseURL != null)
                { 
                    if (!BaseURL.EndsWith(@"/"))
                        BaseURL = BaseURL + @"/";
                    if (!BaseURL.StartsWith("https://"))
                        BaseURL = "https://" + BaseURL;
                    return BaseURL;
                }
                else
                {
                    return "";
                }
            }
        }

        public static string Token { get; set; } = "";
        public static int ID { get; set; }
        public static string UserName { get; set; }


    }
}

