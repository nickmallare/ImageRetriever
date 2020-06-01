using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.ItemSearch.Models
{
    public class ItemSearchModel
    {
        public partial class Status
        {
            public int ID { get; set; }

            public string Name { get; set; }
        }
        public partial class AssetType
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageType { get; set; }
            public long ItemsNumber { get; set; }
            public string IconImage { get; set; }
            public string ImagePath { get; set; }
            public string IconType { get; set; }
            public string AssetTypeIcon { get; set; }
            public string IconPath { get; set; }
            public long CompanyId { get; set; }
            public bool IsFixedLocation { get; set; }
            public bool IsContainer { get; set; }
            public bool IsDisabled { get; set; }
            public bool IsInternal { get; set; }
            public long CreatedBy { get; set; }
            public string ItemCode { get; set; }
            public string SerialNumber { get; set; }
            public string AssetTypeFieldList { get; set; }
        }
        public partial class Location
        {

            public int LocationId { get; set; }


            public int Id { get; set; }

         
            public string LocationName { get; set; }

       
            public string LocationHierarchy { get; set; }

        
            public bool Selected { get; set; }

        
            public bool IsPrimaryLocation { get; set; }

            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }
        public partial class ItemAttribute
        {
            public string ControlLabelText { get; set; }
            public bool IsDisabled { get; set; }
            public string DataTypeName { get; set; }
            public string DataTypeId { get; set; }
            public string Id { get; set; }
            public bool IsDisplayOnSearch { get; set; }

        }
    }
}
