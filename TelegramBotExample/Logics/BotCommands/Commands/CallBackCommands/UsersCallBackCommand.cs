using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Telegram.Bot.Types;
using TelegramBotExample.Database.Tables;
using TelegramBotExample.Logics.RestApiCient;
using TelegramBotExample.Logics.RestApiCient.Models;

namespace TelegramBotExample.Logics.BotCommands.Commands.CallBackCommands
{
    /// <summary>
    /// 
    /// </summary>
    [Command]
    public class UsersCallBackCommand : BaseCallBackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callbackQuery"></param>
        /// <param name="user"></param>
        public override async void CallBackExecute(CallbackQuery callbackQuery, UserTable user)
        {
            if(user==null)
                return;

            try
            {
                var res = await GetUsers(user.Token);
                foreach (var userInfo in res)
                {
                    await BotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Username: {userInfo.UserName} \n Phone: {userInfo.Phone}");
                }

            }
            catch (ApiException ex)
            {
                await BotClient.DeleteMessageAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
                await BotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"{ex.Content}  \n Message:{ex.Message}");
                return;
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private async Task<List<UserInfo>> GetUsers(string accessToken)
        {
            var api = RestService.For<IAuthentication>("http://localhost:52855", new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(accessToken)
            });

            return await api.GetUsers();
        }
    }
}
