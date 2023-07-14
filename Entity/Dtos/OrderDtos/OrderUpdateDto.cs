
namespace Entity.Dtos.OrderDtos
{
    public record OrderUpdateDto
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public bool PaymentStatus { get; init; }
        public bool DeliveryStatus { get; init; }
    }
}
