
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockQueryable.Moq;
using Moq;
using System.Text;
using TechChallengeFase1.Controllers;
using TechChallengeFase1.Data;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services;
using TechChallengeFase1.Services.Interfaces;


namespace TechChallenge.Teste
{
    public class ContatoControllerTest_Adicionar
    {
        private readonly Mock<IContatoService> _mockContatoService;
        private readonly Mock<IBrasilApiService> _mockBrasilApiService;
        private readonly ContatoController _controller;

        public ContatoControllerTest_Adicionar()
        {
            _mockContatoService = new Mock<IContatoService>();
            _mockBrasilApiService = new Mock<IBrasilApiService>();
            _controller = new ContatoController(_mockContatoService.Object, _mockBrasilApiService.Object);

        }

        [Fact]

        public void AdicionarContato_ContatoValido()
        {
            //Arrange
            var contato = new Contatos
            {
                Nome = "fiap",
                DDD = 11,
                Telefone = 999999999,
                Email = "teste@teste.com"
            };
            _controller.ModelState.Clear();


            //Act
            var result = _controller.adicionarContato(contato);

            //Assert

            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal($"/api/Contato/{contato}", createdResult.Location);
            Assert.Equal(contato, createdResult.Value);
            _mockContatoService.Verify(service => service.AdicionarContato(contato), Times.Once);
        }

        [Fact]
        public void AdicionarContato_ContatoInvalido()
        {
            //Arrange
            var contato = new Contatos
            {
                Nome = "",
                DDD = 111,
                Telefone = 12128,
                Email = "açsdkçlkasdç"
            };
            _controller.ModelState.AddModelError("Nome", "O campo Nome é obrigatório");

            //Act
            var result = _controller.adicionarContato(contato);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
            _mockContatoService.Verify(service => service.AdicionarContato(It.IsAny<Contatos>()), Times.Never);
        }

        [Fact]
        public void AdicionarContato_Excecao()
        {
            //Arrange
            var contato = new Contatos
            {
                Nome = "Luana",
                DDD = 41,
                Telefone = 999999999,
                Email = "email.valido@example.com"
            };
            _mockContatoService.Setup(service => service.AdicionarContato(contato)).Throws(new Exception("Erro simulado"));

            //Act and Assert
            var exception = Assert.Throws<Exception>(() => _controller.adicionarContato(contato));
            Assert.Equal("Erro: Erro simulado", exception.Message);
        }
    }
}