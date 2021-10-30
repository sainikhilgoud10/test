namespace PatientGroupsCalculator.Api.Contracts.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PatientGroupsCalculator.Api.Contracts.Models;
    using System;

    public static class ResultExtensions
    {
        public static IActionResult GetHttpActionResult<T>(this Result<T> result)
        {
            return GetHttpActionResult<T>(result, null, null);
        }

        public static IActionResult GetHttpActionResult<T>(this Result<T> result, string routeName, object routeValues)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            ActionResult returnResult;

            switch (result.ResultCode)
            {
                case ResultCode.Ok:
                    {
                        return new OkObjectResult(result.NumberOfGroups);
                    }                

                case ResultCode.BadRequest:
                    {
                        returnResult = new BadRequestResult();
                        break;
                    }                
                default:
                    {
                        returnResult = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                        break;
                    }
            }

            return returnResult;
        }       
    }
}
