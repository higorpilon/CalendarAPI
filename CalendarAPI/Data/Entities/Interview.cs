using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Data.Entities
{
    public class Interview
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
