namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0; //Sqlite icerisinde decimal destegi olmadigi icin Integer tanimlandi.
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}