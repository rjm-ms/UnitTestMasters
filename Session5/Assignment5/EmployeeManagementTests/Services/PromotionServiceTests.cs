﻿using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using Moq;
using Moq.Protected;
using System.Net;

namespace EmployeeManagement.Services.Tests
{
    public class PromotionServiceTests
    {
       
        [Fact()]
        public void PromoteInternalEmployee_Returns_EligibleForPromotion_True()
        {
            // Arrange
            var _mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("{\"eligibleForPromotion\":true}") });
            var _mockClient = new HttpClient(_mockHttpMessageHandler.Object);
            _mockEmployeeRepo.Setup(c => c.SaveChangesAsync()).Returns(() => Task.Run(() => { })).Verifiable();
            var sut = new PromotionService(_mockClient, _mockEmployeeRepo.Object);

            // Act
            var result = sut.PromoteInternalEmployeeAsync(new InternalEmployee { EmployeeId = 100, JobLevel = 1 });

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Result);
        }
    }
}