namespace IndividualTaxCalculator.Application.Dtos;

public record TaxCalculationRequestDto(string PostalCode, decimal AnnualIncome);