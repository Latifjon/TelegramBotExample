using System;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type CommandType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsInternal { get; set; }
    }
}
