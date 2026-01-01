namespace Basket.API.Infrastructure.Persistence.Configurations;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("Carts");
        
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.AccountName).IsUnique();

        builder.Property(x => x.AccountName)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Ignore(x => x.Items);
        
        builder.OwnsMany<CartItem>("_items", item =>
        {
            item.ToTable("CartItems");
            
            item.WithOwner().HasForeignKey("CartId");
            
            item.Property<Guid>("CartId");
            
            item.HasKey("CartId", nameof(CartItem.CatalogItemId));
            
            item.Property(i => i.CatalogItemId).IsRequired();
            item.Property(i => i.Title).IsRequired().HasMaxLength(200);
            item.Property(i => i.Quantity).IsRequired();
            
            item.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            item.Property(x => x.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        });
        
        builder.Navigation("_items")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}