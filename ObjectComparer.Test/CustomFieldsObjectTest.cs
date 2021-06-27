using ObjectComparer.Test.Objects;
using Xunit;

namespace ObjectComparer.Test
{
    public class CustomFieldsObjectTest
    {
        private CustomFieldsObject customFieldsObject01;
        private CustomFieldsObject customFieldsObject02;
        private CustomObject customObject;


        public CustomFieldsObjectTest()
        {
            this.customFieldsObject01 = new CustomFieldsObject();
            this.customFieldsObject02 = new CustomFieldsObject();
            this.customObject = new CustomObject();
        }

        [Fact]
        public void ObjectsAreEqual()
        {
            var comparer = new ObjectComparer();
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customFieldsObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.True(comparer.CompareElements(customFieldsObject01, customFieldsObject02));

        }

        [Fact]
        public void ObjectsAreNotEqual()
        {
            var comparer = new ObjectComparer();
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customFieldsObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "NotEqual", "Foo", "Bar");
            Assert.False(comparer.CompareElements(customFieldsObject01, customFieldsObject02));
        }

        [Fact]
        public void ObjectsIsNull()
        {
            var comparer = new ObjectComparer();
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.False(comparer.CompareElements(customFieldsObject01, null));
        }

        [Fact]
        public void ObjectsAreDifferent()
        {
            var comparer = new ObjectComparer();
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.False(comparer.CompareElements<ICustomObject>(customFieldsObject01, customObject));
        }

        [Fact]
        public void ObjectsAreEqualDeep()
        {
            var comparer = new ObjectComparer() { DeepCompare = true };
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customFieldsObject02.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            Assert.True(comparer.CompareElements(customFieldsObject01, customFieldsObject02));

        }

        [Fact]
        public void ObjectsAreNotEqualDeep()
        {
            var comparer = new ObjectComparer() { DeepCompare = true };
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "Bar");
            this.customFieldsObject01.Initialize(true, 0, 0, 'a', 0, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, "default", "Foo", "NotEqual");
            Assert.False(comparer.CompareElements(customFieldsObject01, customFieldsObject02));

        }
    }
}
