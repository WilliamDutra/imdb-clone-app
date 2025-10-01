using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMDB.ApiClient.GetImagesOfMovie
{
    public class MovieImages
    {
        [JsonPropertyName("backdrops")]
        public Backdrop[] Backdrops { get; set; }

        public class Backdrop
        {
            [JsonPropertyName("aspect_ratio")]
            public decimal AspectRatio { get; set; }

            [JsonPropertyName("height")]
            public int Height { get; set; }

            [JsonPropertyName("width")]
            public int Width { get; set; }

            [JsonPropertyName("file_path")]
            public string FilePath { get; set; }

        }

    }
}
