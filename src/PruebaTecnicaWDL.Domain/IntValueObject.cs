using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaWDL.Domain
{
    public class IntValueObject : ValueObject
    {
        public int Value { get; }

        public IntValueObject(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString(NumberFormatInfo.InvariantInfo);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as IntValueObject;
            if (item == null) return false;

            return Value == item.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
