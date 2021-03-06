﻿using MugenMvvmToolkit;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using Xamarin.Forms;

namespace Navigation
{
    public class App : Application
    {
        public App()
        {
            XamarinFormsBootstrapperBase bootstrapper = XamarinFormsBootstrapperBase.Current ??
                                                        new Bootstrapper<Portable.App>(new AutofacContainer());
            MainPage = bootstrapper.Start();
        }
    }
}