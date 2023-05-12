using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Domain
{
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ErrorId { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }

        public string StackTrace { get; set; }
        [StringLength(100)]
        public string ErrorType { get; set; }
        public DateTime DateCreated
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}

