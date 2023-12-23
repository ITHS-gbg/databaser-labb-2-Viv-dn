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
using Labb2_DbFirst_Template.Handlers;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private readonly ProductRepository _productRepository;

        public WindowContext WindowContext { get; set; }

        public ProductView()
        {
                InitializeComponent();

            _productRepository = new ProductRepository(AppContextManager.Context);

        }

        private void ProdListBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var products = _productRepository.GetAllProducts();
            ProdList.Items.Clear();

            foreach (var bookModel in products)
            {
                ProdList.Items.Add(products);
            }
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ProdList.SelectedItem is BookModel selectedItem)
            {
                var selectedProd = WindowContext.Products.FirstOrDefault(b => b.Title == selectedItem.Title);
                if (selectedProd is null)
                {
                    return;
                }
            }
            //else if (StoreList.SelectedItem is BookModel selectedIem)
            //{
            //    //gör en till i WindowContext för StoreList selected Item namn
            //    //var selectedProd = WindowContext.BookTbl.FirstOrDefault(b => b.Title == selectedItem.Title);
            //}
        }

        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }

    }
}
