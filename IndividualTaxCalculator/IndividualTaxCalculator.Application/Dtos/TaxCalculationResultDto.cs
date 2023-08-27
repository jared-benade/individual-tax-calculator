namespace IndividualTaxCalculator.Application.Dtos;

public record TaxCalculationResultDto(decimal AnnualIncome, string PostalCode, decimal TaxAmount);