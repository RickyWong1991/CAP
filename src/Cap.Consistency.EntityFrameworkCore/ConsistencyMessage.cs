﻿using System;

namespace Cap.Consistency.EntityFrameworkCore
{
    public class ConsistencyMessage : ConsistencyMessage<string>
    {
        public ConsistencyMessage() {
            Id = Guid.NewGuid().ToString();
            SendTime = DateTime.Now;
            UpdateTime = SendTime;
            Status = MessageStatus.WaitForSend;
        }
    }

    public enum MessageStatus
    {
        Deleted = 0,
        WaitForSend = 1,
        RollbackSuccessed = 3,
        RollbackFailed = 4
    }

    public class ConsistencyMessage<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }

        public virtual DateTime SendTime { get; set; }

        public string Payload { get; set; }

        public MessageStatus Status { get; set; }

        public virtual DateTime? UpdateTime { get; set; }
    }
}