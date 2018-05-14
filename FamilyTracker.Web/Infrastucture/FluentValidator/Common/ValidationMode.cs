using System;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Common
{
    [Flags]
    public enum ValidationMode
    {
        None = 0,
        DataRelevance = 1,
        Exist = 2,
        Delete = 4,
        Update = 8,
        Add = 16
    }
}