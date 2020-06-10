using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ImageRetriever.Common.Models
{
    public partial class DetailedAssetInformation
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("PrimaryImageId")]
        public string PrimaryImageId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("AssetTypeID")]
        public string AssetTypeId { get; set; }

        [JsonProperty("AssetTypeName")]
        public string AssetTypeName { get; set; }

        [JsonProperty("AssetTypeDesc")]
        public string AssetTypeDesc { get; set; }

        [JsonProperty("LocationID")]
        public string LocationId { get; set; }

        [JsonProperty("CountryId")]
        public long CountryId { get; set; }

        [JsonProperty("ZoneId")]
        public string ZoneId { get; set; }

        [JsonProperty("ZoneName")]
        public string ZoneName { get; set; }

        [JsonProperty("ZoneLattitude")]
        public long ZoneLattitude { get; set; }

        [JsonProperty("ZoneLongitude")]
        public long ZoneLongitude { get; set; }

        [JsonProperty("LocationName")]
        public string LocationName { get; set; }

        [JsonProperty("IsDisabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("IsInternal")]
        public string IsInternal { get; set; }

        [JsonProperty("CompanyID")]
        public long CompanyId { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }

        [JsonProperty("LastLocation")]
        public string LastLocation { get; set; }

        [JsonProperty("LocationTypeId")]
        public long LocationTypeId { get; set; }

        [JsonProperty("CurrentLocationAddress")]
        public string CurrentLocationAddress { get; set; }

        [JsonProperty("LastSeenDt")]
        public string LastSeenDt { get; set; }

        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("ActiveTagId")]
        public string ActiveTagId { get; set; }

        [JsonProperty("PassiveTagId")]
        public string PassiveTagId { get; set; }

        [JsonProperty("TAGIds")]
        public string TagIds { get; set; }

        [JsonProperty("ModifiedBy")]
        public long ModifiedBy { get; set; }

        [JsonProperty("X")]
        public long X { get; set; }

        [JsonProperty("Y")]
        public long Y { get; set; }

        [JsonProperty("ShowAssetPosition")]
        public bool ShowAssetPosition { get; set; }

        [JsonProperty("StatusId")]
        public long StatusId { get; set; }

        [JsonProperty("StatusName")]
        public string StatusName { get; set; }

        [JsonProperty("StatusNameFromGrid")]
        public string StatusNameFromGrid { get; set; }

        [JsonProperty("AssetTypeFilter")]
        public long AssetTypeFilter { get; set; }

        [JsonProperty("FormBuilderData")]
        public object FormBuilderData { get; set; }

        [JsonProperty("AssetFieldValueViewModel")]
        public AssetFieldValueViewModel[] AssetFieldValueViewModel { get; set; }

        [JsonProperty("AssetTags")]
        public AssetTag[] AssetTags { get; set; }

        [JsonProperty("CustomFieldsFilterData")]
        public object CustomFieldsFilterData { get; set; }

        [JsonProperty("AssetSortBy")]
        public long AssetSortBy { get; set; }

        [JsonProperty("TakeCount")]
        public long TakeCount { get; set; }

        [JsonProperty("SkipCount")]
        public long SkipCount { get; set; }

        [JsonProperty("AssetSortByFieldName")]
        public object AssetSortByFieldName { get; set; }

        [JsonProperty("TagType")]
        public object TagType { get; set; }

        [JsonProperty("LastSeenDays")]
        public object LastSeenDays { get; set; }

        [JsonProperty("AssetCreatedFrom")]
        public object AssetCreatedFrom { get; set; }

        [JsonProperty("AssetCreatedTo")]
        public object AssetCreatedTo { get; set; }

        [JsonProperty("UserId")]
        public long UserId { get; set; }

        [JsonProperty("AssetType")]
        public object AssetType { get; set; }

        [JsonProperty("SelectedCustomAttributeFields")]
        public object SelectedCustomAttributeFields { get; set; }

        [JsonProperty("AssetIDs")]
        public string AssetIDs { get; set; }

        [JsonProperty("FloorId")]
        public string FloorId { get; set; }

        [JsonProperty("SearchText")]
        public object SearchText { get; set; }

        [JsonProperty("ImagesNames")]
        public List<ImagesName> ImagesNames { get; set; }
    }

    public partial class AssetFieldValueViewModel
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("AssetTypeFieldId")]
        public long AssetTypeFieldId { get; set; }

        [JsonProperty("IsReadOnly")]
        public string IsReadOnly { get; set; }

        [JsonProperty("FieldValue")]
        public string FieldValue { get; set; }

        [JsonProperty("CreatedOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("CreatedBy")]
        public long CreatedBy { get; set; }

        [JsonProperty("ModifiedOn")]
        public object ModifiedOn { get; set; }

        [JsonProperty("ModifiedBy")]
        public object ModifiedBy { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("GenericFieldId")]
        public long GenericFieldId { get; set; }

        [JsonProperty("DataType")]
        public string DataType { get; set; }

        [JsonProperty("validation")]
        public Validation Validation { get; set; }

        [JsonProperty("options")]
        public Option[] Options { get; set; }

        [JsonProperty("OrderNumber")]
        public object OrderNumber { get; set; }

        [JsonProperty("MinValue")]
        public object MinValue { get; set; }

        [JsonProperty("MaxValue")]
        public object MaxValue { get; set; }

        [JsonProperty("MaxLength")]
        public long? MaxLength { get; set; }
    }

    public partial class Option
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class Validation
    {
        [JsonProperty("required")]
        public bool ValidationRequired { get; set; }
    }

    public partial class AssetTag
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("TagTypeId")]
        public long TagTypeId { get; set; }

        [JsonProperty("TagId")]
        public string TagId { get; set; }

        [JsonProperty("IsDisabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("CompanyId")]
        public long CompanyId { get; set; }

        [JsonProperty("CreatedBy")]
        public long CreatedBy { get; set; }

        [JsonProperty("CreatedOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedOn")]
        public string ModifiedOn { get; set; }

        [JsonProperty("Remarks")]
        public string Remarks { get; set; }
    }

    public partial class ImagesName
    {
        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("OriginalName")]
        public string OriginalName { get; set; }

        [JsonProperty("IsPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("BlobUrl")]
        public string BlobUrl { get; set; }
        public ImagesName(string ImageName, string OriginalName, bool IsPrimary, string BlobUrl)
        {
            this.ImageName = ImageName;
            this.OriginalName = OriginalName;
            this.IsPrimary = IsPrimary;
            this.BlobUrl = BlobUrl;
        }
    }
}
