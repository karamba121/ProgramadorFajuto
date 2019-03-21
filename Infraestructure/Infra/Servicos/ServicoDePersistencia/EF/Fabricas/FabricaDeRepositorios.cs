using System;
using System.Collections.Generic;

namespace ProgramadorFajuto.Infraestructure.Infra.Servicos.EF.Fabricas
{
    public class FabricaDeRepositorios
    {
        private readonly ContextoEF _contexto;
        private readonly IDictionary<string, object> _repositorios;

        public FabricaDeRepositorios(ContextoEF contexto)
        {
            this._contexto = contexto;
            this._repositorios = new Dictionary<string, object>();
        }

        public T PegarRepositorio<T, I>() where T : class where I : class
        {
            var tipo = typeof(T);

            if (this._repositorios.ContainsKey(tipo.Name))
                return this._repositorios[tipo.Name] as T;

            var implementacao = Activator.CreateInstance(typeof(I), this._contexto);

            this._repositorios.Add(tipo.Name, implementacao);

            return this._repositorios[tipo.Name] as T;
        }
    }
}
