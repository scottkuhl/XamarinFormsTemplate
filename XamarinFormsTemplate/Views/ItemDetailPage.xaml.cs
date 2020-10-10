using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsTemplate.ViewModels;

namespace XamarinFormsTemplate.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}