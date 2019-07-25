using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;

namespace TelegramBotExample.Logics.BotCommands.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class RegisterPhoneCommand : BaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public override void Execute(Message message, UserTable user)
        {
            if (user == null)
                return;

            if (message.Contact == null)
            {
                BotClient.SendTextMessageAsync(message.Chat.Id, "Please share contact!");
                return;
            }

            user.PhoneNumber = message.Contact.PhoneNumber;
            user.Command = null;
            UserRepository.UpdateUser(user);
            BotClient.SendTextMessageAsync(message.Chat.Id, "Conguratulation you succed registered!");

            AskUserName(message, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private void AskUserName(Message message, UserTable user)
        {
            user.PhoneNumber = message.Contact.PhoneNumber;
            user.UserName = message.Chat.Username;
            user.Command = nameof(SetUserNameCommand);
            UserRepository.UpdateUser(user);

            BotClient.SendTextMessageAsync(message.Chat.Id, "Enter UserName", ParseMode.Markdown);
        }
    }
}
