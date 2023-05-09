using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.Services.Interfaces;

namespace UsersWebApiService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример тела запроса
        ///     {
        ///        "login": "New_user_login",
        ///        "password": "New_user_password",
        ///        "group_Code": "Admin"/"User"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Пользователь успешно создан</response>
        /// <response code="400">Некорректные данные (логин занят/администратор уже сущесвует)</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Внутренняя ошибка сервера</response>

        [HttpPost]
        public async Task<JsonResult> CreateUser([FromBody, Required] CreatedUserDTO CreatedUserInfo)
        {
            var response = await _usersService.CreateUser(CreatedUserInfo);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос всех пользователей
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            var response = await _usersService.GetAllUsers();
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос всех пользователей на выбранной странице (по 5 пользователей)
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="422">Некорректное значение номера страницы</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetUsersOnSelectedPage([Required] int selected_page)
        {
            var response = await _usersService.GetUsersOnSelectedPage(selected_page);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос активных пользователей
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetActiveUsers()
        {
            var response = await _usersService.GetActiveUsers();
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос активных пользователей на выбранной странице (по 5 пользователей)
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="422">Некорректное значение номера страницы</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetActiveUsersOnSelectedPage([Required] int selected_page)
        {
            var response = await _usersService.GetActiveUsersOnSelectedPage(selected_page);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос пользователя по Id
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пользователь не найден</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetUserById([Required] Guid Id)
        {
            var response = await _usersService.GetUserById(Id);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Запрос пользователя по логину
        /// </summary>
        /// <response code="200">Данные успешно получены</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пользователь не найден</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        public async Task<JsonResult> GetUserByLogin([Required] string Login)
        {
            var response = await _usersService.GetUserByLogin(Login);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <response code="200">Пользователь успешно удален</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пользователь не найден</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete]
        public async Task<JsonResult> DeleteUserById(Guid Id)
        {
            var response = await _usersService.DeleteUserById(Id);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }

        /// <summary>
        /// Удаление пользователя по логину
        /// </summary>
        /// <response code="200">Пользователь успешно удален</response>
        /// <response code="401">Ошибка авторизации</response>
        /// <response code="404">Пользователь не найден</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete]
        public async Task<JsonResult> DeleteUserByLogin(string Login)
        {
            var response = await _usersService.DeleteUserByLogin(Login);
            return new JsonResult(response)
            {
                StatusCode = (int)response.StatusCode,
            };
        }


    }
}
