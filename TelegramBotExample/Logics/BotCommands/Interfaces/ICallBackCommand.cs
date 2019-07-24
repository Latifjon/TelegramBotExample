using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICallBackCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callbackQuery"></param>
        /// <param name="user"></param>
        void CallBackExecute(CallbackQuery callbackQuery, UserTable user);
    }
}
