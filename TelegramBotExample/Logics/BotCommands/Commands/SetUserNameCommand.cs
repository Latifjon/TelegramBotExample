using Refit;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;
using TelegramBotExample.Logics.RestApiCient;
using TelegramBotExample.Logics.RestApiCient.Models;

namespace TelegramBotExample.Logics.BotCommands.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class SetUserNameCommand : BaseCommand
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
            
            user.UserInfo = new UserInfo
            {
                UserName = message.Text,
                Password = null
            };
            UserRepository.UpdateUser(user);
            var checkUserName = AuthenticationClient.CheckUserNameIsExist(user.UserInfo);
            if (checkUserName.Result == false)
            {
                BotClient.SendTextMessageAsync(message.Chat.Id,
                    $"{message.Text} username doesn't exist in Server. Please enter exist Username");
                return;
            }

            user.Command = null;
            UserRepository.UpdateUser(user);

            AskPassword(message, user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private void AskPassword(Message message, UserTable user)
        {
            user.ChatId = message.Chat.Id;
            user.UserInfo.UserName = message.Text;
            user.Command = nameof(SetUserPasswordCommand);
            UserRepository.UpdateUser(user);

            BotClient.SendTextMessageAsync(message.Chat.Id, "Enter Password", ParseMode.Markdown);
        }
    }
}
