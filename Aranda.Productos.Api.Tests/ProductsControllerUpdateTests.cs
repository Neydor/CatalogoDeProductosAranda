using Aranda.Productos.Api.Controllers;
using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Application.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Aranda.Productos.Api.Tests
{
    [TestClass]
    public class ProductsControllerUpdateTests
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

        #region UpdateProduct Tests

        [TestMethod]
        public async Task UpdateProduct_WithValidIdAndDto_ReturnsNoContent()
        {
            // Arrange
            const int productId = 1;
            var updateDto = new UpdateProductDto
            {
                Nombre = "Updated Product",
                Descripcion = "Updated Description",
                CategoriaId = 2,
                Imagen = "updated.jpg"
            };

            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            var statusResult = (StatusCodeResult)result;
            statusResult.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task UpdateProduct_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            const int productId = 999;
            var updateDto = new UpdateProductDto
            {
                Nombre = "Updated Product",
                Descripcion = "Updated Description",
                CategoriaId = 1,
                Imagen = "updated.jpg"
            };

            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .ThrowsAsync(new KeyNotFoundException());

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public async Task UpdateProduct_WithInvalidData_ReturnsBadRequest()
        {
            // Arrange
            const int productId = 1;
            var updateDto = new UpdateProductDto
            {
                Nombre = "", // Invalid empty name
                Descripcion = "Updated Description",
                CategoriaId = 1,
                Imagen = "updated.jpg"
            };

            const string exceptionMessage = "Product name cannot be empty";
            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .ThrowsAsync(new ArgumentException(exceptionMessage));

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<BadRequestErrorMessageResult>();
            var badRequestResult = (BadRequestErrorMessageResult)result;
            badRequestResult.Message.Should().Be(exceptionMessage);
        }

        [TestMethod]
        public async Task UpdateProduct_ServiceThrowsArgumentException_ReturnsBadRequestWithMessage()
        {
            // Arrange
            const int productId = 1;
            var updateDto = new UpdateProductDto
            {
                Nombre = "Test Product",
                Descripcion = "Test Description",
                CategoriaId = -1, // Invalid category
                Imagen = "test.jpg"
            };

            const string exceptionMessage = "Invalid category ID";
            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .ThrowsAsync(new ArgumentException(exceptionMessage));

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<BadRequestErrorMessageResult>();
            var badRequestResult = (BadRequestErrorMessageResult)result;
            badRequestResult.Message.Should().Be(exceptionMessage);
        }

        [TestMethod]
        public async Task UpdateProduct_SuccessfulUpdate_VerifiesServiceCall()
        {
            // Arrange
            const int productId = 3;
            var updateDto = new UpdateProductDto
            {
                Nombre = "Verification Product",
                Descripcion = "Verification Description",
                CategoriaId = 2,
                Imagen = "verify.jpg"
            };

            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .Returns(Task.CompletedTask);

            // Act
            await _controller.UpdateProduct(productId, updateDto);

            // Assert
            _mockProductService.Verify(s => s.UpdateProductAsync(productId, updateDto), Times.Once);
            _mockProductService.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task UpdateProduct_WithNullDto_CallsServiceAndHandlesResponse()
        {
            // Arrange
            const int productId = 1;
            UpdateProductDto updateDto = null;

            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            var statusResult = (StatusCodeResult)result;
            statusResult.StatusCode.Should().Be(HttpStatusCode.NoContent);
            _mockProductService.Verify(s => s.UpdateProductAsync(productId, updateDto), Times.Once);
        }

        [TestMethod]
        public async Task UpdateProduct_WithZeroId_CallsService()
        {
            // Arrange
            const int productId = 0;
            var updateDto = new UpdateProductDto
            {
                Nombre = "Test Product",
                Descripcion = "Test Description",
                CategoriaId = 1,
                Imagen = "test.jpg"
            };

            _mockProductService.Setup(s => s.UpdateProductAsync(productId, updateDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateProduct(productId, updateDto);

            // Assert
            result.Should().BeOfType<StatusCodeResult>();
            _mockProductService.Verify(s => s.UpdateProductAsync(productId, updateDto), Times.Once);
        }

        #endregion
    }
} 