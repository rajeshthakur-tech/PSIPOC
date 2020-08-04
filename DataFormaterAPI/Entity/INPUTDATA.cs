using System;
using System.ComponentModel.DataAnnotations;

namespace DataFormaterAPI.Entity
{
    public class INPUTDATA
    {
        /// <summary>
        /// Get or Set TicketID
        /// </summary>
        [Required]
        public string TicketID { get; set; }
        /// <summary>
        /// Get or Set Type
        /// </summary>
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// Get or Set Summary
        /// </summary>
        [Required]
        public string Summary { get; set; }
        /// <summary>
        /// Get or Set Status
        /// </summary>
        [Required]
        public string Status { get; set; }
        /// <summary>
        /// Get or Set CreatedDate
        /// </summary>
        [Required]
        public string CreatedDate { get; set; }
        /// <summary>
        /// Get or Set CreatedDateForSorting
        /// </summary>
        public DateTime CreatedDateForSorting { get; set; }
        /// <summary>
        /// Get or Set TicketIDForSorting
        /// </summary>
        public int TicketIDForSorting { get; set; }
    }
}
