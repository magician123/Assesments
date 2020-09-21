using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SortText.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SortText
{
    [TestClass]
    public class SortTextTests
    {
        SortText sortText;

        [TestInitialize]
        public void SetUp()
        {
            var mockText = new Mock<IFormatText>();
            mockText.Setup(text => text.StripPunctuation("")).Returns("zybaa");

            sortText = new SortText(mockText.Object);
        }
       

        [TestMethod]
        public void SelectionSort_Sorting_ReturnsSortedElementsAscending()
        {
            var elements = new char[] { 'z','y','b','a','a' };
            var expectedElements = new char[] { 'a', 'a', 'b', 'y', 'z' };

            var sortedElements = sortText.SelectionSort(elements);
           
            CollectionAssert.AreEqual(sortedElements, expectedElements);
        }

        [TestMethod]
        public void SortString_WhenCalled_ReturnsTypeOfString()
        {
            var result = sortText.SortStringAsync("zybaa");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(string));

        }

    }
}
