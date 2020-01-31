using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace WpfTestMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var listStrMails = new List<string> { "altynbek040492@gmail.com" };
            string strPassword = passwordBox.Password;
            foreach (string mail in listStrMails)
            {
                using(MailMessage mm = new MailMessage("dev.kz@yandex.kz", mail))
                {
                    mm.Subject = "Hello from C#";
                    mm.Body = "Hello, world!";
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("dev.kz@yandex.kz", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
