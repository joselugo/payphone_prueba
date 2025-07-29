using Moq;
using Xunit;
using Wallet.Application.Features.Wallets.Commands.CreateWallet;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Tests.Application.Features.Wallets
{
    public class CreateWalletCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsWalletId()
        {
            // Arrange
            var mockRepo = new Mock<IWalletRepository>();
            var handler = new CreateWalletCommandHandler(mockRepo.Object);

            var command = new CreateWalletCommand
            {
                DocumentId = "DOC123",
                Name = "Jose Lugo",
                InitialBalance = 1000
            };

            // Simular que EF asigna ID después de guardar
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Entities.Wallet>()))
                    .Callback<Entities.Wallet>(w => w.Id = 10)
                    .Returns(Task.CompletedTask);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(10, result);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Entities.Wallet>()), Times.Once);
        }
    }
}
