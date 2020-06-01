using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Common
{
    public class Operators
    {
        public class AssetTypeViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public object ImageType { get; set; }
            public string ItemsNumber { get; set; }
            public object IconImage { get; set; }
            public object ImagePath { get; set; }
            public object IconType { get; set; }
            public object AssetTypeIcon { get; set; }
            public object IconPath { get; set; }
            public string CompanyId { get; set; }
            public bool IsFixedLocation { get; set; }
            public bool IsContainer { get; set; }
            public bool IsDisabled { get; set; }
            public bool IsInternal { get; set; }
            public string CreatedBy { get; set; }
            public object ItemCode { get; set; }
            public object SerialNumber { get; set; }
            public object AssetTypeFieldList { get; set; }
        }

        public class Status
        {
            public string Name { get; set; }
            public object Description { get; set; }
            public bool IsCustom { get; set; }
            public object ToStatusId { get; set; }
            public object AssetTypeId { get; set; }
            public bool IsFirst { get; set; }
            public bool IsLast { get; set; }
            public bool IsScheduled { get; set; }
            public bool IsRecursive { get; set; }
            public object Order { get; set; }
            public object ScheduledDays { get; set; }
            public object ScheduleDays { get; set; }
            public int CreatedBy { get; set; }
            public bool IsDisabled { get; set; }
            public DateTime CreatedOn { get; set; }
            public string CompanyId { get; set; }
            public string Id { get; set; }
            public object SubscribedUsers { get; set; }
            public object ModifiedBy { get; set; }
            public object ModifiedOn { get; set; }
            public object StatusTransitionList { get; set; }
            public object StatusList { get; set; }
            public bool IsMapped { get; set; }
            public object RuleExpressionId { get; set; }
            public bool IsContainer { get; set; }
        }

        public class ReportStatu
        {
            public string Name { get; set; }
            public object Description { get; set; }
            public bool IsCustom { get; set; }
            public object ToStatusId { get; set; }
            public object AssetTypeId { get; set; }
            public bool IsFirst { get; set; }
            public bool IsLast { get; set; }
            public bool IsScheduled { get; set; }
            public bool IsRecursive { get; set; }
            public object Order { get; set; }
            public object ScheduledDays { get; set; }
            public object ScheduleDays { get; set; }
            public string CreatedBy { get; set; }
            public bool IsDisabled { get; set; }
            public DateTime CreatedOn { get; set; }
            public string CompanyId { get; set; }
            public string Id { get; set; }
            public object SubscribedUsers { get; set; }
            public object ModifiedBy { get; set; }
            public object ModifiedOn { get; set; }
            public object StatusTransitionList { get; set; }
            public object StatusList { get; set; }
            public bool IsMapped { get; set; }
            public object RuleExpressionId { get; set; }
            public bool IsContainer { get; set; }
        }

        public class Operator
        {
            public string Id { get; set; }
            public string CompanyId { get; set; }
            public string OperatorName { get; set; }
            public string OperatorKey { get; set; }
            public bool IsDisabled { get; set; }
            public int DataTypeId { get; set; }
            public string DataType { get; set; }
            public string SortOrder { get; set; }

        }

        public class GenericField
        {
            public string Id { get; set; }
            public string CompanyId { get; set; }
            public string ControlLabelText { get; set; }
            public string DataTypeId { get; set; }
            public object DataTypeCodeId { get; set; }
            public string Description { get; set; }
            public string DataTypeName { get; set; }
            public object DataTypeCode { get; set; }
            public bool IsRequired { get; set; }
            public string MaxLength { get; set; }
            public bool IsDisplayOnSearch { get; set; }
            public bool IsDisplayOnGrid { get; set; }
            public object CustomSourceTypeId { get; set; }
            public object OrderNumber { get; set; }
            public string CustomSourceTypeName { get; set; }
            public string SortOrder { get; set; }
            public bool IsDisabled { get; set; }
            public DateTime CreatedOn { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? ModifiedOn { get; set; }
            public string ModifiedBy { get; set; }
            public object CustomSourceTypes { get; set; }
            public object DataTypes { get; set; }
            public object MinValue { get; set; }
            public object MaxValue { get; set; }
            public bool IsAssignedToAssetType { get; set; }
            public object TotalMaxLengthOccupied { get; set; }
            public object MinValueOfAsset { get; set; }
            public object MaxValueOfAsset { get; set; }
            public bool IsDataTypeDisabled { get; set; }
            public bool IsAttributeDisabled { get; set; }
            public bool IsMandatoryOption { get; set; }
        }

        public class Zone
        {
            public int Id { get; set; }
            public object LocationId { get; set; }
            public string Name { get; set; }
            public object Description { get; set; }
            public object ZoneTypeId { get; set; }
            public string RTLSTypeId { get; set; }
            public string X1 { get; set; }
            public string Y1 { get; set; }
            public string X2 { get; set; }
            public string Y2 { get; set; }
            public string RTLSLayoutId { get; set; }
            public string CompanyId { get; set; }
            public bool IsDisabled { get; set; }
            public DateTime CreatedOn { get; set; }
            public string CreatedBy { get; set; }
            public object ModifiedOn { get; set; }
            public object ModifiedBy { get; set; }
            public object ZoneIdTo { get; set; }
            public object ZoneNameTo { get; set; }
            public object Devices { get; set; }
            public object DeviceAntennas { get; set; }
            public object IsScaled { get; set; }
        }

        public class RootObject
        {
            public IList<AssetTypeViewModel> AssetTypeViewModel { get; set; }
            public object TagTypes { get; set; }
            public IList<Status> Status { get; set; }
            public IList<ReportStatu> ReportStatus { get; set; }
            public IList<Operator> Operators { get; set; }
            public object AssetStatus { get; set; }
            public IList<GenericField> GenericFields { get; set; }
            public object UserCountries { get; set; }
            public object UserCountriesList { get; set; }
            public string TimeZoneOffsetPreferred { get; set; }
            public IList<Zone> Zones { get; set; }
            public string ReportServerUrl { get; set; }
            public object SSRSReports { get; set; }
        }


    }
}
