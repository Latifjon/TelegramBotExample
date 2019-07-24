using MongoDB.Bson;

namespace TelegramBotExample.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandTable
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UzName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RuName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EnName { get; set; }
    }
}
