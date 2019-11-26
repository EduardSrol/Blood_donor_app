using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodDonorApp.Infrastructure.UnitOfWork
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private readonly IList<Action> afterCommitActions = new List<Action>();


        public void Commit()
        {
            CommitCore();
            foreach (var action in afterCommitActions)
            {
                action();
            }
            afterCommitActions.Clear();
        }

        public async Task CommitAsync()
        {
            await CommitCoreAsync();
            foreach (var action in afterCommitActions)
            {
                action();
            }
            afterCommitActions.Clear();
        }

        public void RegisterAction(Action action)
        {
            afterCommitActions.Add(action);
        }

        protected abstract Task CommitCoreAsync();

        protected abstract void CommitCore();

        public abstract void Dispose();
    }
}