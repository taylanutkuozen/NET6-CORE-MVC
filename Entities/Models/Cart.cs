namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines {get;set;}
        public Cart()
        {
            Lines=new List<CartLine>();
        }
        public void AddItem(Product product,int quantity)
        {
            CartLine? line=Lines.Where(l=>l.Product.ProductID.Equals(product.ProductID)).FirstOrDefault();
            if(line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product=product,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity+=quantity;
            }
        }
        public void RemoveLine(Product product)=>
            Lines.RemoveAll(l=>l.Product.ProductID.Equals(product.ProductID));
        public decimal ComputeTotalValue()=>
            Lines.Sum(e=>e.Product.ProductPrice*e.Quantity);
        public void Clear()=>Lines.Clear();
    }
}