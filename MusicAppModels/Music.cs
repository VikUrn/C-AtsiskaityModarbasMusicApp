using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAppModels
{
    public class Music
    {
        [Display(Name = "Numeris")]
        public int MusicId { get; set; }

        [Display(Name = "Atlikėjas")]
        public string Performer { get; set; }

        [Display(Name = "Dainos pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Žanras")]
        public string Genre { get; set; }

        [Display(Name = "Nuoroda")]
        public string Url { get; set; }

        public ICollection<User> Users { get; set; }
        public List<WishList> WishLists { get; set; }
    }
}