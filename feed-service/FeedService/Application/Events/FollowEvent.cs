﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events
{
    public enum FollowEventType
    {
        Follow,
        Unfollow
    }

    public class FollowEvent : QueueEvent
    {
        public FollowEventType EventType {  get; set; }
        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
