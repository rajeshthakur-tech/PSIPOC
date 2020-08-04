using System.Collections.Generic;

namespace DataFormaterAPI.Entity
{
    public class ResponseData
    {
        /// <summary>
        /// Get or Set Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Get or Set Tickets
        /// </summary>
        public List<Tickets> Tickets { get; set; }
    }

    public class Tickets
    {
        /// <summary>
        /// Get or Set TicketID
        /// </summary>
        public string TicketID { get; set; }
        /// <summary>
        /// Get or Set Summary
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Get or Set Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Get or Set CreatedDate
        /// </summary>
        public string CreatedDate { get; set; }

    }
}
