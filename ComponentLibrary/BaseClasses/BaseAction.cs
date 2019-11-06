using NLog;
using System;

namespace ComponentLibrary.BaseClasses
{
    public class BaseAction
    {
        protected static readonly Logger _Logger = LogManager.GetCurrentClassLogger();
    }
}