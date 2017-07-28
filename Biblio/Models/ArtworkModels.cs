using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.Models
{
    public class ArtworkModels
    {
        public int ID { get; set; }
        public AuthorModels Author { get; set; }
        public BookGenreModels BookGenre { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}