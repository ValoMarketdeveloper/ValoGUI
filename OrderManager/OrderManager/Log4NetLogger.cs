using log4net;
using Microsoft.Practices.Prism.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class Log4NetLogger : ILoggerFacade
    {

        private ILog m_Logger = null;

        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            m_Logger = LogManager.GetLogger(typeof(Log4NetLogger));
        }

        public void Log(string msg, Category category, Priority priority)
        {
            string assembly = Assembly.GetCallingAssembly().ManifestModule.Name;
            string assemblyName = assembly.Substring(0, assembly.IndexOf('.'));

            switch (category)
            {
                case Category.Debug:
                    if (m_Logger.IsDebugEnabled)
                        m_Logger.Debug(ModuleFunctionMsg(msg, assemblyName));
                    break;
                case Category.Warn:
                    if (m_Logger.IsWarnEnabled)
                        m_Logger.Warn(ModuleFunctionMsg(msg, assemblyName));
                    break;
                case Category.Info:
                    if (m_Logger.IsInfoEnabled)
                        m_Logger.Info(ModuleFunctionMsg(msg, assemblyName));
                    break;
                case Category.Exception:
                    m_Logger.Error(ModuleFunctionMsg(msg, assemblyName));
                    break;
            }
        }

        private StringBuilder ModuleFunctionMsg(string msg, string assemblyName)
        {
            StringBuilder rt = new StringBuilder(msg.Length + 50);
            rt.Append(assemblyName);
            rt.Append(".");
            rt.Append(new StackFrame(2, true).GetMethod().Name);
            rt.Append(" - ");
            rt.Append(msg);
            return rt;

        }
    }
}
