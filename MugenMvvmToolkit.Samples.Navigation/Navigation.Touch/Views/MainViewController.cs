using UIKit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    public class MainViewController : MvvmTabBarController
    {
        #region Overrides of UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Main view";
            View.BackgroundColor = UIColor.White;

            NavigationItem.RightBarButtonItem = new UIBarButtonItem("Navigation", UIBarButtonItemStyle.Plain,
                (sender, args) =>
                {
                    var actionSheet = new UIActionSheet("Navigation");

                    actionSheet.AddButtonWithBinding("First view model modal", "Click ShowFirstWindowCommand");
                    actionSheet.AddButtonWithBinding("First view model page", "Click ShowFirstPageCommand");
                    actionSheet.AddButtonWithBinding("First view model tab", "Click ShowFirstTabCommand");

                    actionSheet.AddButtonWithBinding("Second view model modal", "Click ShowSecondWindowCommand");
                    actionSheet.AddButtonWithBinding("Second view model page", "Click ShowSecondPageCommand");
                    actionSheet.AddButtonWithBinding("Second view model tab", "Click ShowSecondTabCommand");

                    actionSheet.AddButtonWithBinding("Navigation (Clear back stack)", "Click ShowBackStackPageCommand");

                    actionSheet.CancelButtonIndex = actionSheet.AddButton("Cancel");
                    actionSheet.ShowEx(sender, (sheet, o) => sheet.ShowFrom((UIBarButtonItem)o, true));
                });


            using (var bindingSet = new BindingSet<MainViewModel>())
            {
                //TabBar
                bindingSet.Bind(this, AttachedMemberConstants.ItemsSource).To(() => (vm, ctx) => vm.ItemsSource);
                bindingSet.Bind(this, AttachedMemberConstants.SelectedItem).To(() => (vm, ctx) => vm.SelectedItem).TwoWay();
            }
        }

        #endregion
    }
}