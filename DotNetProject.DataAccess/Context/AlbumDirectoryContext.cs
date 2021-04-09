using DotNetProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetProject.DataAccess.Context
{
    public partial class AlbumDirectoryContext : DbContext
    {
        public AlbumDirectoryContext()
        {
        }

        public AlbumDirectoryContext(DbContextOptions<AlbumDirectoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Album> Album { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.AlbumName).IsRequired();

                entity.Property(e => e.NumberOfSongs).IsRequired();

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_Album_Artist");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
