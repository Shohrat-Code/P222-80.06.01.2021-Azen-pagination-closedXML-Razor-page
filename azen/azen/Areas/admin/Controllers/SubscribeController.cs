using azen.Data;
using azen.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace azen.Areas.admin.Controllers
{
    [Area("admin")]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Subscribe> subscribes = _context.Subscribes.ToList();
            string subscribeModel = JsonConvert.SerializeObject(subscribes);

            HttpContext.Session.SetString("Subscribe", subscribeModel);
            return View(subscribes);
        }

        public IActionResult DownloadToExcel()
        {
            string subscribeModel = HttpContext.Session.GetString("Subscribe");
            List<Subscribe> subscribes = JsonConvert.DeserializeObject<List<Subscribe>>(subscribeModel);

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("sl1");

            ws.Row(1).Height = 5;
            ws.Row(2).Height = 30;
            ws.Row(3).Height = 18;

            ws.Column("A").Width = 0.3;
            ws.Column("B").Width = 6;
            ws.Column("C").Width = 30;
            ws.Column("D").Width = 15;

            ws.Range("B2:D2").Merge();
            ws.Range("B2:D2").Value = "Subscribe list";
            ws.Range("B2:D2").Style.Font.FontSize= 14;
            ws.Range("B2:D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("B2:D2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range("B2:D2").Style.Font.Bold = true;

            ws.Cell("B3").Value = "#";
            ws.Cell("B3").Style.Fill.BackgroundColor= XLColor.FromArgb(0, 112, 192);
            ws.Cell("B3").Style.Font.FontColor = XLColor.White;
            ws.Cell("B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("B3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("B3").Style.Font.Bold = true;
            ws.Cell("B3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("C3").Value = "Email";
            ws.Cell("C3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("C3").Style.Font.FontColor = XLColor.White;
            ws.Cell("C3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("C3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("C3").Style.Font.Bold = true;
            ws.Cell("C3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell("D3").Value = "Date";
            ws.Cell("D3").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 112, 192);
            ws.Cell("D3").Style.Font.FontColor = XLColor.White;
            ws.Cell("D3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("D3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Cell("D3").Style.Font.Bold = true;
            ws.Cell("D3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.RightBorder = XLBorderStyleValues.Thin;


            for (int i = 0; i < subscribes.Count; i++)
            {
                ws.Cell("B" + (i + 4)).Value = i + 1;
                ws.Cell("B" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("B" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("C" + (i + 4)).Value = subscribes[i].Email;
                ws.Cell("C" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Cell("C" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("C" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Cell("D" + (i + 4)).Value = subscribes[i].CreatedDate.ToString("dd.MM.yyyy");
                ws.Cell("D" + (i + 4)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("D" + (i + 4)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell("D" + (i + 4)).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + (i + 4)).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            }

            using (var stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Subscribe List.xlsx");
            }
        }

        public IActionResult SendMailAll()
        {
            return View(_context.Subscribes.ToList());
        }

        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Subscribe> subscribes = _context.Subscribes.ToList();

            foreach (var item in subscribes)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("codegroupsp@gmail.com", "Code academy p222");
                mail.To.Add(item.Email);
                mail.Body = MailText;
                mail.IsBodyHtml = true;
                mail.Subject = "Reklam";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("codegroupsp@gmail.com", "codegroupsp2021");

                smtpClient.Send(mail);
            }

            return RedirectToAction("Index");
        }
    }
}
