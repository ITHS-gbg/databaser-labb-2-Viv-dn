using Labb2_DbFirst_Template.Entities;

namespace Labb2_DbFirst_Template.Handlers
{
    public class ShopModel
    {
        public List<ShopTbl> Shops { get; set; }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<BookTbl> Isbn13Id { get; set; } = new();

        public List<BookModel> Inventory { get; set; } = new();
    }
}