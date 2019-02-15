using System;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace Caixa
{
    class AcessoEmail
    {
        public bool enviarEmail(string mensagem, string destinatario)
        {
            try
            {
                String email, senha, assunto, titulo;
                email = "grupoti321@outlook.com";
                senha = "amaralfrango1";
                assunto = "SENHA";
                titulo = "SENHA SECRETA APAGAR BANCO";

                SmtpClient cliente = new SmtpClient();
                cliente.Host = "smtp.live.com";
                cliente.EnableSsl = true;
                cliente.UseDefaultCredentials = false;
                cliente.Port = 587;
                cliente.Credentials = new NetworkCredential(email, senha);


                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(email, titulo);
                message.From = new MailAddress(email, titulo);
                message.To.Add(new MailAddress(destinatario));
                message.Subject = assunto;
                message.Body = mensagem;
                message.IsBodyHtml = false;


                cliente.Send(message);

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Confirma a validade de um email
        /// </summary>
        /// <param name="enderecoEmail">Email a ser validado</param>
        /// <returns>Retorna True se o email for valido</returns>
        public bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
