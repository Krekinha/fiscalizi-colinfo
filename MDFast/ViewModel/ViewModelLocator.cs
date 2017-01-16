﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MDFast.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using FiscaliZi.MDFast.Model;
using FluentValidation;
using FiscaliZi.MDFast.Validation;

namespace FiscaliZi.MDFast.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EntradaViewModel>();
            SimpleIoc.Default.Register<VeiculosViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EntradaViewModel EntradaVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EntradaViewModel>();
            }
        }

        public VeiculosViewModel VeiculosVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VeiculosViewModel>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}