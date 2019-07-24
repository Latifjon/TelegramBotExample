using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        void Execute(Message message, UserTable user);
    }
}
