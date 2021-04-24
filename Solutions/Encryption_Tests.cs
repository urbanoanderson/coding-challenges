using NUnit.Framework;

namespace Challenges.Solutions.Encryption
{
    public class Encryption_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                "haveaniceday",
                "hae and via ecy",
            },
            new object[]
            {
                "feedthedog",
                "fto ehg ee dd",
            },
            new object[]
            {
                "chillout",
                "clu hlt io",
            },
            new object[]
            {
                "if man was meant to stay on the ground god would have given us roots",
                "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau",
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(string input, string expected)
        {
            var result = Encryption.Solution(input);
            Assert.IsTrue(result == expected);
        }
    }
}