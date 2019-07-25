using Refit;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.Repositories;
using TelegramBotExample.Logics.RestApiCient;

namespace TelegramBotExample.Logics.BotCommands.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotClient BotClient => Program.BotClient;

        /// <summary>
        /// 
        /// </summary>
        public IAuthentication AuthenticationClient = RestService.For<IAuthentication>("https://localhost:44343");

        /// <summary>
        /// 
        /// </summary>
        public UserRepository UserRepository = new UserRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        public abstract void Execute(Message message, UserTable user);
    }
}
