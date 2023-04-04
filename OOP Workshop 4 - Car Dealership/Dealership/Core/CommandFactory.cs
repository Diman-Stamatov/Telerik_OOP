using Dealership.Commands;
using Dealership.Commands.Contracts;
using Dealership.Commands.Enums;
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using static Dealership.UtilityMethods;


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dealership.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;
        
        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            
            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = this.ExtractCommandParameters(commandLine);
            ICommand command = null;
            switch (commandType)
            {
                case CommandType.RegisterUser:
                    command = new RegisterUserCommand(commandParameters, repository);
                    break;
                case CommandType.Login:
                    command = new LoginCommand(commandParameters, repository);
                    break;
                case CommandType.Logout:
                    command = new LogoutCommand(repository);
                    break;
                case CommandType.AddVehicle:
                    command = new AddVehicleCommand(commandParameters, repository);
                    break;
                case CommandType.RemoveVehicle:
                    command = new RemoveVehicleCommand(commandParameters, repository);
                    break;
                case CommandType.AddComment:
                    command = new AddCommentCommand(commandParameters, repository);
                    break;
                case CommandType.RemoveComment:
                    command = new RemoveCommentCommand(commandParameters, repository);
                    break;
                case CommandType.ShowUsers:
                    command = new ShowUsersCommand(repository);
                    break;
                case CommandType.ShowVehicles:
                    command = new ShowVehiclesCommand(commandParameters, repository);
                    break;
                
            }
            return command;
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            if (Enum.TryParse(commandName, true, out CommandType result))
            {
                return result;
            }
            string commandTypes = GetCommandTypeNames();
            throw new InvalidUserInputException($"Invalid command. Please use one of the following: {commandTypes}.");
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
