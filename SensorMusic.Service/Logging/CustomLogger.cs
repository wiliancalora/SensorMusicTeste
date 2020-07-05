﻿using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace SensorMusic.Services.Logging
{
    public class CustomLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;
        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            this.loggerName = name;
            loggerConfig = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            string mensagem = string.Format("{0}: {1} - {2}", logLevel.ToString(),
                eventId.Id, formatter(state, exception));
            EscreverTextoNoArquivo(mensagem);
        }
        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivoLog = Environment.CurrentDirectory + "/_Log.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
        }
    }
}
