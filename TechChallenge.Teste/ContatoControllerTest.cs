
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
    public class ContatoControllerTest
    {
        Mock<ContatoContext> _mockContext;
        ContatoController _controller;
        IContatoService _contatoService;
        IBrasilApiService _brasilApiService;
        public ContatoControllerTest()
        {
            var contatos = new List<Contatos>() {
                new Contatos() {
                    Id = Guid.NewGuid(),
                    Nome = "Fiap Contato",
                    DDD = 21,
                    Telefone = 992345678,
                    Email = "fiapaluno@gmail.com"
                }
            };

            var mock = contatos.AsQueryable().BuildMockDbSet();

            var options = new DbContextOptionsBuilder<ContatoContext>()
            .UseInMemoryDatabase(databaseName: "ContatoServiceTest")
            .Options;

            _mockContext = new Mock<ContatoContext>(options);
            _mockContext.Setup(c => c.Contatos).Returns(mock.Object);

            _contatoService = new ContatoService(_mockContext.Object);
            _brasilApiService = new BrasilApiService();
            _controller = new ContatoController(_contatoService, _brasilApiService);
        }

        [Fact]
        public void Adicionar_Contato_Sucesso()
        {
            Contatos contato = new Contatos()
            { 
                Id = Guid.NewGuid(),
                Nome = "Fiap Contato",
                DDD = 21,
                Telefone = 992345678,
                Email = "fiapaluno@gmail.com"
            };

            var response = _controller.adicionarContato(contato);
            var createdContato = response as CreatedAtActionResult;
            var contatoItem = createdContato.Value as Contatos;

            Assert.IsType<CreatedAtActionResult>(response);
            Assert.IsType<Contatos>(createdContato.Value);

            Assert.Equal(contato.Id, contatoItem.Id);
            Assert.Equal(contato.Nome, contatoItem.Nome);
            Assert.Equal(contato.DDD, contatoItem.DDD);
            Assert.Equal(contato.Telefone, contatoItem.Telefone);
            Assert.Equal(contato.Email, contatoItem.Email);
        }
    }
}