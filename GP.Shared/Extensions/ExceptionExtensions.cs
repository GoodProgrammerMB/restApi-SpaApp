using System;

namespace GP.Shared.Extensions
{
    public static class ExceptionExtensions
    {
        private const string ExceptionPrefix = "-----------------EXCEPTION-----------------";

        public static string ToLogString(this Exception exception, bool addPrefix = true)
        {
            var text = addPrefix ? ExceptionPrefix : string.Empty;

            int deepCount = 1;

            var deepException = exception;

            while (deepException.InnerException != null)
            {
                text += $"{Environment.NewLine}{deepCount}) {deepException.Source} - {deepException.Message}";
                deepException = deepException.InnerException;
                deepCount++;
            }

            text += $"{Environment.NewLine}{deepCount}) {deepException.Source} - {deepException.Message}";

            text += $"{Environment.NewLine} StackTrace: {deepException.StackTrace}";

            return text;
        }
    }
}
