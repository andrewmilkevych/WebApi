using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1,1000000)]
        public int Price { get; init; }
    }
}
