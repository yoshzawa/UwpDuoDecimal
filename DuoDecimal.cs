using System;
using System.Text; // StringBuilder を使う場合に備えて残しています。現在のSetDuoDecimalでは不要ですが、GetIntで使うかもしれません。

namespace UwpDuoDecimal
{
    public class DuoDecimal
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            private set
            {
                if (!IsValidDuoDecimalString(value))
                {
                    throw new ArgumentException("無効な12進数文字列です。0-9, T, E のいずれかの文字で構成される1～2文字の文字列を入力してください。");
                }

                string processedValue = value.ToLower();

                if (processedValue.Length == 2 && processedValue.StartsWith("0"))
                {
                    processedValue = processedValue.Substring(1);
                }

                _value = processedValue;
            }
        }

        /// <summary>
        /// 12進数文字列からDuoDecimalのインスタンスを初期化します。
        /// </summary>
        /// <param name="duoDecimalString">12進数文字列 (1～2文字)</param>
        public DuoDecimal(string duoDecimalString)
        {
            Value = duoDecimalString;
        }

        /// <summary>
        /// 10進数からDuoDecimalのインスタンスを初期化します。
        /// </summary>
        /// <param name="intValue">10進数 (0～143)</param>
        public DuoDecimal(int intValue)
        {
            if (intValue < 0 || intValue > 143)
            {
                throw new ArgumentOutOfRangeException(nameof(intValue), "10進数の値は0から143の範囲で指定してください。");
            }
            SetDuoDecimal(intValue);
        }

        /// <summary>
        /// 12進数の値を設定します。
        /// </summary>
        /// <param name="duoDecimalString">12進数文字列 (1～2文字)</param>
        public void SetDuoDecimal(string duoDecimalString)
        {
            Value = duoDecimalString;
        }

        /// <summary>
        /// 10進数の値を設定し、12進数に変換して保存します。
        /// </summary>
        /// <param name="intValue">10進数 (0～143)</param>
        public void SetDuoDecimal(int intValue)
        {
            if (intValue < 0 || intValue > 143)
            {
                throw new ArgumentOutOfRangeException(nameof(intValue), "10進数の値は0から143の範囲で指定してください。");
            }

            string s = "";
            if (intValue >= 12)
            {
                s += "0123456789TE"[intValue / 12];
            }
            s += "0123456789TE"[intValue % 12];

            Value = s;
        }

        /// <summary>
        /// 現在の12進数値を文字列として取得します。
        /// </summary>
        /// <returns>12進数文字列</returns>
        public string GetString()
        {
            return _value;
        }


        int GetDigitValue(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return c - '0';
            }
            else if (c == 't')
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }
        /// <summary>
        /// 現在の12進数値を10進数として取得します。
        /// </summary>
        /// <returns>10進数</returns>
        public int GetInt()
        {
            int intValue = 0; ;


            intValue += GetDigitValue(_value[0]);
            if (_value.Length == 2)
            {
                intValue *=  12; 
                intValue += GetDigitValue(_value[1]);
            }

            return intValue;
        
        }

        /// <summary>
        /// 指定された文字列が有効な12進数表現であるかを確認します。
        /// </summary>
        /// <param name="duoDecimalString">検証する文字列</param>
        /// <returns>有効な12進数表現であればTrue、そうでなければFalse</returns>
        public static bool IsValidDuoDecimalString(string duoDecimalString)
        {
            if (string.IsNullOrEmpty(duoDecimalString))
            {
                return false;
            }

            if (duoDecimalString.Length > 2)
            {
                return false;
            }

            foreach (char c in duoDecimalString)
            {
                // '0'から'9'、または't'であるかをチェック
                if (!((c >= '0' && c <= '9') || c == 't'))
                {
                    return false; // 無効な文字が含まれている
                }
            }

            // すべてのチェックを通過した場合、有効
            return true;

        }
    }
}