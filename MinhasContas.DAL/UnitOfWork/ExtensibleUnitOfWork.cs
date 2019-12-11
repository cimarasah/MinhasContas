using Microsoft.EntityFrameworkCore;
using MinhasContas.DAL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasContas.DAL.UnitOfWork
{
    public class ExtensibleUnitOfWork<TContext, TApplicationContext> : UnitOfWork<TContext>
        where TContext : DbContext
        where TApplicationContext : IApplicationContextService
    {
        public ExtensibleUnitOfWork(TContext context, TApplicationContext applicationContextService)
            : base(context, applicationContextService)
        { }
    }
}
