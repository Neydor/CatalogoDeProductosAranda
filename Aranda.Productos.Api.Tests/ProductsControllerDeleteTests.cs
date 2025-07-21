using Aranda.Productos.Api.Controllers;
using Aranda.Productos.Application.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Aranda.Productos.Api.Tests
{
    [TestClass]
    public class ProductsControllerDeleteTests
    {
        private Mock<IProductService> _mockProductService;
        private ProductsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _controller?.Dispose();
        }

        #region DeleteProduct Tests

        [TestMethod]
        public async Task DeleteProduct_WithExistingId_ReturnsNoContent()
        {
            // Arrange
            const int productId = 1;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            var statusResult = (StatusCodeResult)result;
            statusResult.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task DeleteProduct_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            const int productId = 999;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .ThrowsAsync(new KeyNotFoundException());

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public async Task DeleteProduct_SuccessfulDeletion_VerifiesServiceCall()
        {
            // Arrange
            const int productId = 5;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            await _controller.DeleteProduct(productId);

            // Assert
            _mockProductService.Verify(s => s.DeleteProductAsync(productId), Times.Once);
            _mockProductService.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task DeleteProduct_WithZeroId_CallsService()
        {
            // Arrange
            const int productId = 0;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            var statusResult = (StatusCodeResult)result;
            statusResult.StatusCode.Should().Be(HttpStatusCode.NoContent);
            _mockProductService.Verify(s => s.DeleteProductAsync(productId), Times.Once);
        }

        [TestMethod]
        public async Task DeleteProduct_WithNegativeId_CallsService()
        {
            // Arrange
            const int productId = -1;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .ThrowsAsync(new KeyNotFoundException());

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            _mockProductService.Verify(s => s.DeleteProductAsync(productId), Times.Once);
        }

        [TestMethod]
        public async Task DeleteProduct_ServiceReturnsSuccessfully_EnsuresNoContentResponse()
        {
            // Arrange
            const int productId = 10;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            var statusResult = (StatusCodeResult)result;
            statusResult.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Verify the service was called exactly once
            _mockProductService.Verify(s => s.DeleteProductAsync(productId), Times.Once);
        }

        [TestMethod]
        public async Task DeleteProduct_MultipleCallsWithSameId_CallsServiceMultipleTimes()
        {
            // Arrange
            const int productId = 3;

            _mockProductService.Setup(s => s.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            await _controller.DeleteProduct(productId);
            await _controller.DeleteProduct(productId);

            // Assert
            _mockProductService.Verify(s => s.DeleteProductAsync(productId), Times.Exactly(2));
        }

        #endregion
    }
} 