namespace NotificationService.DeprecatedApi.Notifications.Contracts
{
    public interface IJobs<in TIn, out TOut>
    {
        TOut Run(TIn param);
    }
}