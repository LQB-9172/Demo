namespace xUTest
{
    public class UnitTest1
    {
        // Test case 1: Kiểm tra một giá trị bằng 2
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }

        // Test case 2: Kiểm tra một giá trị bằng false
        [Fact]
        public void Test2()
        {
            Assert.False(1 + 1 == 3);
        }

        // Test case 3: Kiểm tra giá trị không null
        [Fact]
        public void Test3()
        {
            string testString = "Hello, world!";
            Assert.NotNull(testString);
        }

        // Test case 4: Kiểm tra giá trị null
        [Fact]
        public void Test4()
        {
            string testString = null;
            Assert.Null(testString);
        }

        // Test case 5: Kiểm tra điều kiện true
        [Fact]
        public void Test5()
        {
            int number = 10;
            Assert.True(number > 5);
        }

        // Test case 6: Kiểm tra điều kiện sai
        [Fact]
        public void Test6()
        {
            int number = 2;
            Assert.False(number > 5);
            //
        }

        // Test case 7: Kiểm tra giá trị bằng với một số nhất định
        [Fact]
        public void Test7()
        {
            int expected = 10;
            int actual = 5 + 5;
            Assert.Equal(expected, actual);
        }

        // Test case 8: Kiểm tra không bằng
        [Fact]
        public void Test8()
        {
            int expected = 10;
            int actual = 5 + 3;
            Assert.NotEqual(expected, actual);
        }
    }
}
