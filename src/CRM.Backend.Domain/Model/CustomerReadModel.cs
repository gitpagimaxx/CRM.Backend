namespace CRM.Backend.Domain.Model;

public record CustomerReadModel(
    Guid Id,
    string CustomerType,
    string Name,
    string Document,
    string Email,
    DateOnly? BirthDate,
    string? CompanyName,
    string? StateRegistration,
    string? ZipCode,
    string? Street,
    string? Number,
    string? Complement,
    string? Neighborhood,
    string? City,
    string? State,
    string Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);