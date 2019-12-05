using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Core.Configurations
{
    public interface IIocConfiguration
    {
        void RegisterServices();
        void RegisterViewModels();
    }
}
