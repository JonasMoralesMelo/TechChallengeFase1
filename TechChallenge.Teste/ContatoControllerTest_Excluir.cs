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
    public class ContatoControllerTest_Excluir
    {
        private readonly Mock<IContatoService> _mockContatoService;
        private readonly Mock<IBrasilApiService> _mockBrasilApiService;
        private readonly ContatoController _controller;

        public ContatoControllerTest_Excluir()
        {
            _mockContatoService = new Mock<IContatoService>();
            _mockBrasilApiService = new Mock<IBrasilApiService>();
            _controller = new ContatoController(_mockContatoService.Object, _mockBrasilApiService.Object);

        }

        [Fact]
        public void ExcluirContato_RetornaOK()
        {
            //Arrange
            int DDD = 11;
            int Numero = 999999999;


            _mockContatoService.Setup(service => service.ExcluirContato(DDD, Numero));

            //Act
            var result = _controller.excluirContato(DDD, Numero);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Contato ({DDD}) {Numero} excluído com sucesso", okResult.Value);
            _mockContatoService.Verify(service => service.ExcluirContato(DDD, Numero), Times.Once);
        } 

        [Fact]
        public void ExcluirContato_Excecao()
        {
             //Arrange
             int DDD = 11;
             int Numero = 999999999;
             _mockContatoService.Setup(service => service.ExcluirContato(DDD, Numero)).Throws(new Exception("Erro simulado"));

             // Act and Assert
             var exception = Assert.Throws<Exception>(() => _controller.excluirContato(DDD, Numero));
             Assert.Equal("Erro: Erro simulado", exception.Message);
        }
    }
}
