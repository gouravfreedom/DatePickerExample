using System;
using Android.App;
using Android.Views;
using System.Threading.Tasks;

namespace DatePickerComponentExample
{
	public partial class DeviceDatePicker
	{
        public partial Task<DateTime?> GetSelectedDate(DateTime? defaultDate = null)
        {
            var activity = Platform.CurrentActivity;
            defaultDate ??= DateTime.Now;

            var tcs = new TaskCompletionSource<DateTime?>();

            using var dialog = new DatePickerDialog(
                activity,
                (sender, e) => tcs.TrySetResult(e?.Date),
                defaultDate.Value.Year,
                defaultDate.Value.Month - 1,
                defaultDate.Value.Day);

            dialog.CancelEvent += (sender, e) => tcs.TrySetResult(null);
            dialog.KeyPress += DialogKeyPress;

            dialog.Show();
            return tcs.Task;
        }

        static void DialogKeyPress(object sender, global::Android.Content.DialogKeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Back && sender is Dialog dialog)
                dialog?.Cancel();
        }
    }
}

