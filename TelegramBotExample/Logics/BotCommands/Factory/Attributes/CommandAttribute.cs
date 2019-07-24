using System;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsInternal { get; set; }
    }
}
