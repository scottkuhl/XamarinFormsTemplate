using Windows.UI.Core;

namespace XamarinFormsTemplate.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new XamarinFormsTemplate.App());

            // HACK: https://github.com/xamarin/Xamarin.Forms/issues/12443
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}