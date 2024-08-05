using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFase1.Controllers;
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
    }
}
