using Aranda.Productos.Api.Controllers;
using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Application.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Aranda.Productos.Api.Tests
{
    [TestClass]
    public class ProductsControllerCreateTests
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

        #region CreateProduct Tests

        [TestMethod]
        public async Task CreateProduct_WithValidDto_ReturnsCreatedAtRouteWithProduct()
        {
            // Arrange
            var createDto = new CreateProductDto
            {
                Nombre = "New Product",
                Descripcion = "New Description",
                CategoriaId = 1,
                Imagen = "image.jpg"
            };

            var createdProduct = new ProductDto
            {
                Id = 1,
                Nombre = createDto.Nombre,
                Descripcion = createDto.Descripcion,
                Categoria = "Test Category",
                Imagen = createDto.Imagen
            };

            _mockProductService.Setup(s => s.AddProductAsync(createDto))
                .ReturnsAsync(createdProduct);

            // Act
            var result = await _controller.CreateProduct(createDto);

            // Assert
            result.Should().BeOfType<CreatedAtRouteNegotiatedContentResult<ProductDto>>();
            var createdResult = (CreatedAtRouteNegotiatedContentResult<ProductDto>)result;
            
            createdResult.RouteName.Should().Be("GetProductById");
            createdResult.RouteValues.Should().ContainKey("id").WhoseValue.Should().Be(createdProduct.Id);
            createdResult.Content.Should().Be(createdProduct);
            createdResult.Content.Id.Should().Be(1);
            createdResult.Content.Nombre.Should().Be(createDto.Nombre);
        }

        [TestMethod]
        public async Task CreateProduct_WithInvalidDto_ReturnsBadRequest()
        {
            // Arrange
            var createDto = new CreateProductDto
            {
                Nombre = "Invalid Product",
                Descripcion = "Invalid Description",
                CategoriaId = -1, // Invalid category
                Imagen = "image.jpg"
            };

            _mockProductService.Setup(s => s.AddProductAsync(createDto))
                .ThrowsAsync(new ArgumentException("Invalid category ID"));

            // Act
            var result = await _controller.CreateProduct(createDto);

            // Assert
            result.Should().BeOfType<BadRequestErrorMessageResult>();
            var badRequestResult = (BadRequestErrorMessageResult)result;
            badRequestResult.Message.Should().Be("Invalid category ID");
        }

        [TestMethod]
        public async Task CreateProduct_ServiceThrowsArgumentException_ReturnsBadRequestWithMessage()
        {
            // Arrange
            var createDto = new CreateProductDto
            {
                Nombre = "Test Product",
                Descripcion = "Test Description",
                CategoriaId = 1,
                Imagen = "image.jpg"
            };

            const string exceptionMessage = "Product with this name already exists";
            _mockProductService.Setup(s => s.AddProductAsync(createDto))
                .ThrowsAsync(new ArgumentException(exceptionMessage));

            // Act
            var result = await _controller.CreateProduct(createDto);

            // Assert
            result.Should().BeOfType<BadRequestErrorMessageResult>();
            var badRequestResult = (BadRequestErrorMessageResult)result;
            badRequestResult.Message.Should().Be(exceptionMessage);
        }

        [TestMethod]
        public async Task CreateProduct_WithNullDto_CallsServiceAndHandlesResponse()
        {
            // Arrange
            CreateProductDto createDto = null;
            var createdProduct = new ProductDto { Id = 1 };

            _mockProductService.Setup(s => s.AddProductAsync(createDto))
                .ReturnsAsync(createdProduct);

            // Act
            var result = await _controller.CreateProduct(createDto);

            // Assert
            result.Should().BeOfType<CreatedAtRouteNegotiatedContentResult<ProductDto>>();
            _mockProductService.Verify(s => s.AddProductAsync(createDto), Times.Once);
        }

        [TestMethod]
        public async Task CreateProduct_SuccessfulCreation_VerifiesServiceCall()
        {
            // Arrange
            var createDto = new CreateProductDto
            {
                Nombre = "Verification Product",
                Descripcion = "Verification Description",
                CategoriaId = 2,
                Imagen = "verify.jpg"
            };

            var createdProduct = new ProductDto { Id = 5 };

            _mockProductService.Setup(s => s.AddProductAsync(createDto))
                .ReturnsAsync(createdProduct);

            // Act
            await _controller.CreateProduct(createDto);

            // Assert
            _mockProductService.Verify(s => s.AddProductAsync(createDto), Times.Once);
            _mockProductService.VerifyNoOtherCalls();
        }

        #endregion
    }
} 