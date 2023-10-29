using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Models
{
    public class ImageModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Download_url { get; set; }
    }
}
