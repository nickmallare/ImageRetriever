using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Common.Models
{
    public class Image
    {
        public string URL { get; set; }
        public string ID { get; set; }
        public bool HasImage { get; set; }
        public bool IsFavorite { get; set; }
        public Image(string URL, string ID)
        {
            this.URL = URL;
            this.ID = ID;
            HasImage = true;
            IsFavorite = false;
        }
        public Image(string ID)
        {
            this.ID = ID;
            HasImage = false;
            IsFavorite = false;
        }
        public Image(string URL, string ID, bool IsFavorite)
        {
            this.URL = URL;
            this.ID = this.ID;
            this.IsFavorite = IsFavorite;
        }
       
       
    }
}
