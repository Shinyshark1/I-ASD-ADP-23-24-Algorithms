using Algorithms.Hashtable;

namespace Algorithms.Tests
{
    public class HashtableTests
    {
        [Fact]
        public void Insert_Throws_IfThereIsNoSpaceLeft()
        {
            // Arrange
            var hashTable = new Hashtable<string>(3);

            // Act
            hashTable.Insert("a", "First");         // 0
            hashTable.Insert("aa", "Second");       // 1
            hashTable.Insert("aaa", "Third");       // 2

            // Assert
            // 2 as well, but there is no space left.
            Assert.Throws<Exception>(() => hashTable.Insert("ab", "Fourth"));
        }

        [Fact]
        public void Insert_Throws_IfKeyIsNotProvided()
        {
            // Arrange
            var hashTable = new Hashtable<string>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(null, "Null is not allowed."));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert("", "An empty string is not allowed."));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert("   ", "An empty string with spaces is not allowed."));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(string.Empty, "string.Empty is not allowed."));
        }

        [Fact]
        public void Insert_Throws_IfKeyAlreadyExists()
        {
            // Arrange
            var hashTable = new Hashtable<string>();

            // Act
            hashTable.Insert("a", "First");

            // Assert
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert("a", "I already exist, oops!"));
        }

        [Fact]
        public void Get_Returns_TheCorrectItem()
        {
            // Arrange
            var hashTable = new Hashtable<string>(5);

            // Act
            hashTable.Insert("a", "First");
            hashTable.Insert("b", "Second");
            hashTable.Insert("c", "Third");

            // These two will share the same index but the key will be checked to ensure the right value is returned.
            hashTable.Insert("ab", "Fourth");
            hashTable.Insert("ba", "Fifth");

            // Assert
            Assert.Equal("First", hashTable.Get("a"));
            Assert.Equal("Second", hashTable.Get("b"));
            Assert.Equal("Third", hashTable.Get("c"));
            Assert.Equal("Fourth", hashTable.Get("ab"));
            Assert.Equal("Fifth", hashTable.Get("ba"));

            // The key is not found so default is returned.
            Assert.Equal(default, hashTable.Get("Unknown Key"));
        }

        [Fact]
        public void Update_Succesfully_UpdatesTheKey()
        {
            // Arrange
            var hashTable = new Hashtable<string>();

            // Act
            hashTable.Insert("ab", "First");
            hashTable.Insert("ba", "Second");

            var failedResult = hashTable.Update("Non-existant key", "A lovely new value.");
            var result = hashTable.Update("ba", "I am now updated.");

            // Assert
            Assert.False(failedResult);

            Assert.True(result);
            Assert.Equal("I am now updated.", hashTable.Get("ba"));
        }

        [Fact]
        public void Delete_Returns_TrueIfItDeletedAnItem()
        {
            // Arrange
            var hashTable = new Hashtable<string>(3);

            // Act
            hashTable.Insert("a", "First");
            hashTable.Insert("b", "Second");
            hashTable.Insert("c", "Third");

            // Assert
            Assert.True(hashTable.Delete("a"));
            Assert.True(hashTable.Delete("b"));
            Assert.True(hashTable.Delete("c"));
        }

        [Fact]
        public void Delete_Returns_FalseIfItDidNotDeleteAnItem()
        {
            // Arrange
            var hashTable = new Hashtable<string>(3);

            // Act
            hashTable.Insert("a", "First");

            // Assert
            Assert.False(hashTable.Delete("x"));
        }
    }
}
