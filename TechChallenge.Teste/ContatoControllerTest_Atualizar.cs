using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFase1.Controllers;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallenge.Teste
{
    public class ContatoControllerTest_Atualizar
    {
        private readonly Mock<IContatoService> _mockContatoService;
        private readonly Mock<IBrasilApiService> _mockBrasilApiService;
        private readonly ContatoController _controller;

        public ContatoControllerTest_Atualizar()
        {
            _mockContatoService = new Mock<IContatoService>();
            _mockBrasilApiService = new Mock<IBrasilApiService>();
            _controller = new ContatoController(_mockContatoService.Object, _mockBrasilApiService.Object);

        }

        [Fact]

        public void AtualizarContato_RetornaOk()
        {
            //Arrange
            var contato = new Contatos
            {
                Nome = "FiapAtualizado",
                DDD = 44,
                Telefone = 888888888,
                Email = "email@atualizado.com"
            };

            //Act
            var result = _controller.atualizarContato(contato);

            //Assert

            var retornaOk = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(contato, retornaOk.Value);
            _mockContatoService.Verify(service => service.AtualizarContato(contato), Times.Once);
        }

       
        [Fact]
        public void AtualizarContato_Excecao()
        {
            //Arrange
            var contato = new Contatos
            {
                Nome = "",
                DDD = 555,
                Telefone = 98765,
                Email = "emailInvalido"
            };

            _mockContatoService.Setup(service => service.AtualizarContato(contato)).Throws(new Exception("Erro simulado"));

            //Act and Assert
            var exception = Assert.Throws<Exception>(() => _controller.atualizarContato(contato));
            Assert.Equal("Erro: Erro simulado", exception.Message);
            _mockContatoService.Verify(service => service.AtualizarContato(contato), Times.Once);
        }
    }
}
