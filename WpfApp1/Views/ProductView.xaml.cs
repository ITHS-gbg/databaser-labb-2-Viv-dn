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

        public SharedViewModel SharedViewModel { get; set; }

        public ProductView()
        {
            InitializeComponent();

            _productRepository = new ProductRepository(AppContextManager.Context);

            SharedViewModel = new SharedViewModel();

        }

        private void ProdListBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //var products = _productRepository.GetAllProducts();
            List<BookModel> books = _productRepository.GetAllProducts();
            ProdList.Items.Clear();

            if (books is null)
            {
                BookModel book = new BookModel();
                book.AuthorId = 3;
                book.Isbn13 = "12345678";
                book.Title = "Hej";
                ProdList.Items.Add(book);
            }
            else
            {
                foreach (var bookTbl in books)
                {
                    ProdList.Items.Add(bookTbl);
                }
            }

        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {

            if (ProdList.SelectedItem is List<BookModel> selectedItem)
            {
                //var selectedProd = WindowContext.Products.FirstOrDefault(b => b.Title == selectedItem.Title);
                var selectedProd = selectedItem.FirstOrDefault();
                if (selectedProd is null)
                {
                    return;
                }
                else
                {
                    SharedViewModel.SelectedId = selectedProd.Isbn13;
                    _productRepository.AddProduct(selectedProd);
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
