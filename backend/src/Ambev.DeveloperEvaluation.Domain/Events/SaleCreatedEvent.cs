public record SaleCreatedEvent(
    Guid SaleId,
    DateTime SaleDate,
    Guid CustomerId,
    Guid BranchId,
    decimal TotalAmount
);