using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Core.Configurations
{
    public interface IIocConfiguration
    {
        void RegisterViewModels();
        void RegisterServices();
    }
}
