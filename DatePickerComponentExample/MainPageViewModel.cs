using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DatePickerComponentExample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        
        private Boolean _isCancelVisible;
        public Boolean IsCancelVisible
        {
            get => _isCancelVisible;
            set
            {
                _isCancelVisible = value;
                NotifyPropertyChanged();
            }
        }
        

        private string _mentionedDate;
        public string MentionedDate
        {
            get => _mentionedDate;
            set
            {
                if (_mentionedDate != value)
                {
                    _mentionedDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _timeTextColor;
        public string TimeTextColor
        {
            get => _timeTextColor;
            set
            {
                if (_timeTextColor != value)
                {
                    _timeTextColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand CancelCommand { get; private set; }
        public ICommand CalenderCommand { get; private set; }

        public MainPageViewModel()
        {
            TimeTextColor = "Gray";
            MentionedDate = "Select Date";
            SelectedDate = DateTime.Now;
            IsCancelVisible = false;

            CancelCommand = new Command(CancelClicked);
            CalenderCommand = new Command(CalenderClicked);
        }

        private void CancelClicked()
        {
            TimeTextColor = "Gray";
            MentionedDate = "Select Date";
            SelectedDate = DateTime.Now;
            IsCancelVisible = false;
        }

        async private void CalenderClicked()
        {
            DeviceDatePicker deviceDatePicker = new DeviceDatePicker();
            var data = await deviceDatePicker.GetSelectedDate(SelectedDate);

            if(data != null)
            {
                SelectedDate = (DateTime)data;
                TimeTextColor = "Black";
                MentionedDate = SelectedDate?.ToString("dd/MM/yyyy");
                IsCancelVisible = true;
            }
            else
            {
                CancelClicked();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
