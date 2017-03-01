﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Data.SmithReview.Tests {
    
    public class Util {
        public static Mock<DbSet<TEntity>> GetMockDbSet<TEntity>(List<TEntity> set) where TEntity : class {
                    var mockSet = new Mock<DbSet<TEntity>>();
                    mockSet.As<IQueryable<TEntity>>().Setup(m=>m.Provider).Returns(set.AsQueryable().Provider);
                    mockSet.As<IQueryable<TEntity>>().Setup(m=>m.Expression).Returns(set.AsQueryable().Expression);
                    mockSet.As<IQueryable<TEntity>>().Setup(m=>m.ElementType).Returns(set.AsQueryable().ElementType);
                    mockSet.As<IQueryable<TEntity>>().Setup(m=>m.GetEnumerator()).Returns(set.AsQueryable().GetEnumerator());
                    mockSet.Setup(m=>m.Add(It.IsAny<TEntity>()))
                        .Callback((TEntity a)=>set.Add(a))
                        .Returns((TEntity a)=>a)
                        .Verifiable();
                    return mockSet;
                }
        public static Mock<DbEntityEntry<TEntity>> GetMockEntry<TEntity>(TEntity e) where TEntity : class {
            return (new Mock<DbEntityEntry<TEntity>>());
        }
    }
}
