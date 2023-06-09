﻿using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Convertors
{
    public class FavoritesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = value as string;
            if (result == "1") 
            {
                return "ic_favorite_heart_icon.png";
            }
            else
            {
                return "ic_heart_icon.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
