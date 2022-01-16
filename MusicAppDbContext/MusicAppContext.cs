using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicAppModels;

namespace MusicAppDbContext
{
    public class MusicAppContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=localhost; Initial Catalog=MusicAppMvc; Integrated Security=true");

        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Music>()
                .HasMany(p => p.Users)
                .WithMany(p => p.Musics)
                .UsingEntity<WishList>(
                    j => j
                        .HasOne(pt => pt.User)
                        .WithMany(t => t.WishLists)
                        .HasForeignKey(pt => pt.Id),
                    j => j
                        .HasOne(pt => pt.Music)
                        .WithMany(p => p.WishLists)
                        .HasForeignKey(pt => pt.MusicId),
                    j =>
                    {
                        j.Property(pt => pt.WishListId);
                        j.HasKey(t => new { t.MusicId, t.Id });
                    });
        }
    }
}
