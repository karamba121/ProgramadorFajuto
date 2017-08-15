using System;

namespace ProgramadorFajuto.Application.Aplicacao.Util
{
    public class ExcecaoDeAplicacao : Exception
    {
        private ExcecaoDeAplicacao() { }
        public ExcecaoDeAplicacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; private set; }
    }
}
