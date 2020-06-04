using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
