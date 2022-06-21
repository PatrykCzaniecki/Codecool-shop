using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Codecool.CodecoolShop.Models;

string to = ""; //To address    
string from = "codecoolshop123@gmail.com"; //From address    
MailMessage message = new MailMessage(from, to);

string mailbody = "Welcome in Codecool Shop! This is a confirmation Email about your order.";

message.Subject = "Order";
message.Body = mailbody;
message.BodyEncoding = Encoding.UTF8;
message.IsBodyHtml = true;

SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
NetworkCredential basicCredential1 = new NetworkCredential("yourmail id", "Password");
client.EnableSsl = true;
client.UseDefaultCredentials = false;
client.Credentials = basicCredential1;
try
{
    client.Send(message);
}

catch (Exception ex)
{
    throw ex;
}