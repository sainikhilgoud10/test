namespace PatientGroupsCalculator.Api.Contracts.Models
{
    public class Result<T>
    {
        public ResultCode ResultCode { get; set; }

        public T NumberOfGroups { get; set; }
    }
}
