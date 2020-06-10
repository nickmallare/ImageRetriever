using System;
using Newtonsoft.Json;

namespace ImageRetriever.Common
{
    public class BlobInformation
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("BlobUrl")]
        public Uri BlobUrl { get; set; }
    }
}
