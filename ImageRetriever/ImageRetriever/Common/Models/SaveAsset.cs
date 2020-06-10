using System;
using System.Collections.Generic;

namespace ImageRetriever.Common.Models
{
    public class SaveAsset
    {
        public string ID { get; set; }
        public string PrimaryImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetTypeDesc { get; set; }
        public int LocationID { get; set; }
        public int CountryId { get; set; }
        public string ZoneId { get; set; }
        public string ZoneName { get; set; }
        public double ZoneLattitude { get; set; }
        public double ZoneLongitude { get; set; }
        public string LocationName { get; set; }
        public string IsDisabled { get; set; }
        public string IsInternal { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
        public string LastLocation { get; set; }
        public int LocationTypeId { get; set; }
        public string CurrentLocationAddress { get; set; }
        public string LastSeenDt { get; set; }
        public string CreatedOn { get; set; }
        public string ActiveTagId { get; set; }
        public string PassiveTagId { get; set; }
        public string TAGIds { get; set; }
        public string ModifiedBy { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string ShowAssetPosition { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusNameFromGrid { get; set; }
        public int AssetTypeFilter { get; set; }
        public string FormBuilderData { get; set; }
        public List<AssetFieldValueViewModelItem> AssetFieldValueViewModel { get; set; }
        public List<AssetTagsItem> AssetTags { get; set; }
        public int AssetSortBy { get; set; }
        public int TakeCount { get; set; }
        public int SkipCount { get; set; }
        public string AssetSortByFieldName { get; set; }
        public string TagType { get; set; }
        public string LastSeenDays { get; set; }
        public string AssetCreatedFrom { get; set; }
        public string AssetCreatedTo { get; set; }
        public int UserId { get; set; }
        public string AssetType { get; set; }
        public string SelectedCustomAttributeFields { get; set; }
        public string AssetIDs { get; set; }
        public string FloorId { get; set; }
        public string SearchText { get; set; }
        public List<ImagesNamesItem> ImagesNames { get; set; }
    }
}
