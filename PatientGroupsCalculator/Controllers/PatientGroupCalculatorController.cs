using Microsoft.AspNetCore.Mvc;
using PatientGroupsCalculator.Api.Contracts.Interfaces;
using PatientGroupsCalculator.Api.Contracts.Models;
using System.Linq;

namespace PatientGroupsCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientGroupCalculatorController : ControllerBase
    {
        private readonly IPatientGroupsService patientService;

        public PatientGroupCalculatorController(IPatientGroupsService patientGroupsService)
        {
            patientService = patientGroupsService;
        }

        [HttpPost("[action]")]
        public IActionResult Calculate([FromBody] PatientsGrid patientsGrid)
        {
            var result = this.patientService.countPatientGroups(patientsGrid.matrix.Select(a => a.ToArray()).ToArray());
            return new ObjectResult(result);
        }
    }
}
