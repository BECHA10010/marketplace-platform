namespace Basket.API.Infrastructure.Configurations;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCartEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartEntity> builder)
    {
        builder.ToTable("ShoppingCarts");
        
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.AccountName).IsUnique();
        
        builder.Property(x => x.AccountName).IsRequired().HasMaxLength(100);
        
        builder.HasMany(x => x.Items)
            .WithOne(i => i.ShoppingCart)
            .HasForeignKey(i => i.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}