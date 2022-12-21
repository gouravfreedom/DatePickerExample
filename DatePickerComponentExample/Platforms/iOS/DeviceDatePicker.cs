using System;
using UIKit;
using System.Threading.Tasks;
using DT.iOS.DatePickerDialog;

namespace DatePickerComponentExample
{
	public partial class DeviceDatePicker
	{
        public partial Task<DateTime?> GetSelectedDate(DateTime? defaultDate = null)
        {
            var tcs = new TaskCompletionSource<DateTime?>();

            var finalDate = (defaultDate ??= DateTime.Now);

            var dialog = new DatePickerDialog(useLocalizedButtons: true);
            dialog.Show(
                null,
                UIDatePickerMode.Date,
                (date) => tcs.TrySetResult(date),
                finalDate,
                null,
                null,
                () => tcs.TrySetResult(null),
                null);

            return tcs.Task;
        }
    }
}