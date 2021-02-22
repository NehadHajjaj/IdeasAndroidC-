using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.ViewModel
{
   

    
        public class BaseViewModel : INotifyPropertyChanged
        {
            private bool _showStatusMessage = false;
            public bool ShowStatusMessage
            {
                get => _showStatusMessage;
                set
                {
                    _showStatusMessage = value;
                    OnPropertyChanged("ShowStatusMessage");
                }
            }

            private string _statusMessage = string.Empty;
            public string StatusMessage
            {
                get => _statusMessage;
                set
                {
                    _statusMessage = value;
                    OnPropertyChanged("StatusMessage");
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            protected void OnPropChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            protected void SetValue<T>(ref T backingField,
                                       T value,
                                       [CallerMemberName] string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(backingField, value))
                {
                    return;
                }

                backingField = value;
                OnPropChanged(propertyName);
            }


        }

    }


