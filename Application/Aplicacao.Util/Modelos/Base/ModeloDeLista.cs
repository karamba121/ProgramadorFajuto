using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Application.Aplicacao.Util.Modelos.Base
{
    public class ModeloDeLista<T> : List<T>
    {
        public ModeloDeLista(List<T> items, int contador, int numeroDaPagina)
        {
            this.NumeroDaPagina = numeroDaPagina;
            this.TotalDePaginas = (int)Math.Ceiling(contador / 10.0);

            this.AddRange(items);
        }

        public int NumeroDaPagina { get; set; }
        public int TotalDePaginas { get; set; }
        public bool TemPaginaAnterior => this.NumeroDaPagina > 1;
        public bool TemPaginaPosterior => this.NumeroDaPagina < TotalDePaginas;

        public static ModeloDeLista<T> Criar(IEnumerable<T> source, int numeroDaPagina)
        {
            var contador = source.Count();
            var items = source.Skip((numeroDaPagina - 1) * 10).Take(10).ToList();
            return new ModeloDeLista<T>(items, contador, numeroDaPagina);
        }
    }
}
