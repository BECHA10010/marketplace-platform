namespace Catalog.Domain.Specifications;

public record QueryArgs(
    int PageIndex = 1,
    int PageSize = 5,
    Guid? BrandId = null,
    Guid? CategoryId = null,
    string? Search = null)
{
    private const int MaxPageSize = 25;

    /// <summary>
    /// Сортировка по полю и его направлению.<br/>
    /// Возможные значения:
    /// - price_asc - по возрастанию цены
    /// - price_desc - по убыванию цены
    /// - title_asc - по возрастанию названия
    /// - title_desc - по убыванию названия
    /// </summary>
    public string? Sort { get; init; }
    
    public int PageSize { get; init; } = PageSize > MaxPageSize ? MaxPageSize : PageSize;
}