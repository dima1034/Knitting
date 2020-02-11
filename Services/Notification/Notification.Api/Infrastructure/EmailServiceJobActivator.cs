using System;
using Hangfire;
using MediatR;
using NotificationService.Email;

namespace Notification.Api.Infrastructure
{
    public class EmailServiceJobActivator : JobActivator
    {
        // private readonly EmailSenderService _emailSenderService;
        // public EmailServiceJobActivator(EmailSenderService service)
        // {
        //     _emailSenderService = service;
        // }
        //
        // public override object ActivateJob(Type type)
        // {
        //     return _emailSenderService;
        // }
    }
}