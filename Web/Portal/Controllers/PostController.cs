using Microsoft.AspNetCore.Mvc;
using ProgramadorFajuto.Application.Aplicacao.Portal.Contratos;
using ProgramadorFajuto.Application.Aplicacao.Portal.Modelos;
using ProgramadorFajuto.Domain.Dominio.Entidades;
using ProgramadorFajuto.Web.Portal.Filters;
using System.Collections.Generic;
using System.Linq;

namespace ProgramadorFajuto.Web.Portal.Controllers
{
    public class PostController : Controller
    {
        private readonly IServicoDePost _servicoDePost;

        public PostController(IServicoDePost servicoDePost)
        {
            this._servicoDePost = servicoDePost;
        }

        [HttpGet]
        [ExcecoesFilter]
        public IActionResult Index()
        {
            var posts = this._servicoDePost.ListarPosts();
            var meusPosts = new List<Post>();

            if (User.Identity.IsAuthenticated)
                meusPosts = posts.Where(p => p.Id == int.Parse(User.FindFirst("Id").Value)).ToList();

            return View(new ModeloDePost(posts, meusPosts));
        }

        [HttpGet]
        [ExcecoesFilter]
        public IActionResult Detalhes(int id)
        {
            var post = this._servicoDePost.ObterPostPorId(id);

            return View(post);
        }
    }
}
