using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Common.Models
{
    public class DetailedAssetInformation
    {
        public string Id { get; set; }
        public object PrimaryImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetTypeId { get; set; }
     
        public object AssetTypeName { get; set; }
        public object AssetTypeDesc { get; set; }
        public string LocationId { get; set; }
        public string CountryId { get; set; }
        public object ZoneId { get; set; }
        public object ZoneName { get; set; }
        public string ZoneLattitude { get; set; }
        public string ZoneLongitude { get; set; }
        public string LocationName { get; set; }
        public string IsDisabled { get; set; }
        public object IsInternal { get; set; }
        public string CompanyId { get; set; }
        public object CompanyName { get; set; }
        public string CountryName { get; set; }
        public object LastLocation { get; set; }
        public string LocationTypeId { get; set; }
        public object CurrentLocationAddress { get; set; }
        public string LastSeenDt { get; set; }
        public string CreatedOn { get; set; }
        public string ActiveTagId { get; set; }
        public object PassiveTagId { get; set; }
        public object TagIds { get; set; }
        public string ModifiedBy { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string ShowAssetPosition { get; set; }
        public string StatusId { get; set; }
        public object StatusName { get; set; }
        public object StatusNameFromGrid { get; set; }
        public string AssetTypeFilter { get; set; }
        public object FormBuilderData { get; set; }
        public AssetFieldValueViewModel[] AssetFieldValueViewModel { get; set; }
        public AssetTag[] AssetTags { get; set; }
        public object CustomFieldsFilterData { get; set; }
        public string AssetSortBy { get; set; }
        public string TakeCount { get; set; }
        public string SkipCount { get; set; }
        public object AssetSortByFieldName { get; set; }
        public object TagType { get; set; }
        public object LastSeenDays { get; set; }
        public object AssetCreatedFrom { get; set; }
        public object AssetCreatedTo { get; set; }
        public string UserId { get; set; }
        public object AssetType { get; set; }
        public object SelectedCustomAttributeFields { get; set; }
        public object AssetIDs { get; set; }
        public object FloorId { get; set; }
        public object SearchText { get; set; }
        public ImagesName[] ImagesNames { get; set; }
    }

    public partial class AssetFieldValueViewModel
    {
        public string Id { get; set; }
        public string AssetId { get; set; }
        public string AssetTypeFieldId { get; set; }
        public string IsReadOnly { get; set; }
        public string FieldValue { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public string GenericFieldId { get; set; }
        public string DataType { get; set; }
        public object[] Options { get; set; }
        public string OrderNumber { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string MaxLength { get; set; }
    }

 
    public partial class AssetTag
    {
        public string Id { get; set; }
        public string AssetId { get; set; }
        public string TagTypeId { get; set; }
        public string TagId { get; set; }
        public string IsDisabled { get; set; }
        public string CompanyId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string Remarks { get; set; }
    }

    public partial class ImagesName
    {
        public string ImageName { get; set; }
        public string OriginalName { get; set; }
        public string IsPrimary { get; set; }
        public string BlobUrl { get; set; }
    }
}
