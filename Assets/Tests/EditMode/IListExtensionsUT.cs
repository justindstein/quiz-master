using System.Collections.Generic;
using NUnit.Framework;

// Note: I had a lot of trouble getting NUnit to recognize IListExtensions. In order to do this, manually create a
// script assembly and add it as a reference to test asmdef (EG EditMode.asmdef) under 'references'.
// https://stackoverflow.com/questions/50223866/how-to-set-up-unit-tests-in-unity-and-fix-missing-assembly-reference-error
public class IListExtensionsUT
{
    private static readonly List<string> EMPTY_LIST = new List<string>();

    private List<string> elements;

    [SetUp]
    public void Setup()
    {
        this.elements = new List<string>() {
            "0"
            , "1"
            , "2"
            , "3"
            , "4"
        };
    }

    [Test]
    public void Shuffle_ElementsEmpty()
    {
        Assert.IsEmpty(EMPTY_LIST);

        EMPTY_LIST.Shuffle();

        Assert.IsEmpty(EMPTY_LIST);
    }

    [Test]
    // Very low probability of failed assertion due to shuffle not displacing ordering of any elements.
    public void Shuffle_Elements()
    {
        List<string> shuffleElements = new List<string>(this.elements);

        Assert.AreEqual(shuffleElements[0], this.elements[0]);
        Assert.AreEqual(shuffleElements[1], this.elements[1]);
        Assert.AreEqual(shuffleElements[2], this.elements[2]);
        Assert.AreEqual(shuffleElements[3], this.elements[3]);
        Assert.AreEqual(shuffleElements[4], this.elements[4]);

        shuffleElements.Shuffle();

        Assert.Contains(this.elements[0], shuffleElements);
        Assert.Contains(this.elements[1], shuffleElements);
        Assert.Contains(this.elements[2], shuffleElements);
        Assert.Contains(this.elements[3], shuffleElements);
        Assert.Contains(this.elements[4], shuffleElements);

        Assert.IsFalse(
            shuffleElements[0].Equals(this.elements[0])
            && shuffleElements[1].Equals(this.elements[1])
            && shuffleElements[2].Equals(this.elements[2])
            && shuffleElements[3].Equals(this.elements[3])
            && shuffleElements[4].Equals(this.elements[4])
        );
    }

    [Test]
    public void RandomInsert_ElementsEmpty()
    {
        List<string> randomInsertElements = new List<string>(EMPTY_LIST);

        string value = "0";
        int index = randomInsertElements.RandomInsert(value);

        Assert.IsNotEmpty(randomInsertElements);
        Assert.Contains(value, randomInsertElements);
        Assert.AreEqual(value, randomInsertElements[index]);
    }

    [Test]
    // Low probability of failed assertion due to random nature of random insertions.
    public void RandomInsert_Elements()
    {
        int MINIMUM_UNIQUE_INSERT_INDEXES = 40;

        HashSet<int> insertIndexes = new HashSet<int>();

        List<string> randomInsertElements = new List<string>(EMPTY_LIST);

        for (int i = 0; i < 100; i++)
        {
            string value = i.ToString();
            insertIndexes.Add(randomInsertElements.RandomInsert(value));
        }

        Assert.IsNotEmpty(randomInsertElements);
        Assert.GreaterOrEqual(insertIndexes.Count, MINIMUM_UNIQUE_INSERT_INDEXES);

        for (int i = 0; i < 100; i++)
        {
            string value = i.ToString();
            Assert.Contains(value, randomInsertElements);
        }
    }

    [Test]
    // Low probability of failed assertion due to random nature of random insertions.
    public void RandomInsert_VerifyCompleteDistribution_Elements()
    {
        int INSERT_MINIMUM_THRESHOLD = 10;

        Dictionary<int, int> insertIndexes = new Dictionary<int, int>();

        List<string> randomInsertElements = new List<string>(elements);

        for (int i = 0; i < 100; i++)
        {
            string value = "test";
            int insertIndex = randomInsertElements.RandomInsert(value);

            if (!insertIndexes.ContainsKey(insertIndex))
            {
                insertIndexes.Add(insertIndex, 0);
            }

            insertIndexes[insertIndex] = insertIndexes[insertIndex] + 1;

            randomInsertElements.RemoveAt(insertIndex);
        }

        Assert.AreEqual(elements.Count, randomInsertElements.Count);

        // Verify that each index (including front and back of list) has been touched
        for (int i = 0; i <= elements.Count; i++)
        {
            Assert.IsTrue(insertIndexes.ContainsKey(i));
            Assert.GreaterOrEqual(insertIndexes[i], INSERT_MINIMUM_THRESHOLD);
        }
    }
}