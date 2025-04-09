using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    /// <summary>
    ///     ������ ��� ��������� � ���������� ������ � ����������� ����
    /// </summary>
    public class MouseMovementService : IMouseMovementService
    {
        private readonly ApplicationContext db;

        public MouseMovementService(ApplicationContext db)
        {
            this.db = db;
        }

        /// <summary>
        ///     ��������� ������ � ����������� ���� � ��
        /// </summary>
        /// <param name="points">������ ����� ����������� ����</param>
        public async Task Save(List<MousePoint> points)
        {
            try
            {
                db.MouseMovements.Add(new MouseMovement() { MovementPoints = JsonConvert.SerializeObject(points) });
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
