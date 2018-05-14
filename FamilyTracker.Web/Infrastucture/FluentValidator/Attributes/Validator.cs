using FamilyTracker.Web.Infrastucture.FluentValidator.Common;
using System;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Attributes
{
    public class Validator: Attribute
    {
        public Validator(ValidationMode mode)
        {
            Mode = mode;
        }

        public ValidationMode Mode { get; }
    }
}