﻿using System.Collections.Generic;
using System.Reflection;
using MugenMvvmToolkit.iOS.Infrastructure;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using SplitView.Portable;
using UIKit;

namespace SplitView.iOS
{
    public class SplitViewBootstrapper : Bootstrapper<App>
    {
        #region Constructors

        public SplitViewBootstrapper(UIWindow window, IIocContainer iocContainer,
            IEnumerable<Assembly> assemblies = null, IViewModelSettings viewModelSettings = null,
            PlatformInfo platform = null) : base(window, iocContainer, assemblies, viewModelSettings, platform)
        {
            WrapToNavigationController = UIDevice.CurrentDevice.UserInterfaceIdiom != UIUserInterfaceIdiom.Pad;
        }

        #endregion

        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new App(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad);
        }

        #endregion
    }
}