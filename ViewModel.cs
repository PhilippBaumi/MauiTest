using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MauiTest
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private DateTime? selectedDate;
        private string? selectedText;
        public ObservableCollection<string> Dates { get; } = new();

        public DateTime? SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? SelectedText
        {
            get => selectedText;
            set
            {
                if (selectedText != value)
                {
                    selectedText = value;
                    OnPropertyChanged();
                }
            }

        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
