using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;
using KissLog;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ILogger _logger { get; set; }

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Trace("teste 23423423");
            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            throw new Exception("Errooooo");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if(id == 500)
            {
                modelErro.ErrorCode = id;
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.Mensagem = "Tente novamente mais tarde ou entre em contato com o suporte!!";
            }
            else if(id == 404)
            {
                modelErro.ErrorCode = id;
                modelErro.Titulo = "Página não encontrada";
                modelErro.Mensagem = "A Página que está procurando não existe </br> Em caso de dúvidas entre em contato com o suporte!!";
            }
            else if (id == 403)
            {
                modelErro.ErrorCode = id;
                modelErro.Titulo = "Acesso Negado";
                modelErro.Mensagem = "Você não possui permissão para acessar esta página!!";
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
