using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Dtos;

public record TaxCalculationRequestDto(PostalCode PostalCode, Income AnnualIncome);