using System;
using System.Collections.Generic;

namespace ImageRetriever.Common.Models
{
    public class AssetFieldValueViewModelItem
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
        public int GenericFieldId { get; set; }
        public string DataType { get; set; }
        public Validation validation { get; set; }
        public List<string> options { get; set; }
        public int OrderNumber { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public int MaxLength { get; set; }
    }

}
