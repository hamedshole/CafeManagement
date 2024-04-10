namespace Shared.RestClient.Interfaces
{
    public interface INotification
    {
        void NotifyCreate();
        void NotifyUpdate();
        void NotifyDelete();
        void Error(string message); 
        void NoResult();
    }
}
