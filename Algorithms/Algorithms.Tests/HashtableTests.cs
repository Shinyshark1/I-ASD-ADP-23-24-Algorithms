using Algorithms.DynamicArrays;
using Algorithms.Hashtable;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.JsonData;
using Newtonsoft.Json;
using Algorithms.JsonData.Hashing.Models;

namespace Algorithms.Tests
{
    public class HashtableTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheHashtable()
        {
            var hashingJson = JsonConstants.ReadDataSetHashing();
            var hashTableKeyValues = JsonConvert.DeserializeObject<HashtabelsleutelswaardesRoot>(hashingJson)!.Hashtabelsleutelswaardes;

            var hashTable = new Hashtable<object>();
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.A), hashTableKeyValues.A[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.B), hashTableKeyValues.B[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.C), hashTableKeyValues.C[0])));

            // The key already exists, so we'd have duplicate keys.
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.D), hashTableKeyValues.D[0])));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.D), hashTableKeyValues.D[1]));

            // There is no values to insert here, so we cannot even access them.
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.E), hashTableKeyValues.E[0]));
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.F), hashTableKeyValues.F[0]));
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.G), hashTableKeyValues.G[0]));
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.H), hashTableKeyValues.H[0]));
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.I), hashTableKeyValues.I[0]));

            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.J), hashTableKeyValues.J[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.K), hashTableKeyValues.K[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.L), hashTableKeyValues.L[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.M), hashTableKeyValues.M[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.N), hashTableKeyValues.N[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.O), hashTableKeyValues.O[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.P), hashTableKeyValues.P[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.Q), hashTableKeyValues.Q[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.R), hashTableKeyValues.R[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.S), hashTableKeyValues.S[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.T), hashTableKeyValues.T[0])));

            // The key already exists, so we'd have duplicate keys.
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.U), hashTableKeyValues.U[0])));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.U), hashTableKeyValues.U[1]));

            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.V), hashTableKeyValues.V[0])));

            // The key already exists, so we'd have duplicate keys.
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.W), hashTableKeyValues.W[0])));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.W), hashTableKeyValues.W[1]));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.W), hashTableKeyValues.W[2]));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.W), hashTableKeyValues.W[3]));
            Assert.Throws<InvalidOperationException>(() => hashTable.Insert(nameof(hashTableKeyValues.W), hashTableKeyValues.W[4]));

            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.X), hashTableKeyValues.X[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.Y), hashTableKeyValues.Y[0])));
            Assert.Null(Record.Exception(() => hashTable.Insert(nameof(hashTableKeyValues.Z), hashTableKeyValues.Z[0])));

            // Our hashing function doesn't deal properly with integers, causing our chosen index to be -24.
            Assert.Throws<IndexOutOfRangeException>(() => hashTable.Insert(nameof(hashTableKeyValues.Z0), hashTableKeyValues.Z0[0]));
        }

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
