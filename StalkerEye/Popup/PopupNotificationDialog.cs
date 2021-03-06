﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Myevan;

namespace StalkerEye
{
    public class PopupNotificationDialog
    {
        public Popup popup;

        public PopupNotificationDialog(string message, PopupNotificationDialog dialog)
        {
            popup = new Popup();

            popup.text.Text = Korean.ReplaceJosa(message);

            popup.Width = 60 + MeasureString(popup.text.Text);
            CornerRadius cornerRadius = new CornerRadius(5);
            popup.background.CornerRadius = cornerRadius;

            popup.Left = 20;

            if(dialog != null)
            {
                popup.Top = 7 + dialog.popup.Top + dialog.popup.Height;
            }
            else
            {
                popup.Top = 20;
            }
        }

        public void Show()
        {
            popup.Show();
        }

        private double MeasureString(string candidate)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(popup.text.FontFamily, popup.text.FontStyle, popup.text.FontWeight, popup.text.FontStretch),
                popup.text.FontSize,
                Brushes.Black,
                new NumberSubstitution());

            return formattedText.Width;
        }
    }
}
