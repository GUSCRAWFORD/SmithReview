﻿using Data.SmithReview;
using Data.SmithReview.Domain;
using Data.SmithReview.Domain.Interfaces;
using Models.SmithReview;
using Operations.SmithReview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.SmithReview {
    public abstract class Operations<TModel, TDomain, TKey> : IOperations<TModel, TDomain, TKey>, IDisposable
            where TModel : BaseBusinessModel
            where TDomain : BaseDomainModel
            where TKey : IComparable {
        public Operations(IDbContext unitOfWork = null) {
            _context = unitOfWork ?? SmithReviewContextProvider.Instance();
        }
        protected IDbContext _context;

        protected abstract TModel ToModel(TDomain domain);
        protected abstract TDomain ToDomain(TModel model);
        public abstract TModel SingleByKey(TKey id);
        public abstract IEnumerable<TModel> All(int page, int perPage, params string[] orderBy);
        public abstract void Save(TModel item);
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Operations() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
