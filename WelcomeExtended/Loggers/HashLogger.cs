﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WelcomeExtended.Loggers
{
    public class HashLogger:ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,Func<TState, Exception, string> formatter)
        {
            var message = formatter(state , exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red; break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow; break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; break;
            }
            Console.WriteLine("-LOGGER-");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat("[{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("-LOGGER-");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;

        }
    }
}