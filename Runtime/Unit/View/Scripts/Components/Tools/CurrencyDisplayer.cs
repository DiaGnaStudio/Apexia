using UnityEngine;

namespace Min_Max_Slider
{
    internal class CurrencyDisplayer: Displayer
    {
        protected override string Convert(float value)
        {
            string result;
            string[] ScoreNames = new string[] { "", "k", "M", "B", "T", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", };
            int i;

            for (i = 0; i < ScoreNames.Length; i++)
                if (value < 900)
                    break;
                else value = Mathf.Floor(value / 100f) / 10f;

            if (value == Mathf.Floor(value))
                result = value.ToString() + ScoreNames[i];
            else result = value.ToString("F1") + ScoreNames[i];
            return result;
        }
    }
}