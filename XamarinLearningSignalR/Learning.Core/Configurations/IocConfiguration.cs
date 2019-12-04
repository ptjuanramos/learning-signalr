﻿using GalaSoft.MvvmLight.Ioc;
using Learning.Core.Services;
using Learning.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Core.Configurations
{
    public class IocConfiguration : IIocConfiguration
    {

        public void RegisterServices()
        {
            SimpleIoc.Default.Register<IChatMessageService, ChatMessageService>();
            SimpleIoc.Default.Register<IDrawMessageService, DrawMessageService>();
        }

        public void RegisterViewModels()
        {

        }
    }
}
