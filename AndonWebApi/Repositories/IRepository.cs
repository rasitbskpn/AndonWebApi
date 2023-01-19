using AndonWebApi.Entities;

namespace AndonWebApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Retrieves all entities from the database
        /// </summary>
        /// <returns>A collection of all entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="id">The id of the entity to delete</param>
        /// <returns>The task that represents the asynchronous operation</returns>
        Task Delete(int id);

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>The task that represents the asynchronous operation</returns>
        Task Add(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the database
        /// </summary>
        /// <param name="entity">The updated entity information</param>
        /// <returns>The task that represents the asynchronous operation</returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Retrieves an entity by its id
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The entity with the specified id</returns>
        Task<TEntity> GetById(int id);

    }
}
