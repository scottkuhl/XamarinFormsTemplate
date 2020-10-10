using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsTemplate.ViewModels;

namespace XamarinFormsTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}