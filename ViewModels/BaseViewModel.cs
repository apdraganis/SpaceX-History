﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace SpaceXHistory.ViewModels
{
    public partial class BaseViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value))
        //        return false;

        //    field = value;
        //    OnPropertyChanged(propertyName);

        //    return true;
        //}
    }
}
