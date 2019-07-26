using MongoDB.Bson;
using TelegramBotExample.Logics.RestApiCient.Models;

namespace TelegramBotExample.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class UserTable
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CallBackCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LoginInfo UserInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; }
    }
}
