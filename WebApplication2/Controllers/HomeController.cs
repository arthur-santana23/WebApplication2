using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private static List<ClasseAbstrata> listaDeObjetos = new List<ClasseAbstrata>
    {
        new ClasseDerivada { Id = 1, Nome = "Exemplo1" },
        new ClasseDerivada { Id = 2, Nome = "Exemplo2" },
        new ClasseDerivada { Id = 3, Nome = "Exemplo3" }
    };

        public IActionResult Index()
        {
            ViewData["ListaDeObjetos"] = listaDeObjetos;
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarObjeto(string nome)
        {
            var novoObjeto = new ClasseDerivada
            {
                Id = listaDeObjetos.Count + 1,
                Nome = nome
            };

            listaDeObjetos.Add(novoObjeto);

            return Json(new { id = novoObjeto.Id, nome = novoObjeto.Nome, metodoAbstrato = novoObjeto.MetodoAbstrato() });
        }
        [HttpPost]
        public IActionResult EditarObjeto(int id, string novoNome)
        {
            var objetoParaEditar = listaDeObjetos.FirstOrDefault(obj => obj.Id == id);

            if (objetoParaEditar != null)
            {
                objetoParaEditar.Nome = novoNome;

                return Json(new { sucesso = true, mensagem = "Objeto editado com sucesso." });
            }

            return Json(new { sucesso = false, mensagem = "Objeto não encontrado para edição." });
        }

        [HttpPost]
        public IActionResult ExcluirObjeto(int id)
        {
            var objetoParaExcluir = listaDeObjetos.FirstOrDefault(obj => obj.Id == id);

            if (objetoParaExcluir != null)
            {
                listaDeObjetos.Remove(objetoParaExcluir);

                return Json(new { sucesso = true, mensagem = "Objeto excluído com sucesso." });
            }

            return Json(new { sucesso = false, mensagem = "Objeto não encontrado para exclusão." });
        }
    }
}
