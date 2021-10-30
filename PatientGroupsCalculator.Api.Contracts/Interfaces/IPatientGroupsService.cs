using PatientGroupsCalculator.Api.Contracts.Models;

namespace PatientGroupsCalculator.Api.Contracts.Interfaces
{
    public interface  IPatientGroupsService
    {
        public Result<int> countPatientGroups(int[][] M);
    }
}
