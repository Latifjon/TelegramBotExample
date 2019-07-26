using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;
using TelegramBotExample.Logics.RestApiCient.Models;

namespace TelegramBotExample.Logics.RestApiCient
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Post("/Authentication/Authenticate")]
        Task<AuthenticateResult> Auhenticate([Body] LoginInfo user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Get("/Authentication/CheckUserNameIsExist")]
        Task<bool> CheckUserNameIsExist([Body] LoginInfo user);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Get("/Authentication/GetUsers")]
        [Headers("Authorization: Bearer")]
        Task<List<UserInfo>> GetUsers();
    }
}
