using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ListaDeUsuarios()
        {
            Autenticacao.CheckLogin(this);
            //Autenticacao.verifcaSeUsuarioEAdmin(this);

            return View(new UsuarioService().Listar());
        }
        public IActionResult editarUsuario(int id)
        {
            Usuario u = new UsuarioService().Listar(id);
            return View(u);
        }
        [HttpPost]
        public IActionResult editarUsuario(Usuario userEditado)
        {
            UsuarioService us = new UsuarioService();
            us.editarUsuario(userEditado);

            return RedirectToAction("ListaDeUsuarios");
        }
        public IActionResult RegistrarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            //Autenticacao.verifcaSeUsuarioEAdmin(this);

            return View();
        }
        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario novoUser)
        {
            Autenticacao.CheckLogin(this);
            //Autenticacao.verifcaSeUsuarioEAdmin(this);

            //novoUser.Senha = Criptografo.TextoCriptografo(novoUser.Senha);

            UsuarioService us = new UsuarioService();
            us.incluirUsuario(novoUser);

            return RedirectToAction("cadastroRealizado");

        }
        public IActionResult ExcluirUsuario(int id)
        {
            return View(new UsuarioService().Listar(id));
        }
        [HttpPost]
        public IActionResult ExcluirUsuario(string descisao,int id)
        {
            if(descisao =="EXCLUIR")
            {
                ViewData["Mensagem"] = "Exclusão do usuario "+new UsuarioService().Listar(id).Nome+" realizada com sucesso";
                new UsuarioService().excluirUsuario(id);
                return View("ListaDeUsuarios",new UsuarioService().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Exclusão cancelada";
                return View("ListaDeUsuarios",new UsuarioService().Listar());
            }
        }
        public IActionResult cadastroRealizado()
        {
            Autenticacao.CheckLogin(this);
            //Autenticacao.verifcaSeUsuarioEAdmin(this);

            return View();
        }
        public IActionResult NeedAdmin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }
        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
    
}