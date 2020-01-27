using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyelashExtensionsLending.WebAPI.Models
{
    [Table("OrderServices")]
    public class OrderService
    {

        #region Properties

        /// <summary>
        /// Service identifier
        /// </summary>
        [Key]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        /// <summary>
        /// Order identifier
        /// </summary>
        [Key]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Service order
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Order service
        /// </summary>
        public Order Order { get; set; }

        #endregion

    }


}
