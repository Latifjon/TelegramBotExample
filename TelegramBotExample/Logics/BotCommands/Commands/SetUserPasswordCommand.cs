using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;
using TelegramBotExample.Logics.RestApiCient.Models;

namespace TelegramBotExample.Logics.BotCommands.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class SetUserPasswordCommand : BaseCommand
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

            user.UserInfo.Password = message.Text;
            UserRepository.UpdateUser(user);
            var authenticate = AuthenticationClient.Auhenticate(user.UserInfo);

            if (authenticate.Result.Username == null)
            {
                BotClient.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                BotClient.SendTextMessageAsync(message.Chat.Id, "User or Password incorrect! \n Enter Username");
                user.Command = nameof(SetUserNameCommand);
                UserRepository.UpdateUser(user);
                return;
            }

            BotClient.DeleteMessageAsync(message.Chat.Id, message.MessageId);
            BotClient.SendTextMessageAsync(message.Chat.Id, "Congritulations to have passed the authentication!");

            ShowMenu(message, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private void ShowMenu(Message message, UserTable user)
        {
            var keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                    new[] // row 1
                    {
                        new KeyboardButton("Users"),
                        new KeyboardButton("Audit")
                    },
                },
                ResizeKeyboard = true
            };
            BotClient.SendTextMessageAsync(message.Chat.Id, "Choise Menu", replyMarkup:keyboard);
            
        }
    }
}
