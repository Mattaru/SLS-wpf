using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SLS.Core
{
    internal abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChnged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public virtual void Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) throw new ArgumentNullException(nameof(field));
            OnPropertyChnged(propertyName);
            field = value;
        }
    }
}
