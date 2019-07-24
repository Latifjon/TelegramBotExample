using MongoDB.Driver;

namespace TelegramBotExample.Logics.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Connect = "mongodb://localhost";

        /// <summary>
        /// 
        /// </summary>
        public IMongoDatabase Database = new MongoClient(Connect).GetDatabase("TelegramBotExampleDb");
    }
}
