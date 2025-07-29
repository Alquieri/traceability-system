using backend.Services.Interfaces;
using backend.Models;
using backend.Repository;

namespace backend.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IStationRepository _stationRepository;
        private readonly IPartRepository _partRepository;

        public MovementService(IMovementRepository movementRepository, IStationRepository stationRepository, IPartRepository partRepository)
        {
            _movementRepository = movementRepository;
            _stationRepository = stationRepository;
            _partRepository = partRepository;
        }

        public IEnumerable<Movement> GetAll()
        {
            return _movementRepository.GetAll();
        }

        public IEnumerable<Movement> GetByPartId(Guid partId)
        {
            return _movementRepository.GetByPartId(partId);
        }

        public void Create(Movement movement)
        {
            var part = _partRepository.GetById(movement.PartId);
            var destinationStation = _stationRepository.GetById(movement.StationId);

            if (part == null || destinationStation == null)
            {
                throw new KeyNotFoundException("Peça ou Estação de destino não encontrada.");
            }

            ValidateMovement(part, destinationStation);

            part.CurrentStationId = destinationStation.Id;
            part.Status = destinationStation.Number switch
            {
                1 => "Recebida",
                2 => "Montando",
                3 => "Finalizada",
                _ => part.Status
            };
            _partRepository.Update(part);

            _movementRepository.Add(movement);
        }

        public Movement? GetLastByPart(Guid partId)
        {
            return _movementRepository.GetLastByPart(partId);
        }

        private void ValidateMovement(Part part, Station destinationStation)
        {
            if (part.Status == "Finalizada")
            {
                throw new InvalidOperationException("Não é possível mover uma peça finalizada.");
            }

            if (part.CurrentStationId == null)
            {
                if (destinationStation.Number != 1)
                {
                    throw new InvalidOperationException("A primeira movimentação de uma peça deve ser para a estação de 'Recebimento'.");
                }
            }
            else
            {
                var currentStation = _stationRepository.GetById(part.CurrentStationId.Value);
                if (destinationStation.Number != currentStation.Number + 1)
                {
                    throw new InvalidOperationException("Movimentação inválida: a peça só pode avançar para a próxima estação da sequência.");
                }
            }
        }
    }
}