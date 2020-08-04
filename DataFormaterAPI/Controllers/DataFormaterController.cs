using DataFormaterAPI.Common;
using DataFormaterAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataFormaterAPI.Controllers
{
    [Route(RouteConstants.ROUTE_PREFIX)]
    public class DataFormaterController : ControllerBase
    {
        #region Public Methods
        /// <summary>
        /// Format Data
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route(RouteConstants.Format_Data)]
        [ProducesResponseType(200, Type = typeof(List<ResponseData>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public  IActionResult FormatData([FromBody] List<INPUTDATA> requestData)
        {
            if (requestData != null && requestData.Count>0)
            {
                // Validate Created Date
                var isValidDate = requestData.TrueForAll(p => DateTime.TryParseExact(p.CreatedDate, "dd/MMM/yy", System.Globalization.CultureInfo.InvariantCulture,
                      DateTimeStyles.None, out DateTime createdDate));

                if (isValidDate)
                {
                    if (ModelState.IsValid)
                    {
                        return Ok(FormateData(requestData));
                     }
                    else
                    {
                        return BadRequest("Input Data is not valid");
                    }
                }
                else
                {
                    return BadRequest("Created Date is not valid");
                }
            }
            else

            {
                return BadRequest("Input Data is not valid");
            }

        }


        [HttpGet]
        [Produces("text/html")]
        public string Get()
        {
            string output = "<h1 style=\"color: blue; \">Please <a style=\"color: green; \" href='http://localhost:50684/swagger/index.html'>Click Here </a>  to check POC</h1>";
            return output;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Format Input Data
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns>List<ResponseData></returns>
        private List<ResponseData> FormateData(List<INPUTDATA> requestData)
        {
            // for sorting data becouse request data is string so sorting will be not done properly
            requestData.ForEach(p => { p.CreatedDateForSorting = Convert.ToDateTime(p.CreatedDate); p.TicketIDForSorting = Convert.ToInt32(p.TicketID); });
        
            List<ResponseData> outputData = new List<ResponseData>();
            var groupedData = requestData.GroupBy(p => p.Type);
            foreach (var item in groupedData)
            {
                var responseData = new ResponseData
                {
                    Type = item.Key,

                };
                responseData.Tickets = new List<Tickets>();
                List<INPUTDATA> sortedData = new List<INPUTDATA>();
                if (item.GroupBy(p => p.CreatedDate).Count() < item.Count())
                {
                    sortedData = item.OrderBy(p => p.TicketIDForSorting).ToList();
                }
                else
                {
                    sortedData = item.OrderByDescending(p => p.CreatedDateForSorting).ToList();
                }

                foreach (var data in sortedData)
                {
                    Tickets ticket = new Tickets
                    {
                        CreatedDate = data.CreatedDate,
                        Status = data.Status,
                        Summary = data.Summary,
                        TicketID = data.TicketID
                    };
                    responseData.Tickets.Add(ticket);

                }

                outputData.Add(responseData);
            }

            return outputData;

        }
        #endregion
    }
}