using DataFormaterAPI.Controllers;
using DataFormaterAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace DataFormaterAPIUnitTest
{
    public class DataFormaterAPIUnitTest
    {
        List<INPUTDATA> validdata;

        List<INPUTDATA> dataWithInvalidDate;
        List<INPUTDATA> nodata;
        public DataFormaterAPIUnitTest()
        {
            SeedData();
        }
        private void SeedData()
        {
            validdata = new List<INPUTDATA>
            {
                new INPUTDATA() { Type = "Epic", CreatedDate = "09/Jul/19", Status = "In progress", Summary = "Dashboard View", TicketID = "3" },
                new INPUTDATA() { Type = "Story", CreatedDate = "16/Jul/19", Status = "Done", Summary = "Multiple API calls to fetch items for dashboard view", TicketID = "5" },
                new INPUTDATA() { Type = "Bug", CreatedDate = "18/Jul/19", Status = "Ready for Dev", Summary = "UI doesn't waits for all API calls to return a response before moving to next steps", TicketID = "15" },
                new INPUTDATA() { Type = "Story", CreatedDate = "17/Nov/19", Status = "Done", Summary = "Sort the dashboard items based on criticality", TicketID = "17" },
                new INPUTDATA() { Type = "Bug", CreatedDate = "22/Jul/19", Status = "Ready for Dev", Summary = "Dashboard UI sorts numbers as String - 100 and 111 listed before 2 and 22", TicketID = "34" },

                new INPUTDATA() { Type = "Story", CreatedDate = "20/Jul/19", Status = "In progress", Summary = "Apply locale specific language translation to dashboard items", TicketID = "9" },
                new INPUTDATA() { Type = "Story", CreatedDate = "20/Jul/19", Status = "Ready for Dev", Summary = "Apply appropriate color scheme to dashboard items based on criticality", TicketID = "10" }
            };
            dataWithInvalidDate = new List<INPUTDATA>
            {
                new INPUTDATA() { Type = "Epic", CreatedDate = "09/Jul/19", Status = "In progress", Summary = "Dashboard View", TicketID = "3" },
                new INPUTDATA() { Type = "Story", CreatedDate = "16/Jul/19DD", Status = "Done", Summary = "Multiple API calls to fetch items for dashboard view", TicketID = "5" },
                new INPUTDATA() { Type = "Bug", CreatedDate = "18/Jul/19", Status = "Ready for Dev", Summary = "UI doesn't waits for all API calls to return a response before moving to next steps", TicketID = "15" },
                new INPUTDATA() { Type = "Story", CreatedDate = "17/Nov/19", Status = "Done", Summary = "Sort the dashboard items based on criticality", TicketID = "17" },
                new INPUTDATA() { Type = "Bug", CreatedDate = "22/Jul/19", Status = "Ready for Dev", Summary = "Dashboard UI sorts numbers as String - 100 and 111 listed before 2 and 22", TicketID = "34" },

                new INPUTDATA() { Type = "Story", CreatedDate = "20/Jul/19", Status = "In progress", Summary = "Apply locale specific language translation to dashboard items", TicketID = "9" },
                new INPUTDATA() { Type = "Story", CreatedDate = "20/Jul/19", Status = "Ready for Dev", Summary = "Apply appropriate color scheme to dashboard items based on criticality", TicketID = "10" }
            };
            nodata = new List<INPUTDATA>{};
        }
        [Fact]
        public void FormatData_With_ValidInput()
        {
            var controller = new DataFormaterController();
            var data=controller.FormatData(validdata);
            Assert.IsType<OkObjectResult>(data);
        }
        
        [Fact]
        public void FormatData_With_InvalidDate()
        {
            var controller = new DataFormaterController();
            var data = controller.FormatData(dataWithInvalidDate);
            Assert.IsType<BadRequestObjectResult>(data);
        }
        [Fact]
        public void FormatData_With_NullInputData()
        {
            var controller = new DataFormaterController();
            var data = controller.FormatData(nodata);
            Assert.IsType<BadRequestObjectResult>(data);
        }
    }
}
