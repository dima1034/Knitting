
1. Commands -> hangfire -> raised as events -> handles in handler

1. Commands / Handlers contracts -> NotificationService.Domain

1. INotificationPipe
- command: ICommand
- event: 
- handler: IHandler

event* you can later to subscribe on this event

Event Source supposed to raise an event after calling a command
In our case command should produce events.

Handlers should always handle Command or Event?
If it is not, raise an error

```
-----    -----
|   | => |   |
|   |    |   |
-----    -----
```


---



Command -> Saved in hangfire -> (Raised)

CommandHandler -> Produce Event from DOMAIN -OR/AND- make other logic

Each Service Subscribe on a list of events from DOMAIN


---
Mediator 

Command - CommandHandler

Event (Domain or integration). probably domain

Hangfire use mediator to run an event