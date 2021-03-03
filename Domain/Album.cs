using System;
using System.Collections.Generic;
using System.Text;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.Domain
{
    public class Album : IArtistContainer
    {
        public int Id { get; set; }

        public string AlbumName { get; set; }

        public Artist Artist { get; set; }

        public int NumberOfSongs { get; set; }

        public int AlbumLength { get; set; }

        public int Rating { get; set; }

        int IArtistContainer.ArtistId => this.Artist.Id;
    }
}
