using System;
using System.Collections.Generic;

namespace Homer.Api.Domain.Entities.Sistema
{
    public class ResponseResult<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }
        public IEnumerable<TEntity> ListEntities { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResponseResult()
        {
            this.ListEntities = new List<TEntity>();
            Success = true;
        }
    }
}
