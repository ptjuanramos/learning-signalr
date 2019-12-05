using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Learning.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IIocConfiguration iocConfiguration;

        public ViewModelLocator(IIocConfiguration iocConfiguration)
        {
            this.iocConfiguration = iocConfiguration;
            SetupViewModels();
        }

        private void SetupViewModels()
        {
            iocConfiguration.RegisterViewModels();
        }

        public T GetViewModel<T>() where T : ViewModelBase
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
    }
}
