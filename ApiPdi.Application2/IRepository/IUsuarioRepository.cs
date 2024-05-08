using ApiPdi.Application2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPdi.Application2.IRepository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<List<Usuario>> Buscartodos();
        Task AdicionarUsuario(Usuario usuario);
        Task InativarUsuario(int id);
        Task AtualizarUsuario(Usuario usuario);

    }
}
