using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientGroupsCalculator.Api.Contracts.Interfaces;
using PatientGroupsCalculator.Api.Contracts.Models;
using PatientGroupsCalculator.Controllers;
using Xunit;

namespace PatientGroupsCalculator.Api.Tests
{
    public class PatientGroupsControllerTests
    {
        private readonly PatientGroupCalculatorController patientGroupCalculatorController;

        private readonly Mock<IPatientGroupsService> patientGroupsService;

        public PatientGroupsControllerTests()
        {
            this.patientGroupsService = new Mock<IPatientGroupsService>();
            this.patientGroupCalculatorController = new PatientGroupCalculatorController(this.patientGroupsService.Object);
        }

        [Fact]
        public void CalculateSuccess()
        {
            Result<int> mockResult = new Result<int>();
            mockResult.ResultCode = ResultCode.Ok;
            mockResult.NumberOfGroups = 5;            
            this.patientGroupsService.Setup(x => x.countPatientGroups(null)).Returns(mockResult);
            var result = this.patientGroupCalculatorController.Calculate(null);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
