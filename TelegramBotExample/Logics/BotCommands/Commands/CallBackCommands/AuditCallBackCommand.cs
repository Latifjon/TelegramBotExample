using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;

namespace TelegramBotExample.Logics.BotCommands.Commands.CallBackCommands
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditCallBackCommand : BaseCallBackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callbackQuery"></param>
        /// <param name="user"></param>
        public override void CallBackExecute(CallbackQuery callbackQuery, UserTable user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public override void Execute(Message message, UserTable user)
        {
            throw new NotImplementedException();
        }
    }
}
