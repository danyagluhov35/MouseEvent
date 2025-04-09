using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    /// <summary>
    ///     Сервис для обработки и сохранения данных о перемещении мыши
    /// </summary>
    public class MouseMovementService : IMouseMovementService
    {
        private readonly ApplicationContext db;

        public MouseMovementService(ApplicationContext db)
        {
            this.db = db;
        }

        /// <summary>
        ///     Сохраняет данные о перемещении мыши в БД
        /// </summary>
        /// <param name="points">Список точек перемещения мыши</param>
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
