using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SortText
{
    [TestClass]
    public class FormattextTests
    {
        FormatText formatText;

        [TestInitialize]
        public void SetUP()
        {
            formatText = new FormatText();
        }
        [TestMethod]
        public void StripPunctuation_WhenCalled_RemovesAllPanctuations()
        {
            var textWithPanctuation = "This is a test, right?";

            var result = formatText.StripPunctuation(textWithPanctuation);

            Assert.AreEqual("Thisisatestright", result);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StripPunctuation_WhenPassedEmptyOrNull_ReturnsArgumentNullException(string text)
        {

            formatText.StripPunctuation(text);

        }
    }
}
