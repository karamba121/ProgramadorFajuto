using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class FerramentasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult FormatarEmailMarketing()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult FormatarEmailMarketing(IFormFile arquivo)
        {
            return File(this.FormatarEmailMarketingAsync(arquivo), "application/file", "EmailFormatado.html");
        }

        private Stream FormatarEmailMarketingAsync(IFormFile arquivo)
        {
            var texto = "";
            var backgroundColor = "#ffffff";
            var color = "#333333";
            var fontWeight = "normal";
            var fontFamily = "Arial";
            var alt = "img CAIXA Mais Vantagens";
            var title = "CAIXA Mais Vantagens";

            using (var streamReader = new StreamReader(arquivo.OpenReadStream()))
            {
                var conteudo = streamReader.ReadToEnd();
                texto = conteudo;
            }

            var textinho = new StringBuilder();
            var textoTratado = new StringBuilder(texto);

            if (textoTratado.ToString().Contains("</td>"))
                textoTratado = textoTratado.Replace("</td>", "\r\t\t</td>");

            if (textoTratado.ToString().Contains("alt=\"\""))
                textoTratado = textoTratado.Replace("alt=\"\"", "align=\"top\" alt=\"\"");

            var linhasDoTexto = textoTratado.ToString().Split(new[] { '\r' });

            linhasDoTexto = linhasDoTexto.RemoveAt(6);
            linhasDoTexto = linhasDoTexto.RemoveAt(linhasDoTexto.Length - 3);

            for (int i = 0; i < linhasDoTexto.Length; i++)
            {
                if (linhasDoTexto[i].Contains("<title>"))
                {
                    linhasDoTexto[i] = "<title>" + title + "</title>";
                }

                if (linhasDoTexto[i].Contains("<table"))
                {
                    linhasDoTexto[i] = linhasDoTexto[i].Replace(" cellspacing=\"0\">", "cellspacing=\"0\" align=\"center\">");
                }

                if (linhasDoTexto[i].Contains("<img"))
                {
                    var alturaDaTagImg = linhasDoTexto[i].Substring(linhasDoTexto[i].IndexOf("width="), linhasDoTexto[i].IndexOf(" alt=\"\"") - linhasDoTexto[i].IndexOf("width="));
                    linhasDoTexto[i - 1] = linhasDoTexto[i - 1].Replace(">", " " + alturaDaTagImg + ">");
                    linhasDoTexto[i - 1] = linhasDoTexto[i - 1].Replace("align", "valign");
                    linhasDoTexto[i] = linhasDoTexto[i].Replace("alt=\"\"", "alt=\"" + alt + "\" title=\"" + title + "\" style=\"display:block;\"");
                }

                if (linhasDoTexto[i].Contains("texto"))
                {
                    linhasDoTexto[i - 1] = linhasDoTexto[i - 1].Replace("valign=\"top\"", "valign=\"top\" style=\"background-color:" + backgroundColor + ";\"");

                    var largura = linhasDoTexto[i].Substring(linhasDoTexto[i].IndexOf("width=") + 7, (linhasDoTexto[i].IndexOf("height=") - 2) - (linhasDoTexto[i].IndexOf("width=") + 7));
                    var altura = linhasDoTexto[i].Substring(linhasDoTexto[i].IndexOf("height=") + 8, (linhasDoTexto[i].IndexOf("align=") - 2) - (linhasDoTexto[i].IndexOf("height=") + 8));
                    var estaLinha = linhasDoTexto[i].Substring(linhasDoTexto[i].IndexOf("<"));
                    var lineHeight = linhasDoTexto[i].Substring(linhasDoTexto[i].IndexOf("texto-") + 6, (linhasDoTexto[i].IndexOf(">")) - (linhasDoTexto[i].IndexOf("texto-") + 6));

                    linhasDoTexto[i] = linhasDoTexto[i].Replace(estaLinha, "<div style=\"width:" + largura + "px;height:" + altura + "px;color:" + "#ffffff" + ";background-color:" + backgroundColor + ";text-align:center;\">\r\t\t\t\t" +
                        "<font style=\"width:" + largura + "px;height:" + altura + "px;line-height:" + (int.Parse(altura)) / int.Parse(lineHeight) + "px;color:" + color + ";background-color:" + backgroundColor + ";text-align:center;font-family:" + fontFamily +
                        ";font-size:" + (((int.Parse(altura)) / int.Parse(lineHeight)) - 4) + "px;font-weight:" + fontWeight + ";\">\r" + "\t\t\t\t\tOlá, #participante#" + "\r\t\t\t\t</font>\r\t\t\t</div>");
                }
            }

            for (int i = 0; i < linhasDoTexto.Length; i++)
            {
                textinho.AppendLine(linhasDoTexto[i]);
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(textinho.ToString()));
        }
    }
}
