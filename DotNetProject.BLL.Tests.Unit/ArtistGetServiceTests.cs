using System;
using System.Threading.Tasks;
using AutoFixture;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Implementation;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DotNetProject.BLL.Tests.Unit
{
    public class ArtistGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ArtistExists_DoesNothing()
        {
            // Arrange
            var artistContainer = new Mock<IArtistContainer>();

            var artist = new Artist();
            var artistDataAccess = new Mock<IArtistDataAccess>();
            artistDataAccess.Setup(x => x.GetByAsync(artistContainer.Object)).ReturnsAsync(artist);

            var artistGetService = new ArtistGetService(artistDataAccess.Object);

            // Act
            var action = new Func<Task>(() => artistGetService.ValidateAsync(artistContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_ArtistNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var artistContainer = new Mock<IArtistContainer>();
            artistContainer.Setup(x => x.ArtistId).Returns(id);

            var artist = new Artist();
            var artistDataAccess = new Mock<IArtistDataAccess>();
            artistDataAccess.Setup(x => x.GetByAsync(artistContainer.Object)).ReturnsAsync((Artist)null);

            var artistGetService = new ArtistGetService(artistDataAccess.Object);

            // Act
            var action = new Func<Task>(() => artistGetService.ValidateAsync(artistContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Artist not found by id {id}");
        }
    }
}
