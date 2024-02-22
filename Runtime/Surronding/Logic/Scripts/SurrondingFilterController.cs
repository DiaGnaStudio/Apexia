using Surronding.SharedTypes;
using System;

namespace Surronding.Logic
{
    public class SurrondingFilterController
    {
        private readonly Action<SurrendingFilter> OnUpdate;

        public SurrondingFilterController(Action<SurrendingFilter> onUpdate) =>
            OnUpdate = onUpdate;

        public void Update(SurrendingFilter filter) =>
            OnUpdate.Invoke(filter);
    }
}