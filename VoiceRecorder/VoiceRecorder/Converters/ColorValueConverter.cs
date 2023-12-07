/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Globalization;
using Xamarin.Forms;

namespace VoiceRecorder.Converters
{
    public class ColorValueConverter : IValueConverter
    {
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strColor = (string)value;

            if (string.IsNullOrEmpty(strColor) || strColor.Length != 6)
                return Color.Transparent;

            return Color.FromHex((string)value);
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}