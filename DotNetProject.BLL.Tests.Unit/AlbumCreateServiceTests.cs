using System;
using System.Threading.Tasks;
using AutoFixture;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Contracts;
using DotNetProject.BLL.Implementation;
using DotNetProject.Domain;
using DotNetProject.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DotNetProject.BLL.Tests.Unit
{
    class AlbumCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_ArtistValidationSucceed_CreatesAlbum()
        {
            // Arrange
            var album = new AlbumUpdateModel();
            var expected = new Album();

            var artistGetService = new Mock<IArtistGetService>();
            artistGetService.Setup(x => x.ValidateAsync(album));

            var albumDataAccess = new Mock<IAlbumDataAccess>();
            albumDataAccess.Setup(x => x.InsertAsync(album)).ReturnsAsync(expected);

            var albumGetService = new AlbumCreateService(albumDataAccess.Object, artistGetService.Object);

            // Act
            var result = await albumGetService.CreateAsync(album);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_ArtistValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var album = new AlbumUpdateModel();
            var expected = fixture.Create<string>();

            var artistGetService = new Mock<IArtistGetService>();
            artistGetService
                .Setup(x => x.ValidateAsync(album))
                .Throws(new InvalidOperationException(expected));

            var albumDataAccess = new Mock<IAlbumDataAccess>();

            var albumGetService = new AlbumCreateService(albumDataAccess.Object, artistGetService.Object);

            // Act
            var action = new Func<Task>(() => albumGetService.CreateAsync(album));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            albumDataAccess.Verify(x => x.InsertAsync(album), Times.Never);
        }
    }
}
