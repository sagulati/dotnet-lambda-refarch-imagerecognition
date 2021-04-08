using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ImageSize
    {
        /// <summary>
        /// S3 key
        /// </summary>
        public string Key { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Size { get; set; }
    }
}
