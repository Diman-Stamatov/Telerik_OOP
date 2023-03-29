using CosmeticsShop.Commands;
using CosmeticsShop.ApplicationErrors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticsShop.Core
{
    public class Engine
    {
        private const string TERMINATION_COMMAND = "exit";

        private readonly CommandFactory commandFactory;
        private readonly CosmeticsRepository productRepository;
        private List<string> exceptionLog;

        public Engine()
        {
            this.commandFactory = new CommandFactory();
            this.productRepository = new CosmeticsRepository();
            exceptionLog= new List<string>();
        }

        public void Start()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine.ToLower() == TERMINATION_COMMAND)
                {
                    break;
                }

                try
                {
                    this.ProcessCommand(commandLine);
                }
                catch (ArgumentsCountException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionLog.Add(DateTime.Now + "| [" + ex.Message + "]");
                }
                catch (NumberValueException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionLog.Add(DateTime.Now + "| [" + ex.Message + "]");
                }
                catch (ParameterLengthException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionLog.Add(DateTime.Now + "| [" + ex.Message + "]");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionLog.Add(DateTime.Now + "| [" + ex.Message + "]");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionLog.Add(DateTime.Now + "| [" + ex.Message + "]");
                }
            }
            
        }

        private void ProcessCommand(string commandLine)
        {
            string commandName = this.ParseCommand(commandLine);
            List<string> parameters = this.ParseParameters(commandLine);
            ICommand command = this.commandFactory.CreateCommand(commandName, this.productRepository);
            string result = command.Execute(parameters);
            Console.WriteLine(result);
        }

        private string ParseCommand(string commandLine)
        {
            string commandName = commandLine.Split(" ")[0];
            return commandName;
        }

        private List<string> ParseParameters(string commandLine)
        {
            string[] commandParts = commandLine.Split(" ");
            List<string> parameters = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                parameters.Add(commandParts[i]);
            }
            return parameters;
        }
        public void ShowErrorLog()
        {
            var fullLog = new StringBuilder();
            foreach (var log in exceptionLog)
            {
                fullLog.AppendLine(log);
            }
            Console.WriteLine(fullLog.ToString().Trim());
        }
    }
}
