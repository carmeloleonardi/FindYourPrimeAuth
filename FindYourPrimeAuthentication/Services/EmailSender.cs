﻿using FindYourPrimeAuthentication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace FindYourPrimeAuthentication.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IWebHostEnvironment _env;

        public EmailSender(IOptions<SmtpSettings> smtpSettings, IWebHostEnvironment env)
        {
            _smtpSettings = smtpSettings.Value;
            _env = env;
        }

        [Obsolete]
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = htmlMessage
                };

                using(var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrore) => true;


                    if( _env.IsDevelopment())
                    {
                        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port);
                    }
                    else
                    {
                        await client.ConnectAsync(_smtpSettings.Server);
                    }

                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
