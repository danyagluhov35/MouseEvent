using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MouseEvent.Tests 
{
    public class MouseMovementServiceTests
    {
        private readonly DbContextOptions<ApplicationContext> options;
        private readonly ApplicationContext context;
        private readonly IMouseMovementService mouseMovementService;

        public MouseMovementServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new ApplicationContext(options);
            mouseMovementService = new MouseMovementService(context);
        }

        /// <summary>
        ///     Метод для сохранения одной точки перемещения и получения первого сохраненного движения
        /// </summary>
        /// <returns>Сохранённая запись о перемещении мыши</returns>
        public async Task<MouseMovement> SaveSinglePoint()
        {
            var points = new List<MousePoint> { new() { X = 10, Y = 20, T = 30 } };
            await mouseMovementService.Save(points);
            return await context.MouseMovements.FirstOrDefaultAsync();
        }

        /// <summary>
        ///     Проверка на null
        /// </summary>
        [Fact]
        public async Task MousePointNotNull()
        {
            var result = await SaveSinglePoint();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Проверка на соответсвтие
        /// </summary>
        [Fact]
        public async Task MousePointContain()
        {
            var result = await SaveSinglePoint();

            Assert.Contains("10", result.MovementPoints);
        }
    }
}
