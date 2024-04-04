
namespace Solution.Persistence.Context
{
    public class ThisAppDBCOntext : DbContext //Eğer Identity kullanıalcak ise  IdentityDbContext<x,y,Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ThisAppDBCOntext(DbContextOptions<ThisAppDBCOntext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        //Base entitydeki createBy veya updateBy gibi alanları her kayıtta yazamk yerine savechange metodunu override ederek ortak bir yapı oluşturduk.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            string userId;

            var user = _httpContextAccessor.HttpContext!.User;
            userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            userId ??= "";

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        SetIfDeleted(entry, userId);
                        break;
                    case EntityState.Modified:
                        SetIfModified(entry, userId);
                        break;
                    case EntityState.Added:
                        SetIfAdded(entry, userId);
                        break;
                    default:
                        break;
                }
            }
        }
        private static void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
        {


            if (entry.Entity is not AuditableEntity entity)
            {
                return;
            }

            entry.State = EntityState.Modified;

            entity.Status = Status.Deleted;
            entity.DeletedDate = DateTime.Now;
            entity.DeletedBy = userId;
        }
        private static void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State != EntityState.Added)
            {
                return;
            }

            entry.Entity.Status = Status.Added;
            entry.Entity.CreatedBy = userId;
            entry.Entity.CreatedDate = DateTime.Now;
        }
        private static void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
        {

            entry.Entity.Status = Status.Modified;
            entry.Entity.ModifiedBy = userId;
            entry.Entity.ModifiedDate = DateTime.Now;
        }
    }
}
