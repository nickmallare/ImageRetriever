﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Foundation;
using UIKit;

namespace ImageRetriever.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
              
            }
            catch(Exception ex)
            {
                var test = ex.Message;
            }
        }
    }
}