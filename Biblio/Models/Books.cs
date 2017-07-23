using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Stock { get; set; }
    }
}