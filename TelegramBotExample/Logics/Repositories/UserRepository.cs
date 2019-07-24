using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using TelegramBotExample.Database.Tables;

namespace TelegramBotExample.Logics.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository: BaseRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public IMongoCollection<UserTable> UserCollection { get; }

        /// <summary>
        /// 
        /// </summary>
        public UserRepository()
        {
            UserCollection = Database.GetCollection<UserTable>("Users");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserTable> GetUsers()
        {
            return UserCollection.AsQueryable<UserTable>().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public UserTable FindUser(long chatId)
        {
            return UserCollection.Find(f => f.ChatId == chatId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserTable user)
        {
            var filter = Builders<UserTable>.Filter.Eq(s => s.Id, user.Id);
            UserCollection.ReplaceOne(filter, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void InsertUser(UserTable user)
        {
            UserCollection.InsertOne(user);
        }
    }
}
