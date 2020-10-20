using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Xaml;

namespace LiteCRM.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged//, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        }

        protected virtual bool Set<T>(T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        protected virtual bool SetRef<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }


        //public object ProvideValue(IServiceProvider sp)
        //{
        //    var value_target_service = sp.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        //    var root_object_service = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

        //    OnInitializad(value_target_service?.TargetObject, value_target_service?.TargetProperty, root_object_service?.RootObject);

        //    return this;
        //}

        //private WeakReference _TargetRef;
        //private WeakReference _RootRef;

        //public object TargetObject => _TargetRef.Target;
        //public object RootQbject => _RootRef.Target;

        //protected virtual void OnInitializad(object Target, object Property, object Root)
        //{
        //    _TargetRef = new WeakReference(Target);
        //    _RootRef = new WeakReference(Root);
        //}


        //public void Dispose()
        //{
        //    Dispose(true);
        //}

        //private bool _Disposed;
        //protected virtual void Dispose(bool Disposing)
        //{
        //    if (!Disposing || _Disposed) return;
        //}
    }
}
