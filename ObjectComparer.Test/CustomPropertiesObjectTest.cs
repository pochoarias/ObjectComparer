using ObjectComparer.Test.Objects;
using Xunit;

namespace ObjectComparer.Test
{
    public class CustomPropertiesObjectTest
    {
        private readonly CustomPropertiesObject customPropertiesObject01;
        private readonly CustomPropertiesObject customPropertiesObject02;
        private readonly CustomObject customObject;


        public CustomPropertiesObjectTest()
        {
            this.customPropertiesObject01 = new CustomPropertiesObject();
            this.customPropertiesObject02 = new CustomPropertiesObject();
            this.customObject = new CustomObject();
        }

        [Fact]
        public void ObjectsAreEqual()
        {
            var comparer = new ObjectComparer();
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default","Foo","Bar");
            this.customPropertiesObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default","Foo","Bar");
            Assert.True(comparer.CompareElements(customPropertiesObject01, customPropertiesObject02));

        }

        [Fact]
        public void ObjectsAreNotEqual()
        {
            var comparer = new ObjectComparer();
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customPropertiesObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "NotEqual", "Foo", "Bar");
            Assert.False(comparer.CompareElements(customPropertiesObject01, customPropertiesObject02));
        }

        [Fact]
        public void ObjectsIsNull()
        {
            var comparer = new ObjectComparer();
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.False(comparer.CompareElements(customPropertiesObject01, null));
        }

        [Fact]
        public void ObjectsAreDifferent()
        {
            var comparer = new ObjectComparer();
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.False(comparer.CompareElements<ICustomObject>(customPropertiesObject01, customObject));
        }

        [Fact]
        public void ObjectsAreEqualDeep()
        {
            var comparer = new ObjectComparer() { DeepCompare = true };
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customPropertiesObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.True(comparer.CompareElements(customPropertiesObject01, customPropertiesObject02));

        }

        [Fact]
        public void ObjectsAreNotEqualDeep()
        {
            var comparer = new ObjectComparer() { DeepCompare = true };
            this.customPropertiesObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customPropertiesObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "NotEqual");
            Assert.False(comparer.CompareElements(customPropertiesObject01, customPropertiesObject02));

        }
    }
}
