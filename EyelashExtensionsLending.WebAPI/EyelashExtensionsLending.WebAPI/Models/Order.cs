using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyelashExtensionsLending.WebAPI.Models
{
    [Table("Orders")]
    public class Order
    {

        #region Properties

        /// <summary>
        /// Order identifier
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Client identifier
        /// </summary>
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        /// <summary>
        /// Comment on the order
        /// </summary>
        [StringLength(256)]
        public string Comment { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Order client
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Service order
        /// </summary>
        public List<OrderService> OrderServices { get; set; }

        /// <summary>
        /// Time order
        /// </summary>
        public List<OrderTime> OrdersTime { get; set; }

        #endregion

    }


}
