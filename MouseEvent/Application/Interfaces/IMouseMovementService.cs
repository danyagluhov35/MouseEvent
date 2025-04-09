using Application.DTO;

namespace Application.Interfaces
{
    /// <summary>
    ///     ������ ��� ��������� � ���������� ������ � ����������� ����.
    /// </summary>
    public interface IMouseMovementService
    {
        Task Save(List<MousePoint> points);
    }
}
