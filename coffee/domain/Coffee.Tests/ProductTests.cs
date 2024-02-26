using Xunit;

namespace Coffee.Tests
{
    public class ProductTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Product.IsIsbn(null);

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Product.IsIsbn("");

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Product.IsIsbn("ISBN 123");

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnFalse()
        {
            bool actual = Product.IsIsbn("IsBn 123-456-789 0");

            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Product.IsIsbn("xxx IsBn 123-456-789 0123 yyy");

            Assert.False(actual);
        }
    }
}