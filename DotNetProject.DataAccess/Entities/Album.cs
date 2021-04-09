using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetProject.DataAccess.Entities
{
    public partial class Album
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AlbumName { get; set; }
       
        public int NumberOfSongs { get; set; }
        public int AlbumLength { get; set; }
        public int Rating { get; set; }
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
