using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MusicAppModels
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Music> Musics { get; set; }
        public List<WishList> WishLists { get; set; }
    }
}
