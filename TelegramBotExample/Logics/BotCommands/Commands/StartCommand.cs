using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.BotCommands.Abstracts;
using TelegramBotExample.Logics.BotCommands.Commands;

namespace TelegramBotExample.Logics.BotCommands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class StartCommand : BaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public override void Execute(Message message, UserTable user)
        {
            if (user != null)
                return;

            user = new UserTable();
            user.ChatId = message.Chat.Id;
            user.UserName = message.Chat.Username;
            user.Command = nameof(RegisterPhoneCommand);
            UserRepository.InsertUser(user);

            AskPhoneNumber(message);
        }

        /// <summary>
        /// 
        /// </summary>
        private void AskPhoneNumber(Message message)
        {
            var shareContact = new KeyboardButton("Share your contact");
            shareContact.RequestContact = true;

            var keyboard = new ReplyKeyboardMarkup(new[] { shareContact });
            keyboard.ResizeKeyboard = true;
            BotClient.SendTextMessageAsync(message.Chat.Id, "Send phone number please!", replyMarkup: keyboard);
        }
    }
}
