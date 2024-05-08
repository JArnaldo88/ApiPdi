using ApiPdi.Application2.Domain.Models;
using ApiPdi.Application2.IRepository;
using ApiPdi.Infraestrutura2.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ApiPdi.Infraestrutura2.Repository
{
   
    public class UsuarioRepository :  IUsuarioRepository
    {
        private readonly MeuContexto _contexto;

        public UsuarioRepository(MeuContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _contexto.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> Buscartodos()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task InativarUsuario(int id)
        {
            var usuario = await _contexto.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Ativo = "N"; 
                await _contexto.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Usuário com ID {id} não encontrado.");
            }
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

    }
}
