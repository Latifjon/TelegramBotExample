using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;

namespace TelegramBotExample.Logics.BotCommands.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class MenuCommand : BaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public override void Execute(Message message, UserTable user)
        {
            if (user?.Token == null)
                return;

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
