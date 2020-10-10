using Xamarin.Forms;
using XamarinFormsTemplate.Services;

// TODO: Replace all instances of XamarinFormsTemplate with your application name through the entire solution.

namespace XamarinFormsTemplate
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}