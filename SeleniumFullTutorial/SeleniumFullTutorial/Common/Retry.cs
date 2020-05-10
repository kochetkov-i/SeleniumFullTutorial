using System;
using System.Collections.Generic;
using System.Threading;
using Action = System.Action;

namespace SeleniumFullTutorial.Common
{
    /// <summary>
    /// Пример использования
    /// </summary>
    //  Retry.Do(() =>
    //              {
    //                  some code
    //              },
    //              TimeSpan.FromSeconds(0));

    public static class Retry
    {
        /// <summary>
		/// Стандартные задержки при повторах
		/// </summary>
		private static readonly int[] Delays = { 1, 2, 3, 5, 8, 13, 21, 34, 55 };

        public static void Do(Action action, TimeSpan retryDelay, int retryCount = 3)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Do<object>(
                () =>
                {
                    action();
                    return null;
                },
                retryDelay,
                retryCount
            );
        }

        public static T Do<T>(Func<T> action, TimeSpan retryDelay, int retryCount = 3)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            List<Exception> exceptions = null;

            while(true)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    if (exceptions == null)
                        exceptions = new List<Exception>();

                    exceptions.Add(ex);

                    var delay = GetNextDelay(exceptions.Count, retryCount, retryDelay);
                    if (delay == null)
                        break;

                    Thread.Sleep(delay.Value);
                }
            }

            var lastException = exceptions[exceptions.Count - 1];
            throw new AggregateException($"Unable to complete action in {retryCount} attempts. Last exception message: '{lastException.Message}'", exceptions);
        }

        /// <summary>
		/// Получить задержку перед следующей попыткой.
		/// Если возвращается null - значит повторы больше производить не требуется.
		/// </summary>
		private static TimeSpan? GetNextDelay(int numberOfErrors, int retryCount, TimeSpan retryDelay)
        {
            if (numberOfErrors > retryCount)
                return null;

            var factor = Delays[Math.Min(numberOfErrors, Delays.Length) - 1];
            return TimeSpan.FromMilliseconds(factor * retryDelay.TotalMilliseconds);
        }
    }
}