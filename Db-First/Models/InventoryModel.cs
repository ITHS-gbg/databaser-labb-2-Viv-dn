namespace Labb2_DbFirst_Template.Handlers;

public class InventoryModel
{
    public int ShopId { get; set; }

    public string Isbn13Id { get; set; } = null!;

    public int? InStock { get; set; }
}