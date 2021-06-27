using ObjectComparer.Test.Objects;

namespace ObjectComparer.Test
{
    public class CustomFieldsObject : ICustomObject
    {
        public bool boolValue;
        public byte byteValue;
        public sbyte sbyteValue;
        public char charValue;
        public decimal decimalValue;
        public double doubleValue;
        public float floatValue;
        public int intValue;
        public uint uintValue;
        public nint nintValue;
        public long longValue;
        public ulong ulongValue;
        public short shortValue;
        public ushort ushortValue;
        public string stringValue;
        public BaseObject baseObject = new BaseObject();

        public void Initialize(
            bool boolValue,
            byte byteValue,
            sbyte sbyteValue,
            char charValue,
            decimal decimalValue,
            double doubleValue,
            float floatValue,
            int intValue,
            uint uintValue,
            nint nintValue,
            long longValue,
            ulong ulongValue,
            short shortValue,
            ushort ushortValue,
            string stringValue,
            string baseFoo,
            string baseBar)
        {
            this.boolValue = boolValue;
            this.byteValue = byteValue;
            this.sbyteValue = sbyteValue;
            this.charValue = charValue;
            this.decimalValue = decimalValue;
            this.doubleValue = doubleValue;
            this.floatValue = floatValue;
            this.intValue = intValue;
            this.uintValue = uintValue;
            this.nintValue = nintValue;
            this.longValue = longValue;
            this.ulongValue = ulongValue;
            this.shortValue = shortValue;
            this.ushortValue = ushortValue;
            this.stringValue = stringValue;
            this.baseObject.Foo = baseFoo;
            this.baseObject.Bar = baseBar;
        }
    }
}
