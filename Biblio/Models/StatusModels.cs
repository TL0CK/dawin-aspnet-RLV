using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Biblio.Models
{
    public class StatusModels
    {
        public int ID { get; set; }
        public string ShortLibStatus { get; set; }
        public string LibStatus { get; set; }
        public DateTime StartBorrowingTime { get; set; }
        public DateTime ExpectedEndBorrowingTime { get; set; }
        public ApplicationUser CurrentOwner { get; set; }
    }
}