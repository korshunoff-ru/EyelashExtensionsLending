using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyelashExtensionsLending.WebAPI.Models
{
    [Table("Services")]
    public class Service
    {

        #region Properties

        /// <summary>
        /// Service identifier
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        [Required, MinLength(4), MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// Service Description
        /// </summary>
        [Required, MinLength(4)]
        public string Description { get; set; }

        /// <summary>
        /// Service cost
        /// </summary>
        [Required]
        public float Cost { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Service orders
        /// </summary>
        public List<OrderService> OrderServices { get; set; }

        #endregion

    }


}
