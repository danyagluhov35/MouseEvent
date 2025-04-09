using Application.DTO;

namespace Application.Interfaces
{
    /// <summary>
    ///     Сервис для обработки и сохранения данных о перемещении мыши.
    /// </summary>
    public interface IMouseMovementService
    {
        Task Save(List<MousePoint> points);
    }
}
