namespace Checkout.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.AccountName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Ignore(o => o.TotalAmount);
        
        builder.Property(o => o.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.Property(o => o.PaymentMethod)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.Property(o => o.PaymentStatus)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.OwnsOne(o => o.CustomerContact, contact =>
        {
            contact.Property(c => c.FirstName).HasMaxLength(100);
            contact.Property(c => c.LastName).HasMaxLength(100);
            contact.Property(c => c.Email).HasMaxLength(255);
        });
        
        builder.OwnsOne(o => o.DeliveryAddress, address =>
        {
            address.Property(a => a.Street).HasMaxLength(200);
            address.Property(a => a.City).HasMaxLength(100);
        });

        builder.OwnsOne(o => o.PaymentCard, card =>
        {
            card.Property(c => c.CardNumber).HasMaxLength(20);
            card.Property(c => c.Expiration).HasMaxLength(10);
            card.Property(c => c.CvvCode).HasMaxLength(10);
        });

        builder.OwnsMany(o => o.Items, item =>
        {
            item.WithOwner().HasForeignKey("OrderId");
            
            item.Property<Guid>("Id").HasDefaultValueSql("gen_random_uuid()");
            
            item.HasKey("Id");
            item.Property(i => i.Title).HasMaxLength(100).IsRequired();
            item.Property(i => i.Quantity).IsRequired();
            item.Property(i => i.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();
        });

        builder.HasIndex(o => o.AccountName);
        builder.HasIndex(o => o.Status);
        builder.HasIndex(o => o.PaymentStatus);
    }
}