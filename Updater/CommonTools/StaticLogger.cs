using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Logging;
using System.Runtime.CompilerServices;

namespace CommonTools
{
    public static class StaticLogger
    {
        #region Properties

        private static ILoggerFacade logger;
        public static ILoggerFacade Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        #endregion

        #region Methods

        public static void LogException(Exception e)
        {
            if (logger != null && e != null)
            {
                logger.Log(e.Message, Category.Exception, Priority.Medium);
                logger.Log(e.StackTrace, Category.Exception, Priority.Medium);

                if (e.InnerException != null)
                {
                    logger.Log(e.InnerException.Message, Category.Exception, Priority.Medium);
                    logger.Log(e.InnerException.StackTrace, Category.Exception, Priority.Medium);
                }
            }
        }

        public static void LogInfo(string message)
        {
            if (logger != null)
                logger.Log(message, Category.Info, Priority.Medium);
        }

        public static void LogError(string message, [CallerMemberName] string functionName = null)
        {
            if (logger != null)
                logger.Log(functionName + ": " + message, Category.Exception, Priority.Medium);
        }

        #endregion
    }
}
