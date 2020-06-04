using Autofac;
using SharedKernel;
using SharedKernel.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IComponentContext _container;

        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }

        public async Task Dispatch(BaseDomainEvent domainEvent)
        {
            var wrappedHandlers = GetWrappedHandlers(domainEvent);

            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                await handler.Handle(domainEvent).ConfigureAwait(false);
            }
        }

        public IEnumerable<DomainEventHandler> GetWrappedHandlers(BaseDomainEvent domainEvent)
        {
            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            IEnumerable handlers = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));
            IEnumerable<DomainEventHandler> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (DomainEventHandler)Activator.CreateInstance(wrapperType, handler));

            return wrappedHandlers;
        }

        public abstract class DomainEventHandler
        {
            public abstract Task Handle(BaseDomainEvent domainEvent);
        }

        public class DomainEventHandler<T> : DomainEventHandler
            where T : BaseDomainEvent
        {
            private readonly IHandle<T> _handler;

            public DomainEventHandler(IHandle<T> handler)
            {
                _handler = handler;
            }

            public override Task Handle(BaseDomainEvent domainEvent)
            {
                return _handler.Handle((T)domainEvent);
            }
        }
    }
}
