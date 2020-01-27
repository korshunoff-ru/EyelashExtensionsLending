using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyelashExtensionsLending.WebAPI.Models
{
    /// <summary>
    /// Order time entity
    /// </summary>
    [Table("OrdersTime")]
    public class OrderTime
    {

        #region Properties
        
        /// <summary>
        /// Order time identifier
        /// </summary>
        [Key]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        /// <summary>
        /// Order date
        /// </summary>
        [Key]
        public DateTime Date { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Order of this time
        /// </summary>
        public Order Order { get; set; }

        #endregion

    }


}
