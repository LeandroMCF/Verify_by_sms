

using System;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Whatsapp.Repositorie
{
    public class Mensagem : IMensagem
    {
        public string Enviar(string cel)
        {
            //Criar senha

            string poss = "1234567890";
            Random sorteio = new Random();
            int num = 0;
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                num = sorteio.Next(0, poss.Length - 1);
                password.Append(poss[num]);
            }

            //Enviar senha

            var sid = "AC7f1c920175fb38e5f69f4346757a4f77";
            var authToken = "85ff73b38a817e307c2021f1481b6de0";
            TwilioClient.Init(sid, authToken);

            var message = MessageResource.Create(
                from: new PhoneNumber("+18646333589"),
                to: new PhoneNumber(cel),
                body: password.ToString()
            );

            //Retornar senha para o sistema

            string senha = Criptografia.CalculaHash(password.ToString());
            return senha;
        }

        public bool Verificar(string cod, string cripto)
        {
            string senha = Criptografia.CalculaHash(cod);

            if (senha == cripto)
            {
                return true;
            }

            return false;
        }
    }
}
