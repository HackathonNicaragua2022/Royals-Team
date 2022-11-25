using _EnSena.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace _EnSena.Views
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