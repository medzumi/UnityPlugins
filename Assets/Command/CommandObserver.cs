// MIT LICENSE
// https://github.com/medzumi/UnityPlugins/blob/master/LICENSE

using System.Collections.Generic;

public class CommandObserver
{
    private class CommandProxy : ICommand
    {
        private class EmptyCommand : ICommand
        {
            void ICommand.Execute()
            {
                //Пустышка
            }
        }

        private ICommand commandCache;

        //TODO: может использовать лист?
        public ICommand Command
        {
            set
            {
                if(!(value is CommandProxy))
                {
                    if(value != null)
                    {
                        commandCache = value;
                    }
                    else
                    {
                        throw new System.NullReferenceException("Комадна равна Null");
                    }
                }
                else
                {
                    throw new System.Exception("Возможно зацикливание. Заместитель не должен замещать заместителя"); 
                }
            }
        }

        public CommandProxy()
        {
            Command = new EmptyCommand();
        }

        public CommandProxy(ICommand command)
        {
            Command = command;
        }

        void ICommand.Execute()
        {
            commandCache.Execute();
        }
    }

    private static CommandObserver instanceCache;
    private static CommandObserver instance => instanceCache ?? (instanceCache = new CommandObserver());

    private readonly Dictionary<string, CommandProxy> commands = new Dictionary<string, CommandProxy>();

    /// <summary>
    /// Добавить команду в обсервер
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    public static void AddCommand(string id, ICommand command)
    {
        CommandProxy commandProxy;
        if(instance.commands.TryGetValue(id, out commandProxy))
        {
            commandProxy.Command = command;
        }
        else
        {
            instance.commands.Add(id, new CommandProxy(command));
        }
    }

    /// <summary>
    /// Получить команду по <paramref name="id"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ICommand GetCommand(string id)
    {
        CommandProxy commandProxy;
        if (!instance.commands.TryGetValue(id, out commandProxy))
        {
            commandProxy = new CommandProxy();
            instance.commands.Add(id, commandProxy);
        }
        return commandProxy;
    }
}
