using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetProject.DataAccess.Entities
{
    public partial class Artist
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int YearOfBirth { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
