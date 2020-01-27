using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyelashExtensionsLending.WebAPI.Models
{
    [Table("Clients")]
    public class Client
    {

        #region Properties

        /// <summary>
        /// Client identifier
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Last name of client
        /// </summary>
        [Required, MinLength(4), MaxLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// First name of client
        /// </summary>
        [Required, MinLength(4), MaxLength(64)]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of client
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Phone number of client
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Client orders
        /// </summary>
        public List<Order> Orders { get; set; }

        #endregion

    }


}
