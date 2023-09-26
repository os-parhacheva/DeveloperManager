using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Domain
{
    public enum ContentType
    {
        Book = 10,
        Document = 20,
        File = 30,
        Image = 40,
        Video = 50
    }
    public class ContentUrlVO
    {
        public Guid ContentId { get; set; }
        public ContentType ContentType { get; set; } // 1 - Book, 2 - Document, 3 - File, 4 -Img , 5 -Video 
        public bool ReadOnly { get; set; }
        public string ServiceUrl { get; set; } = "";


    }
}
