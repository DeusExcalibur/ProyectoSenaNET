﻿// Repositories/IGenericRepository.cs
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProyectoSenaScrum.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}