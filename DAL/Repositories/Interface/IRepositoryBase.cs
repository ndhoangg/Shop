﻿using System;
using System.Linq.Expressions;

namespace DAL.Interface
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
        void Add(TEntity objModel);

        Task AddAsync(TEntity objModel);

        void AddRange(IEnumerable<TEntity> objModel);

        Task AddRangeAsync(IEnumerable<TEntity> objModel);

        TEntity GetId(Guid id);

        Task<TEntity> GetIdAsync(int id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        int Count();

        Task<int> CountAsync();

        void Update(TEntity objModel);

        void Remove(TEntity objModel);
    }
	
}

