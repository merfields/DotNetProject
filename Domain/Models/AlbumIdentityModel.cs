using System;
using System.Collections.Generic;
using System.Text;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.Domain.Models
{
    
    class AlbumIdentityModel : IAlbumIdentity
    {
        public int Id { get; }

        public AlbumIdentityModel(int id)
        {
            this.Id = id;
        }

    }
}
