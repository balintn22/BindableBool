/*
Copyright (c) 2023, Balint Nagy
All rights reserved.
*/

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YA
{
    public class BindableBool : INotifyPropertyChanged
    {
        private bool _flag;

        public bool Value
        {
            get => _flag;
            set
            {
                if (_flag == value)
                    return;

                _flag = value;
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(IsTrue));
                OnPropertyChanged(nameof(IsFalse));
            }
        }

        public bool IsTrue { get => _flag; }
        public bool IsFalse { get => !_flag; }

        public BindableBool(bool b)
        {
            _flag = b;
        }

        public static implicit operator bool(BindableBool bb) => bb._flag;
        public static implicit operator BindableBool(bool b) => new BindableBool(b);


        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
