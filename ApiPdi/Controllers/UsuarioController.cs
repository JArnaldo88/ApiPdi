using ApiPdi.Application2.Business.Interfaces;
using ApiPdi.Application2.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApiPdi.Controllers
{

    
    [Route("api/[controller]")]
    public class UsuarioControllers  : Controller
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioControllers(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("ObterPorId/{id}")]
        public async Task<Usuario> ObterPorId(int id)
        {
            var usuario = await _usuarioService.BuscarPorId(id);
            return usuario;

        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<List<Usuario>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.Buscartodos();
            return Ok(usuarios);
        }

        [HttpPost("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Dados do usuário inválidos.");
                }

                 await _usuarioService.AdicionarUsuario(usuario);


                return Ok("Usuario cadastrado com Sucesso!"); 
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Erro ao adicionar usuário: {ex.Message}");
            }
        }

        [HttpPut("inativar/{id}")]
        public async Task<IActionResult> InativarUsuario(int id)
        {
            try
            {
                await _usuarioService.InativarUsuario(id);
                return Ok("Usuário inativado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao inativar usuário: {ex.Message}");
            }
        }
        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] Usuario usuarioAtualizado)
        {
            try
            {
                if (usuarioAtualizado == null || id <= 0)
                {
                    return BadRequest("Dados do usuário inválidos.");
                }

                var usuarioExistente = await _usuarioService.BuscarPorId(id);

                if (usuarioExistente == null)
                {
                    return NotFound("Usuário não encontrado.");
                }
                if (usuarioExistente.Nome != usuarioAtualizado.Nome)
                {
                    usuarioExistente.Nome = usuarioAtualizado.Nome;
                }
                if (usuarioExistente.Sobrenome != usuarioAtualizado.Sobrenome)
                {
                    usuarioExistente.Sobrenome = usuarioAtualizado.Sobrenome;
                }
                if (usuarioExistente.Email != usuarioAtualizado.Email)
                {
                    usuarioExistente.Email = usuarioAtualizado.Email;
                }
                if (usuarioExistente.Endereco != usuarioAtualizado.Endereco)
                {
                    usuarioExistente.Endereco = usuarioAtualizado.Endereco;
                }
                if (usuarioExistente.Numero != usuarioAtualizado.Numero)
                {
                    usuarioExistente.Numero = usuarioAtualizado.Numero;
                }
                if (usuarioExistente.Telefone != usuarioAtualizado.Telefone)
                {
                    usuarioExistente.Telefone = usuarioAtualizado.Telefone;
                }
                if (usuarioExistente.Ativo != usuarioAtualizado.Ativo)
                {
                    usuarioExistente.Ativo = usuarioAtualizado.Ativo;
                }

                await _usuarioService.AtualizarUsuario(usuarioExistente);

                return Ok("Usuário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar usuário: {ex.Message}");
            }
        }

    }
   
}
