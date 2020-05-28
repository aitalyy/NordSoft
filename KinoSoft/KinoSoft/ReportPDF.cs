using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;

namespace KinoSoft
{
    public enum TypeReport
    {
        [Description("Отчет")]
        Report
    }

    class ReportPDF
    {

        Contex db = new Contex();

        public void Save(TypeReport type, DateTime startDate, DateTime endDate)
        {
            switch (type)
            {
                case TypeReport.Report:
                    CreateReport1(startDate, endDate);
                    break;
                default:
                    break;
            }
        }

        public void CreateReport1(DateTime startDate, DateTime endDate)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("report.pdf", FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            doc.Add(new Paragraph("ОТЧЕТ", font));

            var result = db.Orders.Where(c => (c.Date > startDate && c.Date < endDate));
            foreach (Order order in result)
            {
                doc.Add(new Paragraph(order.Cost.ToString(), font));
            }
            doc.Close();
        }

        public void SendMail()
        {
            MailAddress from = new MailAddress("somemail@gmail.com", "Tom");
            MailAddress to = new MailAddress("somemail@yandex.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Attachments.Add(new Attachment("report.pdf"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
