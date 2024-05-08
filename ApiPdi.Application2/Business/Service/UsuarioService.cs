using ApiPdi.Application2.Business.Interfaces;
using ApiPdi.Application2.Domain.Models;
using ApiPdi.Application2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPdi.Application2.Business
{


    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<List<Usuario>> Buscartodos()
        {
            return await _usuarioRepository.Buscartodos();
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            await _usuarioRepository.AdicionarUsuario(usuario);
        }

        public async Task InativarUsuario(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario != null)
            {
                usuario.Ativo = "N"; // Define o usuário como inativo
                await _usuarioRepository.AtualizarUsuario(usuario);
            }
            else
            {
                throw new ArgumentException($"Usuário com ID {id} não encontrado.");
            }
        }
        public async Task AtualizarUsuario(Usuario usuario)
        {
            await _usuarioRepository.AtualizarUsuario(usuario);
        }

    }
}
