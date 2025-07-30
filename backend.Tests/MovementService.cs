using Moq;
using backend.Models;
using backend.Repository;
using backend.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace backend.Tests
{
    public class MovementServiceTests
    {
        private readonly Mock<IMovementRepository> _movementRepositoryMock;
        private readonly Mock<IPartRepository> _partRepositoryMock;
        private readonly Mock<IStationRepository> _stationRepositoryMock;
        private readonly MovementService _service;

        public MovementServiceTests()
        {
            _movementRepositoryMock = new Mock<IMovementRepository>();
            _partRepositoryMock = new Mock<IPartRepository>();
            _stationRepositoryMock = new Mock<IStationRepository>();

            _service = new MovementService(
                _movementRepositoryMock.Object,
                _stationRepositoryMock.Object,
                _partRepositoryMock.Object
            );
        }

        [Fact]
        public void Create_ShouldMovePartToFirstStation_WhenPartIsNew()
        {
            var part = new Part("Peça Nova") { Id = Guid.NewGuid(), CurrentStationId = null };
            var station1 = new Station { Id = Guid.NewGuid(), Name = "Recebimento", Number = 1 };
            var movement = new Movement { PartId = part.Id, DestinationStationId = station1.Id };

            _partRepositoryMock.Setup(repo => repo.GetById(part.Id)).Returns(part);
            _stationRepositoryMock.Setup(repo => repo.GetById(station1.Id)).Returns(station1);

            _service.Create(movement);

            Assert.Equal("Recebida", part.Status);
            _partRepositoryMock.Verify(repo => repo.Update(part), Times.Once);
            _movementRepositoryMock.Verify(repo => repo.Add(It.IsAny<Movement>()), Times.Once);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenSkippingAStation()
        {
            var station1 = new Station { Id = Guid.NewGuid(), Name = "Recebimento", Number = 1 };
            var station3 = new Station { Id = Guid.NewGuid(), Name = "Inspeção", Number = 3 };
            var part = new Part("Peça em processo") { Id = Guid.NewGuid(), CurrentStationId = station1.Id };
            var movement = new Movement { PartId = part.Id, DestinationStationId = station3.Id };

            _partRepositoryMock.Setup(repo => repo.GetById(part.Id)).Returns(part);
            _stationRepositoryMock.Setup(repo => repo.GetById(station3.Id)).Returns(station3);
            _stationRepositoryMock.Setup(repo => repo.GetById(part.CurrentStationId.Value)).Returns(station1);

            var action = () => _service.Create(movement);
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Create_ShouldSetStatusToFinalizada_WhenMovingToLastStation()
        {
            var station2 = new Station { Id = Guid.NewGuid(), Name = "Montagem", Number = 2 };
            var station3 = new Station { Id = Guid.NewGuid(), Name = "Inspeção", Number = 3 };
            var part = new Part("Peça Quase Pronta") { Id = Guid.NewGuid(), CurrentStationId = station2.Id };
            var movement = new Movement { PartId = part.Id, DestinationStationId = station3.Id };

            _partRepositoryMock.Setup(repo => repo.GetById(part.Id)).Returns(part);
            _stationRepositoryMock.Setup(repo => repo.GetById(station3.Id)).Returns(station3);
            _stationRepositoryMock.Setup(repo => repo.GetById(part.CurrentStationId.Value)).Returns(station2);
            _stationRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Station> { new Station { Number = 1 }, station2, station3 });

            _service.Create(movement);

            Assert.Equal("Finalizada", part.Status);
            _partRepositoryMock.Verify(repo => repo.Update(part), Times.Once);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenMovingBackward()
        {
            var station1 = new Station { Id = Guid.NewGuid(), Name = "Recebimento", Number = 1 };
            var station2 = new Station { Id = Guid.NewGuid(), Name = "Montagem", Number = 2 };
            var part = new Part("Peça em Montagem") { Id = Guid.NewGuid(), CurrentStationId = station2.Id };
            var movement = new Movement { PartId = part.Id, DestinationStationId = station1.Id };

            _partRepositoryMock.Setup(repo => repo.GetById(part.Id)).Returns(part);
            _stationRepositoryMock.Setup(repo => repo.GetById(station1.Id)).Returns(station1);
            _stationRepositoryMock.Setup(repo => repo.GetById(part.CurrentStationId.Value)).Returns(station2);

            var action = () => _service.Create(movement);
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Create_ShouldThrowException_WhenPartIsAlreadyFinished()
        {
            var station3 = new Station { Id = Guid.NewGuid(), Name = "Inspeção", Number = 3 };
            var part = new Part("Peça Finalizada") { 
                Id = Guid.NewGuid(), 
                CurrentStationId = station3.Id, 
                Status = "Finalizada"
            };
            var movement = new Movement { PartId = part.Id, DestinationStationId = station3.Id };

            _partRepositoryMock.Setup(repo => repo.GetById(part.Id)).Returns(part);
            _stationRepositoryMock.Setup(repo => repo.GetById(station3.Id)).Returns(station3);

            var action = () => _service.Create(movement);
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
