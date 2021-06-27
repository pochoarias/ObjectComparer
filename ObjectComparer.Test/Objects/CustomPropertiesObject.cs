using ObjectComparer.Test.Objects;

namespace ObjectComparer.Test
{
    public class CustomPropertiesObject : ICustomObject
    {
        public bool boolValue { get; private set; }
        public byte byteValue { get; private set; }
        public sbyte sbyteValue { get; private set; }
        public char charValue { get; private set; }
        public decimal decimalValue { get; private set; }
        public double doubleValue { get; private set; }
        public float floatValue { get; private set; }
        public int intValue { get; private set; }
        public uint uintValue { get; private set; }
        public nint nintValue { get; private set; }
        public long longValue { get; private set; }
        public ulong ulongValue { get; private set; }
        public short shortValue { get; private set; }
        public ushort ushortValue { get; private set; }
        public string stringValue { get; private set; }
        public BaseObject baseObject { get; set; } = new BaseObject();

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
