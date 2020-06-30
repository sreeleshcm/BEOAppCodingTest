using System;
using System.ComponentModel.DataAnnotations;

namespace BEOAppCodingTest.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
