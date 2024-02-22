using System;
using UScreens;
using UWarning.Core;
using UWarning.View;

namespace UWarning
{
    public static class WarningSystem
    {
        public static void Show(string id, Action acceptAction, Action rejectAction) =>
            UScreenRepo.Get<WarningViewController>().Show(WarningCardRepo.Get(id), acceptAction, rejectAction);

        public static void Show(string id, string description, Action acceptAction, Action rejectAction) =>
            UScreenRepo.Get<WarningViewController>().Show(WarningCardRepo.Get(id), acceptAction, rejectAction, description);
    }
}
