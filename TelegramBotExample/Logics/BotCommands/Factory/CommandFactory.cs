using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TelegramBotExample.Logics.BotCommands.Factory
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<CommandInfo> _commandInfos;

        /// <summary>
        /// 
        /// </summary>
        static CommandFactory()
        {
            Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            _commandInfos = new List<CommandInfo>();
            var types = Assembly.GetCallingAssembly().GetTypes();

            var commandTypes = types.Where(w => typeof(ICommand).IsAssignableFrom(w)).ToList();
            commandTypes.ForEach(InternalInitialize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        private static void InternalInitialize(Type commandType)
        {
            var attr = commandType.GetCustomAttribute<CommandAttribute>();
            if (attr == null)
                return;

            var info = new CommandInfo();
            info.CommandType = commandType;
            info.CommandName = commandType.Name;
            info.IsInternal = attr.IsInternal;
            _commandInfos.Add(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static ICallBackCommand GetCallBackCommand(string commandName)
        {
           return GetCommand(commandName) as ICallBackCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static ICommand GetCommand(string commandName)
        {
            var commandInfo = _commandInfos.FirstOrDefault(i => i.CommandName == commandName);
            if (commandInfo == null)
                return null;

            return (ICommand)Activator.CreateInstance(commandInfo.CommandType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public static ICommand GetPublicCommand(string commandName)
        {
            var commandInfo = _commandInfos.FirstOrDefault(i => !i.IsInternal && i.CommandName == commandName);
            if (commandInfo == null)
                return null;

            return (ICommand)Activator.CreateInstance(commandInfo.CommandType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CommandInfo> GetCommandInfos()
        {
            return _commandInfos.ToList();
        }
    }
}
