﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class LogHelper
    {
        public static void WriteOperationLog(string identity, string content, LogLevel level = LogLevel.Info)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("OperationLog");
            log4net.ThreadContext.Properties["logId"] = Guid.NewGuid().ToString();
            log4net.ThreadContext.Properties["user"] = identity;
            switch (level)
            {
                case LogLevel.Debug:
                    logger.Debug(content);
                    break;
                case LogLevel.Warn:
                    logger.Warn(content);
                    break;
                case LogLevel.Error:
                    logger.Error(content);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(content);
                    break;
                case LogLevel.Info:
                default:
                    logger.Info(content);
                    break;
            }
        }

        public static void WriteSystemLog(string identity, string menuId, string content)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("SystemLog");
            log4net.ThreadContext.Properties["logId"] = Guid.NewGuid().ToString();
            log4net.ThreadContext.Properties["menuId"] = menuId;
            log4net.ThreadContext.Properties["identity"] = identity;
            logger.Info(content);
        }
    }
}
