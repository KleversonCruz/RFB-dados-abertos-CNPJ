using Core.Data.Context;

namespace Core.Data.Initialization
{
    public interface IAppInitializer
    {
        Task InitializeDatabaseAsync(bool ensureDelete, CancellationToken cancellationToken);
        Task InitializeDatabaseAsync(CancellationToken cancellationToken = default);
    }

    internal class AppInitializer : IAppInitializer
    {
        private readonly IAppDbContext dbContext;

        public AppInitializer(IAppDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task InitializeDatabaseAsync(CancellationToken cancellationToken = default!) 
            => await dbContext.EnsureCreateDatabaseAsync(cancellationToken);

        public async Task InitializeDatabaseAsync(bool ensureDelete, CancellationToken cancellationToken = default!)
        {
            if (ensureDelete)
            {
                await dbContext.EnsureDeleteDatabaseAsync(cancellationToken);
            }
            await InitializeDatabaseAsync(cancellationToken);
        }
    }
}
