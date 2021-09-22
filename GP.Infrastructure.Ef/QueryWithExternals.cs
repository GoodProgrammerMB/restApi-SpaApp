using GP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Infrastructure.Ef
{
    public class QueryWithExternals<TDomainObject> : Query<TDomainObject> where TDomainObject : class, IDomainObject
    {
        protected readonly List<Func<TDomainObject, Task>> ExternalActions;
        protected readonly List<Func<List<TDomainObject>, List<TDomainObject>>> AggregateActions;

        public QueryWithExternals(IQueryable<TDomainObject> query) : base(query)
        {
            ExternalActions = new List<Func<TDomainObject, Task>>();
            AggregateActions = new List<Func<List<TDomainObject>, List<TDomainObject>>>();
        }

        public override async Task<List<TDomainObject>> ToListAsync()
        {
            var entities = await base.ToListAsync();
            if (ExternalActions.Any())
            {
                foreach (var entity in entities)
                {
                    await ApplyExternalActions(entity);
                }
            }

            ApplyAggregateActions(entities);

            return entities;
        }

        public override async Task<TDomainObject> SingleOrDefaultAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.SingleOrDefault();
            }

            var entity = await base.SingleOrDefaultAsync();

            if (entity != null)
            {
                await ApplyExternalActions(entity);
            }

            return entity;
        }

        public override async Task<TDomainObject> SingleAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.Single();
            }

            var entity = await base.SingleAsync();

            await ApplyExternalActions(entity);

            return entity;
        }

        public override async Task<TDomainObject> FirstOrDefaultAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.FirstOrDefault();
            }

            var entity = await base.FirstOrDefaultAsync();

            if (entity != null)
            {
                await ApplyExternalActions(entity);
            }

            return entity;
        }

        public override async Task<TDomainObject> FirstAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.First();
            }

            var entity = await base.FirstAsync();

            await ApplyExternalActions(entity);

            return entity;
        }

        public override async Task<TDomainObject> LastOrDefaultAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.LastOrDefault();
            }

            var entity = await base.LastOrDefaultAsync();

            if (entity != null)
            {
                await ApplyExternalActions(entity);
            }

            return entity;
        }

        public override async Task<TDomainObject> LastAsync()
        {
            if (AggregateActions.Any())
            {
                var entities = await ApplyAggregateActions();

                return entities.Last();
            }

            var entity = await base.LastAsync();

            await ApplyExternalActions(entity);

            return entity;
        }

        private async Task ApplyExternalActions(TDomainObject entity)
        {
            foreach (var action in ExternalActions)
            {
                await action(entity);
            }
        }

        private void ApplyAggregateActions(List<TDomainObject> entities)
        {
            if (AggregateActions.Any())
            {
                foreach (var action in AggregateActions)
                {
                    action(entities);
                }
            }
        }

        private async Task<List<TDomainObject>> ApplyAggregateActions()
        {
            var entities = await ToListAsync();
            foreach (var action in AggregateActions)
            {
                action(entities);
            }

            return entities;
        }


        protected void RegisterExternal(Func<TDomainObject, Task> action)
        {
            ExternalActions.Add(action);
        }

        protected void RegisterAggregate(Func<List<TDomainObject>, List<TDomainObject>> action)
        {
            AggregateActions.Add(action);
        }
    }
}
