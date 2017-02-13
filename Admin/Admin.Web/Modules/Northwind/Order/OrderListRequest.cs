using Serenity.Services;

namespace Admin.Northwind
{
    public class OrderListRequest : ListRequest
    {
        public int? ProductID { get; set; }
    }
}