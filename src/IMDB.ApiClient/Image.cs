using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient
{
    public class Image
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public string Url { get; set; }

        private Image(int height, int width, string url)
        {
            Height = height;
            Width = width;
            Url = url;
        }

        public static Image Restore(int height, int width, string url)
        {
            return new Image(height, width, url);
        }

    }
}
