using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.DataLayer.DTO;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;
using UsersWebApiService.DataLayer.Responses;
using UsersWebApiService.Services.Interfaces;
using System.Linq;
using UsersWepApiService.DataLayer.Helpers;

namespace UsersWebApiService.Services.Implementations
{
    public class UsersService : IUsersService
    {
        const int page_size = 5;
        private readonly IUserRepository _userRepository;
        private readonly IUser_groupRepository _user_groupRepository;
        private readonly IUser_stateRepository _user_stateRepository;
        private readonly IMapper _mapper;
        public UsersService(IMapper mapper, IUserRepository userRepository, IUser_groupRepository user_groupRepository, IUser_stateRepository user_stateRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _user_groupRepository = user_groupRepository;
            _user_stateRepository = user_stateRepository;
        }
        public async Task<BaseRepsonse<Guid>> CreateUser(CreatedUserDTO CreatedUserInfo)
        {
            try
            {
                var user = await _userRepository.GetUserByLogin(CreatedUserInfo.Login);
                if (user != null) return new BaseRepsonse<Guid>(Description: "Пользователь с таким логином уже существует", StatusCode: StatusCode.BadRequest);

                if (CreatedUserInfo.Group_Code == group_code.Admin)
                {
                    user = await _userRepository.GetAdminUser();
                    if (user != null) return new BaseRepsonse<Guid>(Description: "Администратор уже существует", StatusCode: StatusCode.BadRequest);
                }

                var new_user = _mapper.Map<User>(CreatedUserInfo);
                new_user.Created_date = DateTime.Now;
                new_user.User_group_id = await _user_groupRepository.GetUser_groupIdByCode(CreatedUserInfo.Group_Code);
                new_user.User_state_id = await _user_stateRepository.GetUser_stateIdByCode(state_code.Active);

                await _userRepository.Create(new_user);

                var u = new_user;

                return new BaseRepsonse<Guid>()
                {
                    Description = "Пользователь успешно создан",
                    Data = new_user.Id,
                    StatusCode = StatusCode.Created
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<Guid>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<List<UserDTO>>> GetAllUsers()
        {
            try
            {
                var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetAllUsers());

                return new BaseRepsonse<List<UserDTO>>()
                {
                    Description = "Список пользователей успешно получен",
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<List<UserDTO>>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<UsersPageDTO>> GetUsersOnSelectedPage(int selected_page)
        {
            try
            {
                var page_count = (int)Math.Ceiling((double)await _userRepository.GetAllUsersCount() / page_size);
                if (selected_page <= 1 || selected_page > page_count) return new BaseRepsonse<UsersPageDTO>(Description: $"Некорректное значение страницы. Оно должно быть в пределах от 1 до {page_count}", StatusCode: StatusCode.UnprocessableContent);

                var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetUsersOnSelectedPage(selected_page, page_size));

                return new BaseRepsonse<UsersPageDTO>()
                {
                    Description = $"Страница {selected_page} с пользователями получена",
                    Data = new UsersPageDTO()
                    {
                        Users = users,
                        SelectedPage = selected_page,
                        PageCount = page_count
                    },
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<UsersPageDTO>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<List<UserDTO>>> GetActiveUsers()
        {
            try
            {
                var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetActiveUsers());

                return new BaseRepsonse<List<UserDTO>>()
                {
                    Description = "Список активных пользователей успешно получен",
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<List<UserDTO>>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<UsersPageDTO>> GetActiveUsersOnSelectedPage(int selected_page)
        {
            try
            {
                var page_count = (int)Math.Ceiling((double)await _userRepository.GetActiveUsersCount() / page_size);
                if (selected_page <= 1 || selected_page > page_count) return new BaseRepsonse<UsersPageDTO>(Description: $"Некорректное значение страницы. Оно должно быть в пределах от 1 до {page_count}", StatusCode: StatusCode.UnprocessableContent);

                var users = _mapper.Map<List<UserDTO>>(await _userRepository.GetActiveUsersOnSelectedPage(selected_page, page_size));

                return new BaseRepsonse<UsersPageDTO>()
                {
                    Description = $"Страница {selected_page} с активными пользователями получена",
                    Data = new UsersPageDTO()
                    {
                        Users = users,
                        SelectedPage = selected_page,
                        PageCount = page_count
                    },
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<UsersPageDTO>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<UserDTO>> GetUserByLogin(string Login)
        {
            try
            {
                var user = await _userRepository.GetUserByLogin(Login);
                if (user == null) return new BaseRepsonse<UserDTO>(Description: "Пользователя с таким логином не существует", StatusCode: StatusCode.NotFound);

                return new BaseRepsonse<UserDTO>()
                {
                    Description = "Данные о пользователе успешно получены",
                    Data = _mapper.Map<UserDTO>(user),
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<UserDTO>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<UserDTO>> GetUserById(Guid Id)
        {
            try
            {
                var user = await _userRepository.GetUserById(Id);
                if (user == null) return new BaseRepsonse<UserDTO>(Description: "Пользователя с таким Id не существует", StatusCode: StatusCode.NotFound);

                return new BaseRepsonse<UserDTO>()
                {
                    Description = "Данные о пользователе успешно получены",
                    Data = _mapper.Map<UserDTO>(user),
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<UserDTO>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<bool>> IsUserExistsByLoginAndPassword(string Login, string Password)
        {
            try
            {
                var user = await _userRepository.GetUserByLoginAndPassword(Login, HashPasswordHelper.GetHashPassword(Password));
                if (user == null) return new BaseRepsonse<bool>(Description: "Неправильный логин или пароль", StatusCode: StatusCode.NotFound);

                return new BaseRepsonse<bool>()
                {
                    Description = "Пользователь существует",
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<bool>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<bool>> DeleteUserByLogin(string Login)
        {
            try
            {
                var user = await _userRepository.GetUserByLogin(Login);
                if (user == null) return new BaseRepsonse<bool>(Description: "Пользователь с заданным логином не существует", StatusCode: StatusCode.BadRequest);

                user.User_state_id = await _user_stateRepository.GetUser_stateIdByCode(state_code.Blocked);
                await _userRepository.Update(user);

                return new BaseRepsonse<bool>()
                {
                    Description = "Пользователь успешно удален (заблокирован)",
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<bool>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }

        public async Task<BaseRepsonse<bool>> DeleteUserById(Guid Id)
        {
            try
            {
                var user = await _userRepository.GetUserById(Id);
                if (user == null) return new BaseRepsonse<bool>(Description: "Пользователь с заданным Id не существует", StatusCode: StatusCode.BadRequest);

                user.User_state_id = await _user_stateRepository.GetUser_stateIdByCode(state_code.Blocked);
                await _userRepository.Update(user);

                return new BaseRepsonse<bool>()
                {
                    Description = "Пользователь успешно удален (заблокирован)",
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseRepsonse<bool>(Description: ex.Message, StatusCode: StatusCode.InternalServerError);
            }
        }
    }
}
