using SortText.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SortText
{
    public class FormatText: IFormatText
    {
        #region Methods
        public string StripPunctuation(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException();

            return Regex.Replace(text, @"[^0-9a-zA-Z]+", "");
        }
        #endregion
    }
}
