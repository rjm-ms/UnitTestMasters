using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagement.Controllers.Tests
{
    public class PromotionsControllerTests
    {
        [Fact()]
        public void CreatePromotion_InternalEmployee_Returns_Created()
        {
            // Arrange
            var _stubEmployeeService = new Mock<IEmployeeService>();
            var _mockPromotionService = new Mock<IPromotionService>();
            var sut = new PromotionsController(_stubEmployeeService.Object, _mockPromotionService.Object);
            var internalEmployeeToPromote = new InternalEmployee
            {
                EmployeeId = 1,
                JobLevel = 12
            };
            var promotionForCreation = new PromotionForCreationDto
            {
                EmployeeId = 1
            };

            _stubEmployeeService.Setup(x => x.FetchInternalEmployeeAsync(1)).ReturnsAsync(internalEmployeeToPromote);
            _mockPromotionService.Setup(x => x.PromoteInternalEmployeeAsync(internalEmployeeToPromote)).ReturnsAsync(true);

            // Act
            var result = (OkObjectResult)sut.CreatePromotion(promotionForCreation).Result;
            var promotionResultDto = (PromotionResultDto)result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(internalEmployeeToPromote.EmployeeId, promotionResultDto.EmployeeId);
            Assert.Equal(internalEmployeeToPromote.JobLevel, promotionResultDto.JobLevel);
        }
    }
}