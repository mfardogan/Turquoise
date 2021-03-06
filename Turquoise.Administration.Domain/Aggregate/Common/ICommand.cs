﻿namespace Turquoise.Administration.Domain.Aggregate.Common
{
    public interface ICommand<TEntity, TPk> where TEntity : Poco<TPk>
    {
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TPk id);
    }
}
