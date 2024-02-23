using System;
using Unit.SharedTypes;

namespace Unit.Logic
{
    public class UnitFilterController
    {
        private readonly Action<UnitFilter> OnUpdate;

        public UnitFilterController(Action<UnitFilter> onUpdate) => 
            OnUpdate = onUpdate;

        public void Update(UnitFilter filter) =>
            OnUpdate.Invoke(filter);
    }
}