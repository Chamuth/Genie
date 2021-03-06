﻿using System;
using System.Text;

namespace Genie.Tools
{
    internal class GenieExceptionMessageFormatter : IMessageFormatter
    {
        /// <summary>
        /// Includes base message, exception message , exception stack trace
        /// </summary>
        /// <param name="exception">exception to include</param>
        /// <param name="baseMessage">base message or the title of the result</param>
        /// <returns>formatted string</returns>
        public string FormatException(Exception exception, string baseMessage)
        {
            const string messageTemplate =
                "$baseMessage$\n" +
                "\t$exceptionMessage$" +
                "\t\t$exceptionTrace$\n";

            return new StringBuilder(messageTemplate)
                .Replace("$baseMessage$", baseMessage ?? "")
                .Replace("$exceptionMessage$", exception.Message ?? "")
                .Replace("$exceptionTrace$", exception.Source.Replace(Environment.NewLine, "\t\t" + Environment.NewLine))
                .ToString();
        }
    }
}
