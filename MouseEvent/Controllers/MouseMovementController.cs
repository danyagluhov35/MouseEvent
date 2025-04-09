using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MouseMovementController : Controller
    {
        private readonly IMouseMovementService MouseService;

        public MouseMovementController(IMouseMovementService service)
        {
            MouseService = service;
        }

        /// <summary>
        ///     Отображает стартовую страницу
        /// </summary>
        /// <returns>Представление Index</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Получает список координат перемещения мыши от клиента и сохраняет их
        /// </summary>
        /// <param name="points">Список точек перемещения мыши, полученный из тела запроса</param>
        /// <returns>Ответ с кодом 200 OK при успешном сохранении</returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] List<MousePoint> points)
        {
            await MouseService.Save(points);
            return Ok();
        }

    }
}