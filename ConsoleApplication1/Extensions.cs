using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelimiterExtention
{
    public static class Extensions
    {
        /// <summary>
        /// 依定界符號來切割列舉
        /// </summary>
        /// <typeparam name="T">型別</typeparam>
        /// <param name="source">來源列舉物件</param>
        /// <param name="delimiter">定界符號</param>
        /// <returns>依定界符號分離後後可列舉的列舉(陣列)物件</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, IEnumerable<T> delimiter)
        {
            //定界符號轉列表物件
            var delimiterList = delimiter.ToList();
            //暫存列表
            var outputBuffer = new List<T>();
            //counter
            var m = 0;
            //列舉所有項目
            foreach (var item in source)
            {
                //若此項目是定界符號
                if (item.Equals(delimiterList[m]))
                {
                    m++;

                    //若(記數器+1)等於定界符號的數量=>即定界符號數量等同於記數器次數
                    if (m == delimiterList.Count)
                    {
                        //記數器歸零
                        m = 0;

                        //若暫存列表有資料
                        if (outputBuffer.Count > 0)
                        {
                            //傳出去前一次切割後的暫存列表
                            yield return outputBuffer;
                            //暫存列表歸零
                            outputBuffer = new List<T>();
                        }
                    }
                }
                else
                {
                    //這段不太懂會何要加 (暫存列表加入定界列表列舉)
                    outputBuffer.AddRange(delimiterList.Take(m));

                    //若項目為定界符號[0]
                    if (item.Equals(delimiterList[0]))
                    {
                        //記數器推進1
                        m = 1;
                    }
                    else
                    {
                        //記數器歸零
                        m = 0;
                        //要資料項目加入此block的暫存列表
                        outputBuffer.Add(item);
                    }
                }
            }

            outputBuffer.AddRange(delimiterList.Take(m));
            //傳出最後一段暫存列表(因迴圈已跑完,所以補上最後一段被切割的暫存列表)
            if (outputBuffer.Count > 0)
            {
                yield return outputBuffer;
            }
        }
    }
}
