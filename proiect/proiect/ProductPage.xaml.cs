using proiect.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage //se utilizeaza pentru a crea o lista cu produse
    {
        ShopList sl;
        private ShopList slist;

        public ProductPage(ShopList bindingContext)
        {
            InitializeComponent();
            sl = slist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var product = (Burger)BindingContext;
            await App.Database.SaveProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = (Burger)BindingContext;
            await App.Database.DeleteProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Burger p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Burger;
                var lp = new ListProduct()
                {
                    ShopListID = sl.ID,
                    ProductID = p.ID
                };
                await App.Database.SaveListProductAsync(lp);
                p.ListProducts = new List<ListProduct> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}