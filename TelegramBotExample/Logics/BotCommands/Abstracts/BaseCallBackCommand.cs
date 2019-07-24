using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCallBackCommand : BaseCommand, ICallBackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callbackQuery"></param>
        /// <param name="user"></param>
        public abstract void CallBackExecute(CallbackQuery callbackQuery, UserTable user);
    }
}
