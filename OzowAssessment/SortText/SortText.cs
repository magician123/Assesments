using SortText.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText
{
    public class SortText
    {
       
        #region Fields 
        private readonly IFormatText _formatText;
        #endregion

        #region Constructor
        public SortText(IFormatText formatText)
        {
            _formatText = formatText;
        }
        #endregion

        #region Methods
      
        public async Task<string> SortStringAsync(string text)
        {
            string result = string.Empty;

            try
            {
                var task = Task<string>.Factory.StartNew(() =>
                {
                    _formatText.StripPunctuation(text);

                    var unSortedText = text.ToLower().Trim();
                    var sortedArray = SelectionSort(unSortedText.ToCharArray());

                    return GenerateText(sortedArray);

                });

               result = await task;

            }
            catch (Exception e)
            {

                return e.Message;
            }

            return result;
           
        }
        public char[] SelectionSort(char[] array)
        {
            for (int j = 0; j < array.Count() - 1; j++)
            {

                int smallest = j;
                for (int k = j + 1; k < array.Count(); k++)
                    if (array[k].CompareTo(array[smallest]) < 0) smallest = k;


                char temp = array[j];
                array[j] = array[smallest];
                array[smallest] = temp;
            }

            return array;
        }
        private string  GenerateText(char[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in array)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
       
        #endregion
    }
}
