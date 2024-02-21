using System.Net;
using System.Net.Mail;
using MDL_Test_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDL_Test_task.Controllers;

[ApiController, Route("api/[controller]")]
public class MailsController(MailSettings smtpSettings, ApplicationContext context) : Controller
{
    /// <summary>
    /// Обработчик GET запроса. Возвращает все рассылки сообщений, отправленные ранее
    /// (Записанные в БД).
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetMails()
    {
        var allMails = await context.Mails.ToListAsync();
        
        return Ok(allMails);
    }

    /// <summary>
    /// Обработчик POST запроса. Делает рассылку сообщения и сохраняет информацию в БД
    /// </summary>
    /// <param name="mail">Данные для рассылки</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SendMail(Mail mail)
    {
        var mailForDb = await GetAndSendEmail(mail);
        await context.Mails.AddAsync(mailForDb);
        await context.SaveChangesAsync();
        return Ok(mailForDb);
    }

    private async Task<DbMail> GetAndSendEmail(Mail mail)
    {
        var mailForBd = new DbMail
        {
            Subject = mail.Subject,
            Body = mail.Body,
            Recipients = string.Join(",", mail.Recipients),
        };
        
        var smtpClient = new SmtpClient(smtpSettings.Server)
        {
            Port = smtpSettings.Port,
            EnableSsl = true,   
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
        };

        var message = new MailMessage();
        message.From = new MailAddress(smtpSettings.Username);
        
        foreach (var recipient in mail.Recipients)
        {
            message.To.Add(recipient);
        }

        message.Subject = mail.Subject;
        message.Body = mail.Body;

        try
        {
            await smtpClient.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            mailForBd.Result = "Failed";
            mailForBd.FailedMessage = ex.Message;
        }

        return mailForBd;
    }
}