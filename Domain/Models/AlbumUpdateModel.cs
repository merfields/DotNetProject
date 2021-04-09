using System;
using System.Collections.Generic;
using System.Text;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.Domain.Models
{
    public class AlbumUpdateModel:IArtistContainer, IAlbumIdentity
    {
        public int Id { get; set; }

        public string AlbumName { get; set; }

        public int NumberOfSongs { get; set; }

        public int AlbumLength { get; set; }

        public int Rating { get; set; }

        public int ArtistId { get; set; }
    }
}
