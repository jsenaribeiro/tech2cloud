public record SaleCreatedEvent(
    int SaleId,
    int BranchId,
    int CustomerId,
    DateTime SaleDate,
    decimal TotalAmount
);