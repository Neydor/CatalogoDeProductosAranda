using Aranda.Productos.Api.Controllers;
using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Application.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Aranda.Productos.Api.Tests
{
    [TestClass]
    public class ProductsControllerTest
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

        #region Constructor Tests

        [TestMethod]
        public void Constructor_WithValidProductService_CreatesInstance()
        {
            // Act
            var controller = new ProductsController(_mockProductService.Object);

            // Assert
            controller.Should().NotBeNull();
        }

        #endregion

        #region GetProducts Tests

        [TestMethod]
        public async Task GetProducts_WithValidParameters_ReturnsOkWithPagedResponse()
        {
            // Arrange
            var queryParameters = new ProductQueryParameters { Page = 1, PageSize = 10 };
            var products = CreateSampleProducts();
            var pagedResponse = new PagedResponse<ProductDto>(products, 2, 1, 10);

            _mockProductService.Setup(s => s.GetProductsAsync(queryParameters))
                .ReturnsAsync(pagedResponse);

            // Act
            var result = await _controller.GetProducts(queryParameters);

            // Assert
            result.Should().BeOfType<OkNegotiatedContentResult<PagedResponse<ProductDto>>>();
            var okResult = (OkNegotiatedContentResult<PagedResponse<ProductDto>>)result;
            okResult.Content.Should().Be(pagedResponse);
            okResult.Content.Data.Should().HaveCount(2);
        }

        [TestMethod]
        public async Task GetProducts_WithNullParameters_CreatesDefaultParametersAndReturnsOk()
        {
            // Arrange
            var products = CreateSampleProducts();
            var pagedResponse = new PagedResponse<ProductDto>(products, 2, 1, 10);

            _mockProductService.Setup(s => s.GetProductsAsync(It.IsAny<ProductQueryParameters>()))
                .ReturnsAsync(pagedResponse);

            // Act
            var result = await _controller.GetProducts(null);

            // Assert
            result.Should().BeOfType<OkNegotiatedContentResult<PagedResponse<ProductDto>>>();
            _mockProductService.Verify(s => s.GetProductsAsync(It.IsAny<ProductQueryParameters>()), Times.Once);
        }

        #endregion

        #region GetProduct Tests

        [TestMethod]
        public async Task GetProduct_WithExistingId_ReturnsOkWithProduct()
        {
            // Arrange
            const int productId = 1;
            var product = new ProductDto
            {
                Id = productId,
                Nombre = "Test Product",
                Descripcion = "Test Description",
                Categoria = "Test Category"
            };

            _mockProductService.Setup(s => s.GetProductByIdAsync(productId))
                .ReturnsAsync(product);

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            result.Should().BeOfType<OkNegotiatedContentResult<ProductDto>>();
            var okResult = (OkNegotiatedContentResult<ProductDto>)result;
            okResult.Content.Should().Be(product);
            okResult.Content.Id.Should().Be(productId);
        }

        [TestMethod]
        public async Task GetProduct_WithNonExistingId_ReturnsNotFound()
        {
            // Arrange
            const int productId = 999;
            _mockProductService.Setup(s => s.GetProductByIdAsync(productId))
                .ReturnsAsync((ProductDto)null);

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        #endregion

        #region Helper Methods

        private List<ProductDto> CreateSampleProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    Nombre = "Product 1",
                    Descripcion = "Description 1",
                    Categoria = "Category 1"
                },
                new ProductDto
                {
                    Id = 2,
                    Nombre = "Product 2",
                    Descripcion = "Description 2",
                    Categoria = "Category 2"
                }
            };
        }

        #endregion
    }
}
