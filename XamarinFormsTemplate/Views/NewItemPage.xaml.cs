using Xamarin.Forms;

using XamarinFormsTemplate.Models;
using XamarinFormsTemplate.ViewModels;

namespace XamarinFormsTemplate.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}