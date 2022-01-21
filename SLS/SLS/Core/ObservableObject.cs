using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SLS.Core
{
    internal abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChnged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

            /*var handlers = propertychanged;
            if (handlers != null) return;

            var invocation_list = handlers.getinvocationlist();

            var args = new propertychangedeventargs(propertyname);
            foreach(var action in invocation_list)
            {
                if (action.target is dispatcherobject disp_obj)
                    disp_obj.dispatcher.invoke(action, this, args);
                else
                    action.dynamicinvoke(this, args);
            }*/
        }

        public virtual void Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) throw new ArgumentNullException(nameof(field));
            OnPropertyChnged(propertyName);
            field = value;
        }
    }
}
