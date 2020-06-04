using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}
