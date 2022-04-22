namespace Whatsapp
{
    public interface IMensagem
    {
        string Enviar(string cel);
        bool Verificar(string cod, string cripto);
    }
}
