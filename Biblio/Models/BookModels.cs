using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class BookModels
    {
        public int ID { get; set; }
        public ArtworkModels Oeuvre { get; set; }
        public DateTime OwnershipDate { get; set; }
        public StatusModels Status { get; set; }
    }

    public class BookDBContext : DbContext
    {
        public DbSet<BookModels> BookModels { get; set; }
    }
}