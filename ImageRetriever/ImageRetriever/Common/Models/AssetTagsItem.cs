using System;
namespace ImageRetriever.Common.Models
{
    public class AssetTagsItem
    {
        public string Id { get; set; }
        public string AssetId { get; set; }
        public string TagTypeId { get; set; }
        public string TagId { get; set; }
        public string IsDisabled { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string Remarks { get; set; }
    }
}
