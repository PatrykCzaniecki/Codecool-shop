using System.Net;
using System.Net.Mail;

internal static class Email
{
    public static void SendEmail(string emailTo)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential("codecoolshop123@gmail.com", "crdittdmwumbitlg"),
            EnableSsl = true
        };
        client.Send("codecoolshop123@gmail.com", emailTo, "test", "testbody");
    }
}