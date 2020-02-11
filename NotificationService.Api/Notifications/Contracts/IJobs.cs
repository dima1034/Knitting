namespace NotificationService.Api.Notifications.Contracts
{
    public interface IJobs<in TIn, out TOut>
    {
        TOut Run(TIn param);
    }
}