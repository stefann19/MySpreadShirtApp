namespace SpreadShirtShop.Models;

public class Sellable
{
    public string SellableId { get; set; }
    public string IdeaId { get; set; }
    public string MainDesignId { get; set; }
    public string ProductTypeId { get; set; }
    public List<Tag> Tags { get; set; }
    public CurrencyPrice Price { get; set; }
    public ImageModel PreviewImage { get; set; }
    public List<Appearance> AppearanceIds { get; set; }
    public int DefaultAppearanceId { get; set; }
}

public class RawSellable
{
    public string SellableId { get; set; }
    public string IdeaId { get; set; }
    public string MainDesignId { get; set; }
    public string ProductTypeId { get; set; }
    public List<string> Tags { get; set; }
    public CurrencyPrice Price { get; set; }
    public ImageModel PreviewImage { get; set; }
    public List<string> AppearanceIds { get; set; }
    public string DefaultAppearanceId { get; set; }

    public Sellable toSellable()
    {
        return new Sellable
        {
            Price = this.Price,
            SellableId = this.SellableId,
            ProductTypeId = this.ProductTypeId,
            PreviewImage = this.PreviewImage,
            MainDesignId = this.MainDesignId,
            IdeaId = this.IdeaId,
            DefaultAppearanceId = int.Parse(this.DefaultAppearanceId),
            Tags = this.Tags.Select(t => new Tag { Value = t }).ToList(),
            AppearanceIds = this.AppearanceIds.Select(a => new Appearance { Value = a }).ToList(),
        };
    }
}


public class SellablesPages
{
    public int Count { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public List<RawSellable> Sellables { get; set; }
}
public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Categoryname { get; set; }
    public string Brand { get; set; }
    public double ShippingFactor { get; set; }
    public string SizeFitHint { get; set; }

}