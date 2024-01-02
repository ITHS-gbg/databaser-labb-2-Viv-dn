using Labb2_DbFirst_Template.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labb2_DbFirst_Template.Entities;
using Labb2_DbFirst_Template.Handlers;

namespace BookStore.Views
{
    /// <summary>
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        private readonly ShopRepository _shopRepository;

        public StoreWindowContext StoreWindowContext { get; set; } = new();

        public SharedViewModel SharedViewModel { get; set; }

        public SharedWindowContext SharedWindowContext { get; set; }

        public StoreView()
        {
            InitializeComponent();

            _shopRepository = new ShopRepository(AppContextManager.Context);
            this.DataContext = SharedViewModel;
        }
    
        private void StoreList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            //var shop = _shopRepository.GetShopById(1);
            //var shop2 = _shopRepository.GetShopById(2);
            //if (shop is null)
            //{
            //    return;
            //}
            //else
            //{
            //    foreach (var book in Inv )
            //    {
            //        StoreList.Items.Add(book);
            //    }
            //}

            //if (StoreList.SelectedItem is Inventory selectedItem)
            //{
            //    StoreWindowContext.Title = selectedItem.Isbn13Id;
            //    StoreWindowContext.Stock = selectedItem.InStock;
            //}
        }

        public string GetSelectedId()
        {
            return SharedViewModel.SelectedId;
        }


        private void MariaplanBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var shopChoice = _shopRepository.GetListFromShop1();
            StoreList.Items.Clear();

            foreach (var books in shopChoice)
            {
                StoreList.Items.Add(shopChoice);
            }
        }

        private void AkademibokhandelnBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //var shopChoice = _shopRepository.GetShopById(2);
        }

        private void PocketShop_OnClick(object sender, RoutedEventArgs e)
        {
            //    var shopChoice = _shopRepository.GetShopById(3);
            //    StoreList.ItemsSource = shopChoice;
            //}
        }
    }
}
