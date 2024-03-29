﻿using SLS.MVVM.Model.Interfaces;
using System;

namespace SLS.MVVM.Model
{
    internal class LoggModel : IEntity
    {
        public int Id { get; set; }

        public string ObjectSenderName { get; } = "Unknown";

        public string Action { get; }

        public string Message { get; }

        public DateTime Date { get; }
        
        public LoggModel(string action, string messsage) 
        {
            Action = action;
            Message = messsage;
            Date = DateTime.Now;
        }

        public LoggModel(string senderName, string action, string message) : this(action, message)
        {
            ObjectSenderName = senderName;
        }
    }
}
