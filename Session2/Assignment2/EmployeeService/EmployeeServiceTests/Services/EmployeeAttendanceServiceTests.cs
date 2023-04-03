using EmployeeService.Interface;
using EmployeeService.Repository.Interface;
using Moq;
using Xunit;

namespace EmployeeService.Services.Tests
{
    public class EmployeeAttendanceServiceTests
    {
        private Mock<IEmployeeAttendanceRepo> _mockEmployeeAttendanceRepo;
        private Mock<IEmployeeService> _mockEmployeeService;
        private EmployeeAttendanceService _employeeAttendanceService;

        public EmployeeAttendanceServiceTests()
        {
            _mockEmployeeAttendanceRepo = new Mock<IEmployeeAttendanceRepo>();
            _mockEmployeeService = new Mock<IEmployeeService>();
            _employeeAttendanceService = new EmployeeAttendanceService(_mockEmployeeAttendanceRepo.Object, _mockEmployeeService.Object);
        }

        [Fact()]
        public void SaveAttendanceTest_Success()
        {
            // Arrange
            int employeeId = 1;
            _mockEmployeeService.Setup(x => x.EmployeeExist(employeeId)).Returns(true);
            _mockEmployeeAttendanceRepo.Setup(x => x.SaveInOut(employeeId)).Returns(true);

            // Act
            var result = _employeeAttendanceService.SaveAttendance(employeeId);

            // Assert 
            Assert.True(result);
            _mockEmployeeAttendanceRepo.Verify(s => s.SaveInOut(employeeId), Times.Once);
        }

        [Fact()]
        public void SaveInOutTest_Failed()
        {
            // Arrange
            int employeeId = 1;
            _mockEmployeeService.Setup(x => x.EmployeeExist(employeeId)).Returns(false);

            // Act
            var result = _employeeAttendanceService.SaveAttendance(employeeId);

            // Assert 
            Assert.False(result);
            _mockEmployeeAttendanceRepo.Verify(s => s.SaveInOut(employeeId), Times.Never);
        }
    }
}