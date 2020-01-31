using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Формирование письма
            MailMessage mm = new MailMessage("dev.kz@yandex.kz", "altynbek040492@gmail.com");
            mm.Subject = "Заголовок письма";
            mm.Body = "Содержимое письма";
            mm.IsBodyHtml = false; // Не используем html в теле письма


            // Авторизуемся на smtp-сервере и отправляем письмо
            SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential("dev.kz@yandex.kz", "Qwerty");
            sc.Send(mm);
        }
    }
}
