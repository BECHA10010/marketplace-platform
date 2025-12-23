namespace Catalog.Infrastructure.Seeding;

public static class InitialData
{
    public static IEnumerable<Brand> Brands => 
    [
        Brand.Create(Guid.Parse("b0000001-0000-0000-0000-000000000001"), "Polaris"),
        Brand.Create(Guid.Parse("b0000001-0000-0000-0000-000000000002"), "Redmond"),
        Brand.Create(Guid.Parse("b0000001-0000-0000-0000-000000000003"), "Scarlett"),
        Brand.Create(Guid.Parse("b0000001-0000-0000-0000-000000000004"), "Золотое яблоко")
    ];
    
    public static IEnumerable<Category> Categories => 
    [
        Category.Create(Guid.Parse("c0000001-0000-0000-0000-000000000001"), "Бытовая техника"),
        Category.Create(Guid.Parse("c0000001-0000-0000-0000-000000000002"), "Электроника"),
        Category.Create(Guid.Parse("c0000001-0000-0000-0000-000000000003"), "Одежда"),
        Category.Create(Guid.Parse("c0000001-0000-0000-0000-000000000004"), "Детские товары"),
        Category.Create(Guid.Parse("c0000001-0000-0000-0000-000000000005"), "Косметика и уход")
    ];
    
    public static IEnumerable<CatalogItem> CatalogItems =>
    [
        CatalogItem.Create(
            Guid.Parse("a0000001-0000-0000-0000-000000000001"),
            "Мультиварка Redmond RMC-M90",
            "Умная мультиварка с 45 программами",
            Guid.Parse("b0000001-0000-0000-0000-000000000002"),
            Guid.Parse("c0000001-0000-0000-0000-000000000001"),
            5990m
        ),

        CatalogItem.Create(
            Guid.Parse("a0000001-0000-0000-0000-000000000002"),
            "Смартфон Scarlett VT-1234",
            "Бюджетный смартфон с хорошей камерой",
            Guid.Parse("b0000001-0000-0000-0000-000000000003"),
            Guid.Parse("c0000001-0000-0000-0000-000000000002"),
            8990m
        ),

        CatalogItem.Create(
            Guid.Parse("a0000001-0000-0000-0000-000000000003"),
            "Фен Polaris PHD 2077",
            "Компактный фен для волос",
            Guid.Parse("b0000001-0000-0000-0000-000000000001"),
            Guid.Parse("c0000001-0000-0000-0000-000000000001"),
            1790m
        ),

        CatalogItem.Create(
            Guid.Parse("a0000001-0000-0000-0000-000000000004"),
            "Электрочайник Scarlett SC-EK21",
            "Стильный чайник с подсветкой",
            Guid.Parse("b0000001-0000-0000-0000-000000000003"),
            Guid.Parse("c0000001-0000-0000-0000-000000000001"),
            1290m
        ),

        CatalogItem.Create(
            Guid.Parse("a0000001-0000-0000-0000-000000000010"),
            "Кофеварка Polaris PCM 1516E",
            "Капельная кофеварка 600 Вт",
            Guid.Parse("b0000001-0000-0000-0000-000000000001"),
            Guid.Parse("c0000001-0000-0000-0000-000000000001"),
            3290m
        )
    ];
}
