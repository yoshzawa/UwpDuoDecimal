using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpDuoDecimal
{
    internal class DuoDecimal
    {
        private string _value; // 12進数の値を保持

        // プロパティ
        public string Value
        {
            get { return _value; }
            private set
            {
                if (!IsValidDuoDecimal(value))
                {
                    throw new ArgumentException("無効な12進数文字列です。0-9, T, E のいずれかの文字で構成される1～2文字の文字列を入力してください。");
                }
                _value = value.ToUpper(); // 大文字に変換して保存
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
            if (intValue < 0 || intValue > 143) // 12進数2桁 (EE) は10進数で 11*12 + 11 = 132+11=143
            {
                throw new ArgumentOutOfRangeException(nameof(intValue), "10進数の値は0から143の範囲で指定してください。");
            }
            _value = IntToDuoDecimalString(intValue);
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
            _value = IntToDuoDecimalString(intValue);
        }

        /// <summary>
        /// 現在の12進数値を文字列として取得します。
        /// </summary>
        /// <returns>12進数文字列</returns>
        public string GetDuoDecimal()
        {
            return _value;
        }

        /// <summary>
        /// 現在の12進数値を10進数として取得します。
        /// </summary>
        /// <returns>10進数</returns>
        public int GetInt()
        {
            return DuoDecimalStringToInt(_value);
        }

        /// <summary>
        /// 指定された文字列が有効な12進数表現であるかを確認します。
        /// </summary>
        /// <param name="duoDecimalString">検証する文字列</param>
        /// <returns>有効な12進数表現であればTrue、そうでなければFalse</returns>
        public static bool IsValidDuoDecimal(string duoDecimalString)
        {
            return true;
        }

        /// <summary>
        /// 10進数値を12進数文字列に変換します。
        /// </summary>
        /// <param name="value">10進数値</param>
        /// <returns>12進数文字列</returns>
        private static string IntToDuoDecimalString(int value)
        {
            return "0";
        }

        /// <summary>
        /// 12進数文字列を10進数値に変換します。
        /// </summary>
        /// <param name="duoDecimalString">12進数文字列</param>
        /// <returns>10進数値</returns>
        private static int DuoDecimalStringToInt(string duoDecimalString)
        {
            throw new ArgumentException("無効な12進数文字が含まれています。");
            //return 0;
        }
    }
}