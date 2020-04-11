using System;

namespace VehiclesPriceListApp.Infrastructure.Data.SeedDB
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        public Type DependingType { get; private set; }

        public DependsOnAttribute(Type dependingType)
        {
            if (!(typeof(ISeed).IsAssignableFrom(dependingType)))
                throw new ArgumentException("dependingType should implement ISeed", "dependingType");

            this.DependingType = dependingType;
        }
    }
}
