using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

static class Email
{
    private static OrderDaoMemory orderDataStore;
    private static Order order;
    public static void SendEmail(string emailTo)
    {
        orderDataStore = OrderDaoMemory.GetInstance();
        order = orderDataStore.order;

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("codecoolshop123@gmail.com", "crdittdmwumbitlg"),
            EnableSsl = true
        };
        string message = CreateMessage();
        client.Send("codecoolshop123@gmail.com", emailTo, $"CodeCool Shop - You buy {order.Cart.TotalProducts()} products", message);
    }

    private static string CreateMessage()
    {
        order = orderDataStore.order;
        string message = $"Hello {order.Address.FullName},\n Here is you confirmation order\n You buy:\n\n";
        foreach (var product in order.Cart.Products)
        {
            message +=
                $"Name: {product.Key.Name}\nPrice: {product.Key.DefaultPrice}\nQuantity: {product.Key.CartQuantity}\n\n";
        }

        message += $"Total price: {order.Cart.TotalPrice()}\nTotal products: {order.Cart.TotalProducts()}\n\n";
        message += $"Your shipping addres:\n\nFull name: {order.Address.FullName}\nStreet: {order.Address.Street}\nCity: {order.Address.City}\nZip code: {order.Address.Zip}\n" +
                   $"Country: {order.Address.Country}\nEmail: {order.Address.Email}\nPhone: {order.Address.Phone}\n";
        return message;
    }
}

 