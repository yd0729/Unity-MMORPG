using System;

namespace Common
{
    public static class Log
    {
        // TODO 颜色
        // TODO 时间
        // TODO 消息级别
        public static void Init(string name)
        {
            // log = LogManager.GetLogger(name);
        }
        public static void Info(object message)
        {
            Console.WriteLine(message);
        }

        public static void InfoFormat(string format,params object[] args)
        {
            Console.WriteLine(format, args);
        }
        public static void Warning(object message)
        {
            Console.WriteLine(message);
        }
        public static void WarningFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
        public static void Error(object message)
        {
            Console.WriteLine(message);
        }
        public static void ErrorFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
        public static void Fatal(object message)
        {
            Console.WriteLine(message);
        }
        public static void FatalFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
