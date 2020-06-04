using Core.Entities;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events
{
    public class UserCompletedEvent: BaseDomainEvent
    {
        public User CompletedUser { get; set; }

        public UserCompletedEvent(User completedItem)
        {
            CompletedUser = completedItem;
        }
    }
}
