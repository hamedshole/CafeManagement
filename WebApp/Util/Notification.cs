using MudBlazor;
using Shared.RestClient.Interfaces;

namespace WebApp.Util
{
    internal class Notification(ISnackbar snackbar) : INotification
    {
        private readonly ISnackbar _snackbar = snackbar;

        public void Error(string message)
        {
            _snackbar.Add(message, Severity.Error);
        }

        public void NoResult()
        {
            _snackbar.Add("داده ای یافت نشد", Severity.Warning);
        }

        public void NotifyCreate()
        {
            _snackbar.Add("ثبت با موفقیت انجام شد", Severity.Success);
        }

        public void NotifyDelete()
        {
            _snackbar.Add ("حذف با موفقیت انجام شد", Severity.Success);
        }

        public void NotifyUpdate()
        {
            _snackbar.Add("به روزرسانی با موفقیت انجام شد", Severity.Success);
        }
    }
}
