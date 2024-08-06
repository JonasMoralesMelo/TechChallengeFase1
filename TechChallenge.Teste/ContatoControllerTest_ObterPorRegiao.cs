using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFase1.Controllers;
using TechChallengeFase1.Models.DTO;
using TechChallengeFase1.Models.Entity;
using TechChallengeFase1.Services.Interfaces;

namespace TechChallenge.Teste
{
    public class ContatoControllerTest_ObterPorRegiao
    {
        private readonly Mock<IContatoService> _mockContatoService;
        private readonly Mock<IBrasilApiService> _mockBrasilApiService;
        private readonly ContatoController _controller;

        public ContatoControllerTest_ObterPorRegiao()
        {
            _mockContatoService = new Mock<IContatoService>();
            _mockBrasilApiService = new Mock<IBrasilApiService>();
            _controller = new ContatoController(_mockContatoService.Object, _mockBrasilApiService.Object);

        }

        [Fact]
        public void ObterContatoPorRegiao_RetornaOk()
        {
            //Arrange
            int DDD = 11;
            int Numero = 999999999;

            var contato = new Contatos()
            {
                Nome = "fiap",
                DDD = DDD,
                Telefone = Numero,
                Email = "teste@teste.com"
            };

            List<Contatos> listaContatos = new();
            listaContatos.Add(contato);
            List<ContatosDTO> listaContatosDto = new();
            listaContatosDto.Add(new ContatosDTO(contato, It.IsAny<string>()));

            _mockContatoService.Setup(service => service.ConsultarContatoPorDDD(DDD)).Returns(listaContatos);
            _mockBrasilApiService.Setup(service => service.buscarRegiaoPorContato(listaContatos)).Returns(listaContatosDto);

            //Act
            var result = _controller.obterContatoRegiao(DDD);

            //Assert
            var retornaOk = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(listaContatosDto, retornaOk.Value);
            _mockBrasilApiService.Verify(service => service.buscarRegiaoPorContato(listaContatos), Times.Once);

        }

        [Fact]
        public void ObterContatoPorRegiao_Excecao()
        {
            //Arrange
            int DDD = 11;
            int Numero = 999999999;

            var contato = new Contatos()
            {
                Nome = "fiap",
                DDD = DDD,
                Telefone = Numero,
                Email = "teste@teste.com"
            };

            List<Contatos> listaContatos = new();
            listaContatos.Add(contato);
            List<ContatosDTO> listaContatosDto = new();
            listaContatosDto.Add(new ContatosDTO(contato, It.IsAny<string>()));

            _mockContatoService.Setup(service => service.ConsultarContatoPorDDD(DDD)).Returns(listaContatos);
            _mockBrasilApiService.Setup(service => service.buscarRegiaoPorContato(listaContatos)).Throws(new Exception("Erro simulado"));

            //Act
            var exception = Assert.Throws<Exception>(() => _controller.obterContatoRegiao(DDD));

            //Assert

            Assert.Equal("Erro: Erro simulado", exception.Message);
        }
    }
}
