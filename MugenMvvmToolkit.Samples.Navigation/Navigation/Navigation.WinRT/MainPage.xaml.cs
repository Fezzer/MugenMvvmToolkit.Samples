﻿// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Navigation.WinRT
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Navigation.App());
        }
    }
}