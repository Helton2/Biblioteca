using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void incluirUsuario(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(user);
                bc.SaveChanges();
            }
        }
        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }
        public Usuario Listar(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
        public void editarUsuario(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario u = bc.Usuarios.Find(user.Id);

                u.Nome = user.Nome;
                u.Login = user.Login;
                u.Senha = user.Senha;
                u.Tipo = user.Tipo;
                bc.SaveChanges();

            }
        } 
        public void excluirUsuario(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();

            }
        }
    }
}