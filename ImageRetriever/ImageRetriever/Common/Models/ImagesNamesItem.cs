using System;
namespace ImageRetriever.Common.Models
{
    public class ImagesNamesItem
    {
        public string ImageName { get; set; }
        public string OriginalName { get; set; }
        public string IsPrimary { get; set; }
        public string BlobUrl { get; set; }
        

        public ImagesNamesItem(string ImageName, string OriginalName, string IsPrimary, string BlobUrl)
        {
            this.ImageName = ImageName;
            this.OriginalName = OriginalName;
            this.IsPrimary = IsPrimary;
            this.BlobUrl = BlobUrl;
        }
    }

}
