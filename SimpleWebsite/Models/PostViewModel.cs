using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebsite.Models
{
    public class PostViewModel
    {
        public int idPost { get; set; }
        public string Title { get; set; }        
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
    }
}