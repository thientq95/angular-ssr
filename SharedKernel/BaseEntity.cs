using System;
using System.Collections.Generic;

namespace SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
