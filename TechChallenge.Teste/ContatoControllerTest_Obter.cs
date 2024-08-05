using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFase1.Controllers;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallenge.Teste
{
    public class ContatoControllerTest_Obter
    {
        private readonly Mock<IContatoService> _mockContatoService;
        private readonly Mock<IBrasilApiService> _mockBrasilApiService;
        private readonly ContatoController _controller;

        public ContatoControllerTest_Obter()
        {
            _mockContatoService = new Mock<IContatoService>();
            _mockBrasilApiService = new Mock<IBrasilApiService>();
            _controller = new ContatoController(_mockContatoService.Object, _mockBrasilApiService.Object);

        }

        [Fact]
        public void ObterContato_RetornaOk()
        {
            //Arrange
            int DDD = 11;
            int Numero = 999999999;
            var contato = new Contatos
            {
                Nome = "fiap",
                DDD = DDD,
                Telefone = Numero,
                Email = "teste@teste.com"
            };

            _mockContatoService.Setup(service => service.ConsultarContato(DDD, Numero)).Returns(contato);

            //Act
            var result = _controller.obterContato(DDD, Numero);

            //Assert
            var retornaOk = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(contato, retornaOk.Value);
        }

        [Fact]
        public void ObterContato_Excecao()
        {
            //Arrange
            int DDD = 11;
            int Numero = 999999999;
            _mockContatoService.Setup(service => service.ConsultarContato(DDD, Numero)).Throws(new Exception("Erro simulado"));

            //Act and Assert
            var exception = Assert.Throws<Exception>(() => _controller.obterContato(DDD, Numero));
            Assert.Equal("Erro: Erro simulado", exception.Message);
        }


    }
}
