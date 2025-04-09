namespace Domain.Entities
{
    /// <summary>
    ///     ������ � ����������� ����, ���������� �������������, ������ ����� ����������� � ���� �������� ������
    /// </summary>
    public class MouseMovement
    {
        public MouseMovement()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string MovementPoints { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
