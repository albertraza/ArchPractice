using Library.Domain.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.Data.Extentions
{
    internal static class ApplicationDbContextExtentions
    {
        public static void DetectChanges(this ApplicationDbContext dbContext)
        {
            IEnumerable<EntityEntry> entries = dbContext.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity.GetType().BaseType == typeof(Entity) || entry.Entity is IEntity)
                {
                    IEntity? entity = entry.Entity as IEntity;

                    if (entity == null) continue;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            {
                                PropertyValues? databaseEntity = entry.GetDatabaseValues();
                                if (databaseEntity == null)
                                {
                                    entity.CreatedDate = DateTime.UtcNow;
                                    entity.StateId = (int)EntityStates.Active;
                                }
                                else
                                {
                                    if (databaseEntity.ToObject() is IEntity dbEntity)
                                    {
                                        entity.CreatedDate = dbEntity.CreatedDate;
                                    }
                                    entity.UpdatedDate = DateTime.UtcNow;
                                    entity.DeletedDate = null;
                                    entity.StateId = (int)EntityStates.Active;
                                    entry.State = EntityState.Modified;
                                }
                                break;
                            }
                        case EntityState.Modified:
                            {
                                PropertyValues? databaseEntity = entry.GetDatabaseValues();
                                if (databaseEntity?.ToObject() is IEntity dbEntity)
                                {
                                    entity.CreatedDate = dbEntity.CreatedDate;
                                }
                                entity.StateId = (int)EntityStates.Active;
                                entity.UpdatedDate = DateTime.UtcNow;
                                break;
                            }
                        case EntityState.Deleted:
                        case EntityState.Detached:
                            {
                                PropertyValues databaseEntity = entry.GetDatabaseValues();
                                var dbEntity = databaseEntity.ToObject() as IEntity;
                                entity.CreatedDate = dbEntity.CreatedDate;
                                entity.UpdatedDate = dbEntity.UpdatedDate;
                                entity.DeletedDate = DateTime.UtcNow;
                                entity.StateId = (int)EntityStates.Inactive;
                                entry.State = EntityState.Modified;
                                break;
                            }
                        case EntityState.Unchanged:
                            if (entity is not null)
                            {
                                PropertyValues databaseEntity = entry.GetDatabaseValues();
                                if (databaseEntity is not null)
                                {
                                    IEntity databaseEntityObject = databaseEntity.ToObject() as IEntity;

                                    entity.CreatedDate = databaseEntityObject.CreatedDate;
                                    entity.StateId = (int)EntityStates.Active;
                                    entity.UpdatedDate = DateTime.UtcNow;
                                    entity.DeletedDate = databaseEntityObject.DeletedDate;
                                    entry.State = EntityState.Modified;

                                }

                                if (databaseEntity is null)
                                {
                                    entity.CreatedDate = DateTime.UtcNow;
                                    entity.StateId = (int)EntityStates.Active;
                                    entry.State = EntityState.Added;
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        public static async Task DetectChangesAsync(this ApplicationDbContext dbContext)
        {
            IEnumerable<EntityEntry> entries = dbContext.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity.GetType().BaseType == typeof(Entity) || entry.Entity is IEntity)
                {
                    IEntity entity = entry.Entity as IEntity;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            {
                                PropertyValues databaseEntity = await entry.GetDatabaseValuesAsync();
                                if (databaseEntity == null)
                                {
                                    entity.CreatedDate = DateTime.UtcNow;
                                    entity.StateId = (int)EntityStates.Active;
                                }
                                else
                                {
                                    var dbEntity = databaseEntity.ToObject() as IEntity;
                                    entity.CreatedDate = dbEntity.CreatedDate;
                                    entity.UpdatedDate = DateTime.UtcNow;
                                    entity.DeletedDate = null;
                                    entity.StateId = (int)EntityStates.Active;
                                    entry.State = EntityState.Modified;
                                }
                                break;
                            }
                        case EntityState.Modified:
                            {
                                PropertyValues databaseEntity = await entry.GetDatabaseValuesAsync();
                                var dbEntity = databaseEntity.ToObject() as IEntity;
                                entity.CreatedDate = dbEntity.CreatedDate;
                                entity.UpdatedDate = DateTime.UtcNow;
                                entity.StateId = (int)EntityStates.Active;
                                break;
                            }
                        case EntityState.Deleted:
                        case EntityState.Detached:
                            {
                                PropertyValues databaseEntity = await entry.GetDatabaseValuesAsync();
                                var dbEntity = databaseEntity.ToObject() as IEntity;
                                entity.CreatedDate = dbEntity.CreatedDate;
                                entity.UpdatedDate = dbEntity.UpdatedDate;
                                entity.DeletedDate = DateTime.UtcNow;
                                entity.StateId = (int)EntityStates.Inactive;
                                entry.State = EntityState.Modified;
                                break;
                            }
                        case EntityState.Unchanged:
                            if (entity is not null)
                            {
                                PropertyValues databaseEntity = await entry.GetDatabaseValuesAsync();
                                if (databaseEntity is not null)
                                {
                                    IEntity databaseEntityObject = databaseEntity.ToObject() as IEntity;

                                    entity.CreatedDate = databaseEntityObject.CreatedDate;
                                    entity.UpdatedDate = DateTime.UtcNow;
                                    entity.DeletedDate = databaseEntityObject.DeletedDate;
                                    entity.StateId = (int)EntityStates.Active;
                                    entry.State = EntityState.Modified;

                                }

                                if (databaseEntity is null)
                                {
                                    entity.CreatedDate = DateTime.UtcNow;
                                    entity.StateId = (int)EntityStates.Active;
                                    entry.State = EntityState.Added;
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
