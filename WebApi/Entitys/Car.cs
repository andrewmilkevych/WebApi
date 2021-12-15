using System;
namespace WebApi.Entitys
{
    public record Car
    {
        public Guid Id { get; init; }
        public string? Mark { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
