using FCI.AlzheimerDetection.BL.DTOs.EmailServiceDTOs;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Settings.EmailSettings;
using FCI.AlzheimerDetection.DAL.Shared;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class EmailManager
    (IOptions<EmailSetting> emailSettings, UserManager<ApplicationUser> userManager)
    : IEmailManager
{
    private readonly EmailSetting _emailSettings = emailSettings.Value;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result> ResetPassword(string email, string token, ResetPasswordDTO resetPasswordDTO)
    {
        var userIsExists = await _userManager.FindByEmailAsync(email);
        if (userIsExists is null)
            return Result.Failure("User Is not Exists");

        var checkToken = await _userManager
            .VerifyUserTokenAsync(userIsExists, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);

        if (!checkToken)
            return Result.Failure("Invalid Token");

        var resetPasswordResult = await _userManager.ResetPasswordAsync(userIsExists, token, resetPasswordDTO.NewPassword);

        if (!resetPasswordResult.Succeeded)
            return Result.Failure("".GetErrorResult(resetPasswordResult));

        await SendEmailAsync(email, "Password Changed Successfully", "Your Password has been Reset Successfully");

        return Result.Success("Password Changed Successfully");
    }

    public async Task<Result> ConfirmEmailAsync(string email, string token)
    {
        var userIsExists = await _userManager.FindByEmailAsync(email);
        if (userIsExists is null)
            return Result.Failure<string>("User Is Not Exists");

        var confirmatinoResult = await _userManager.ConfirmEmailAsync(userIsExists, token);

        if (!confirmatinoResult.Succeeded)
            return Result.Failure("Email Confirmation Failed");

        return Result.Success("Email Confirmed Successfully");
    }

    public async Task<Result> ForgetPassword(string email)
    {
        var userIsExists = await _userManager.FindByEmailAsync(email);

        if (userIsExists is null)
            return Result.Failure("User Is Not Exists");

        var token = await _userManager.GeneratePasswordResetTokenAsync(userIsExists);

        var callbackURL = $"http://localhost:3000/resetPassword?email={email}&token={token}";

        await SendEmailAsync(email, "Forget Password", callbackURL);
        return Result.Success("Email Send Successfully");
    }

    public async Task<Result> ChangePassword(string email, ChangePasswordDTO changePasswordDTO)
    {
        var userIsExists = await _userManager.FindByEmailAsync(email);
        if (userIsExists is null)
            return Result.Failure("User Is not Exists");

        var checkOldPassword =
            await _userManager.CheckPasswordAsync(userIsExists, changePasswordDTO.OldPassword);

        if (!checkOldPassword)
            return Result.Failure("Old Password Is Not Correct");

        var resetPassword =
             await _userManager.ChangePasswordAsync(userIsExists, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);

        if (!resetPassword.Succeeded)
            return Result.Failure("".GetErrorResult(resetPassword));

        await SendEmailAsync(email, "Password Changed Successfully", "Your Password Changed Successfully");

        return Result.Success("Password Changed Successfully");
    }

    public async Task SendEmailAsync(string To, string Subject, string Content, IList<IFormFile> attachments = null)
    {
        var email = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_emailSettings.Email),
            Subject = Subject
        };

        email.To.Add(MailboxAddress.Parse(To));

        var builder = new BodyBuilder
        {
            HtmlBody = Content
        };

        if (attachments != null && attachments.Any())
        {
            foreach (var file in attachments)
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    file.CopyTo(ms);
                    builder.Attachments.Add(file.FileName, ms.ToArray(), ContentType.Parse(file.ContentType));
                }
            }
        }

        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}

#region Send Email Steps

/*
 The SendEmailAsync method in the EmailManager class is responsible for sending an email with optional attachments. Here are the steps involved in the creation of this method:
1.	Create a new MimeMessage object to represent the email message.
•	Set the Sender property of the MimeMessage object to the email address specified in the _emailSettings field.
•	Set the Subject property of the MimeMessage object to the value of the Subject parameter passed to the method.
2.	Add the recipient email address to the To property of the MimeMessage object.
•	Parse the To parameter value and add it to the To property of the MimeMessage object.
3.	Create a BodyBuilder object to build the email body.
•	Set the HtmlBody property of the BodyBuilder object to the value of the Content parameter passed to the method.
4.	Check if there are any attachments specified.
•	If the attachments parameter is not null and contains any items, proceed to the next step. Otherwise, skip the attachment handling.
5.	Iterate through each attachment in the attachments parameter.
•	Check if the attachment has a non-zero length.
•	Create a new MemoryStream object to store the attachment data.
•	Copy the attachment data to the MemoryStream.
•	Add the attachment to the Attachments property of the BodyBuilder object, using the attachment's file name, the data from the MemoryStream, and the content type parsed from the attachment's ContentType property.
6.	Set the email body of the MimeMessage object to the message body built by the BodyBuilder object.
7.	Create a new SmtpClient object to handle the email sending process.
8.	Connect to the SMTP server using the email server settings specified in the _emailSettings field.
•	Use the Host and Port properties of the _emailSettings field to establish the connection.
•	Use the StartTls option to enable a secure connection.
9.	Authenticate with the SMTP server using the email address and password specified in the _emailSettings field.
10.	Send the email using the SendAsync method of the SmtpClient object, passing in the MimeMessage object.
11.	Disconnect from the SMTP server, indicating that the email sending process is complete.*/

#endregion Send Email Steps