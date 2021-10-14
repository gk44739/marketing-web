using marketing_web.Interfaces;
using marketing_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private HttpContext _httpContext { get { return _contextAccessor.HttpContext; } }
        private AspNetUsers CurrentUser { get; set; }

        public UserService(IUserRepository userRepository,
                        IHttpContextAccessor contextAccessor,
                        UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;

            if (_httpContext.User.Identity.IsAuthenticated)
            {
                var id = userManager.GetUserId(_httpContext.User);
                CurrentUser = userRepository.Find(u => u.Id == id).FirstOrDefault();
            }
        }
        public async Task<IEnumerable<AspNetUsers>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();

            // logjika shkruhet ketu dhe rregullohet modeli ne formen qe deshirojme te kthejme ne controller
            return users;

        }


        public string GetUserId()
        {
            try
            {


                if (CurrentUser != null)
                {
                    return CurrentUser.Id;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserName()
        {
            try
            {

                if (CurrentUser != null)
                {
                    return CurrentUser.UserName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserEmail()
        {
            try
            {

                if (CurrentUser != null)
                {
                    return CurrentUser.Email;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserPhoneNumber()
        {
            try
            {
                return CurrentUser.PhoneNumber;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string GetUsernameByUserId(string id)
        {
            try
            {
                return _userRepository.GetByStringId(id).UserName;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetUserFullName(string id)
        {
            return _userRepository.GetUser(id).Email;
        }
    }
}
