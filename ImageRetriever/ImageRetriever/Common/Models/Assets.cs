using System;
using System.Collections.Generic;
using System.Text;

namespace ImageRetriever.Common.Models
{
    /// <summary>
    /// Contains list of AssetRecords
    /// </summary>
    public class Asset
    {
        public int ID { get; set; }
        public object Name { get; set; }
        public object Description { get; set; }
        public int AssetTypeId { get; set; }
        public object AssetTypeDesc { get; set; }
        public object AssetStatusName { get; set; }
        public object AssetTypeImage { get; set; }
        public object AssetTypeIconImage { get; set; }
        public object LocationName { get; set; }
        public int LocationId { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public object LastSeenDate { get; set; }
        public int RTLSZoneId { get; set; }
        public object Assets { get; set; }
        public object AssetList { get; set; }
        public object AssetTypeImageList { get; set; }
        public object AssetsForDrawing { get; set; }
        public object Zones { get; set; }
        public object SiteFloorAssetCountDetails { get; set; }
        public object BuildingFloorAssetCountDetails { get; set; }
        public int TotalAssetsCount { get; set; }
        public List<AssetRecord> AssetRecords { get; set; }
    }
}
