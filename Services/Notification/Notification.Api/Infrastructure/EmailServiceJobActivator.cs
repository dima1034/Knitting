using System;
using Hangfire;
using MediatR;

namespace Notification.Api.Infrastructure
{
    public class MediatorJobActivator : JobActivator
    {
        private readonly IMediator _mediator;

        public MediatorJobActivator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override object ActivateJob(Type type)
        {
            return _mediator;
        }
    }
}