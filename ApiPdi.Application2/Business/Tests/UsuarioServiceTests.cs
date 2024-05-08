using ApiPdi.Application2.Domain.Models;
using ApiPdi.Application2.IRepository;
using Moq;
using Xunit;

namespace ApiPdi.Application2.Business.Tests
{
    public class UsuarioServiceTests
    {
        [Fact]
        public async Task BuscarPorId_DeveRetornarUsuarioQuandoExiste()
        {
            int id = 1;
            var usuario = new Usuario(id, "João", "Silva", "Endereço", 123, "123456789", "joao@example.com", "S");
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(usuario);
            var usuarioService = new UsuarioService(usuarioRepositoryMock.Object);

            // Act
            var resultado = await usuarioService.BuscarPorId(id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(id, resultado.Id);


        }
        [Fact]
        public async Task Buscartodos_DeveRetornarListaDeUsuarios()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario(1, "João", "Silva", "Endereço 1", 123, "123456789", "joao@example.com", "S"),
                new Usuario(2, "Maria", "Santos", "Endereço 2", 456, "987654321", "maria@example.com", "S")
            };
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(repo => repo.Buscartodos()).ReturnsAsync(usuarios);
            var usuarioService = new UsuarioService(usuarioRepositoryMock.Object);

            // Act
            var resultado = await usuarioService.Buscartodos();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(usuarios.Count, resultado.Count);
        }
    }
}
