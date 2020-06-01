using ImageRetriever.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageRetriever.Common
{
    static class Attributes
    {
        public static ObservableCollection<string> AttributeList = new ObservableCollection<string>();
        public static List<CustomAttributeList> PostAttributeList = new List<CustomAttributeList>();
        public static string PostAttributeString;
        //public static List<String> PostSelectedCustomAttributeField
        //{
        //    get
        //    {
        //        foreach(var x )
        //    }

        //}

    }
}
