using System;

namespace ImageRetriever.Common.Models
{
    public class AssetRecord
    {
        public int RowNumber { get; set; }
        public int CompanyId { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetTypeID { get; set; }
        public object LocationID { get; set; }
        public string LocationName { get; set; }
        public string AssetTypeName { get; set; }
        public string TAGIds { get; set; }
        public string CreatedOn { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public object LastSeenDt { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsInternal { get; set; }
        public string ZoneName { get; set; }
        public int ZoneId { get; set; }
        public object LocationTypeId { get; set; }
        public string BrownColor { get; set; }
        public string Color { get; set; }
        public string Heighted { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
        private string imageName;
        public string ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                if(value == null)
                {
                    imageName = "";
                    HasImage = false;
                }
                else
                {
                    imageName = value;
                    HasImage = true;
                }
            }
        }
        public string BlobUrl { get; set; }
        public bool IsFavorite { get; set; }
        public string ImageList { get; set; }
        public bool HasImage { get; set; }

    }
}
