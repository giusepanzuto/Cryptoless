using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptoless
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region - Model -

        public static readonly DependencyProperty SourceTextProperty =
            DependencyProperty.Register("SourceText", typeof(string), typeof(MainWindow), new UIPropertyMetadata("", SourceTextChanged));
        public string SourceText
        {
            get { return (string)GetValue(SourceTextProperty); }
            set { SetValue(SourceTextProperty, value); }
        }
        public static void SourceTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var m = (MainWindow)d;
            var r = ((string)e.NewValue).ToCharArray();

            if (r.Length > 2)
            {
                var rnd = new Random();
                int start = 1;
                for (int i = 1; i < r.Length; i++)
                {
                    if (char.IsLetter(r[i]) == false || i == r.Length -1)
                    {
                        if (start != -1)
                        {
                            int end = i - 1;
                            for (int j = start + 1; j < end; j++)
                            {
                                var k = rnd.Next(start + 1, end - 1);
                                var tmp = r[j];
                                r[j] = r[k];
                                r[k] = tmp;
                            }
                            start = -1;
                        }
                    }
                    else if (start == -1)
                    {
                        start = i;
                    }
                }
            }

            m.ResultText = new string(r);
        }

        public static readonly DependencyProperty ResultTextProperty =
            DependencyProperty.Register("ResultText", typeof(string), typeof(MainWindow), new UIPropertyMetadata(""));
        public string ResultText
        {
            get { return (string)GetValue(ResultTextProperty); }
            set { SetValue(ResultTextProperty, value); }
        }

        #endregion
    }
}
