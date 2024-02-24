using System;
using Unit.Data;

namespace Unit.Logic.Module
{
    internal class FilterHandler
    {
        private readonly Action<UnitFilter> OnUpdate;

        public FilterHandler(Action<UnitFilter> onUpdate) => 
            OnUpdate = onUpdate;

        public void Update(UnitFilter filter) =>
            OnUpdate.Invoke(filter);
    }
}