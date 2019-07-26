using System.Threading.Tasks;
using Refit;
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
        public override async void Execute(Message message, UserTable user)
        {
            if (user == null)
                return;

            try
            {
                var result = await PassAuthentication(message, user);
                UpdateUserAndSendSuccess(message, user, result);
            }
            catch (ApiException exception)
            {
                await BotClient.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                await BotClient.SendTextMessageAsync(message.Chat.Id, $"{exception.Content}");
                await BotClient.SendTextMessageAsync(message.Chat.Id, "Enter Username");
                user.Command = nameof(SetUserNameCommand);
                UserRepository.UpdateUser(user);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private async Task<AuthenticateResult> PassAuthentication(Message message, UserTable user)
        {
            user.UserInfo.Password = message.Text;
            return await AuthenticationClient.Auhenticate(user.UserInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <param name="result"></param>
        private void UpdateUserAndSendSuccess(Message message, UserTable user, AuthenticateResult result)
        {
            user.Command = null;
            user.Token = result.Token;
            UserRepository.UpdateUser(user);

            BotClient.DeleteMessageAsync(message.Chat.Id, message.MessageId);
            BotClient.SendTextMessageAsync(message.Chat.Id, "Congritulations to have passed the authentication!");

            var menuCommand = new MenuCommand();
            menuCommand.Execute(message,user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        private void ShowMenu(Message message, UserTable user)
        {
            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton{ Text="Users", CallbackData = "UsersCallBackCommand"},
                    new InlineKeyboardButton{Text="Audit", CallbackData = "AuditCallBackCommand"},
                }
            });

            BotClient.SendTextMessageAsync(message.Chat.Id, "Choise Menu", replyMarkup: keyboard);

        }
    }
}
