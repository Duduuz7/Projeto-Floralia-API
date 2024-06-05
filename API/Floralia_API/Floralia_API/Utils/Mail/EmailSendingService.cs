namespace WebAPI.Utils.Mail
{
    public class EmailSendingService
    {
        private readonly IEmailService emailService;

        public EmailSendingService(IEmailService service)
        {
            emailService = service;
        }

        public async Task SendRecovery(string email, int codigo)
        {
            try
            {
                MailRequest request = new MailRequest()
                {
                    ToEmail = email,

                    Subject = "Recuperação de senha",

                    Body = GetHtmlContentRecovery(codigo)

                };

                await emailService.SendEmailAsync(request);


            }
            catch (Exception)
            {

                throw;
            }
        }


        private string GetHtmlContentRecovery(int codigo)
        {
            string Response = @"
            <div style=""width:100%; background-color:rgba(96, 191, 197, 1); padding: 20px;"">
                <div style=""max-width: 600px; margin: 0 auto; background-color:#FFFFFF; border-radius: 10px; padding: 20px;"">
                    <img src=""https://blobvitalhubmatheusd.blob.core.windows.net/containervitalhubmatheusd/logo-removebg-preview%202Logo_Floralia%20(1).svg"" alt="" Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
                    <h1 style=""color: #333333;text-align: center;"">Recuperação de senha</h1>
                    <p style=""color: #666666;font-size: 24px; text-align: center;"">Código de confirmação <strong>" + codigo + @"</strong></p>
                </div>
            </div>";

            return Response;
        }
    }
}
