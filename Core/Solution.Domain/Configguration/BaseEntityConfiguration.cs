namespace Solution.Domain.Configguration
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.ModifiedBy).IsRequired(false);
            builder.Property(e => e.ModifiedDate).IsRequired(false);
        }
    }
}
