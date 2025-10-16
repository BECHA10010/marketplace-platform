namespace Basket.API.Infrastructure.Configurations;

public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItemEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder.ToTable("ShoppingCartItems");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Price).IsRequired();
    }
}