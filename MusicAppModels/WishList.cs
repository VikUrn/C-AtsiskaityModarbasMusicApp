
using System.ComponentModel.DataAnnotations;

namespace MusicAppModels
{
    public class WishList
    {
        public int WishListId { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }

        public string Id { get; set; }
        public User User { get; set; }
    }
}
