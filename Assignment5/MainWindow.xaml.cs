using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Assignment5
{
  
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private int horizontalOffset = 150;
        private int hairOffset = 0;
        private int eyesOffset = 200;
        private int noseOffset = 400;
        private int mouthOffset = 600;

        private List<BitmapImage> hair = new List<BitmapImage>();
        private List<BitmapImage> eyes = new List<BitmapImage>();
        private List<BitmapImage> nose = new List<BitmapImage>();
        private List<BitmapImage> mouth = new List<BitmapImage>();

        private CommandHandler hair1;
        private CommandHandler hair2;
        private CommandHandler hair3;
        private CommandHandler hair4;
        private CommandHandler eyes1;
        private CommandHandler eyes2;
        private CommandHandler eyes3;
        private CommandHandler eyes4;
        private CommandHandler nose1;
        private CommandHandler nose2;
        private CommandHandler nose3;
        private CommandHandler nose4;
        private CommandHandler mouth1;
        private CommandHandler mouth2;
        private CommandHandler mouth3;
        private CommandHandler mouth4;
        private CommandHandler help1;
        private CommandHandler help2;

        public MainWindow()
        {
            SetupImages();
            InitializeComponent();
            SetupHandlers();
        }

        private void SetupHandlers()
        {
            hair1 = new CommandHandler(() => GetImage(horizontalOffset, hairOffset, hair[0]), true);
            hair2 = new CommandHandler(() => GetImage(horizontalOffset, hairOffset, hair[1]), true);
            hair3 = new CommandHandler(() => GetImage(horizontalOffset, hairOffset, hair[2]), true);
            hair4 = new CommandHandler(() => GetImage(horizontalOffset, hairOffset, hair[3]), true);
            
            eyes1 = new CommandHandler(() => GetImage(horizontalOffset, eyesOffset, eyes[0]), true);
            eyes2 = new CommandHandler(() => GetImage(horizontalOffset, eyesOffset, eyes[1]), true);
            eyes3 = new CommandHandler(() => GetImage(horizontalOffset, eyesOffset, eyes[2]), true);
            eyes4 = new CommandHandler(() => GetImage(horizontalOffset, eyesOffset, eyes[3]), true);

            nose1 = new CommandHandler(() => GetImage(horizontalOffset, noseOffset, nose[0]), true);
            nose2 = new CommandHandler(() => GetImage(horizontalOffset, noseOffset, nose[1]), true);
            nose3 = new CommandHandler(() => GetImage(horizontalOffset, noseOffset, nose[2]), true);
            nose4 = new CommandHandler(() => GetImage(horizontalOffset, noseOffset, nose[3]), true);

            mouth1 = new CommandHandler(() => GetImage(horizontalOffset, mouthOffset, mouth[0]), true);
            mouth2 = new CommandHandler(() => GetImage(horizontalOffset, mouthOffset, mouth[1]), true);
            mouth3 = new CommandHandler(() => GetImage(horizontalOffset, mouthOffset, mouth[2]), true);
            mouth4 = new CommandHandler(() => GetImage(horizontalOffset, mouthOffset, mouth[3]), true);

            help1 = new CommandHandler(() => Get_Doc_Help(), true);
            help2 = new CommandHandler(() => Get_Web_Help(), true);

            DataContext = new
            {
                hairCMD1 = hair1,
                hairCMD2 = hair2,
                hairCMD3 = hair3,
                hairCMD4 = hair4,
                eyesCMD1 = eyes1,
                eyesCMD2 = eyes2,
                eyesCMD3 = eyes3,
                eyesCMD4 = eyes4,
                noseCMD1 = nose1,
                noseCMD2 = nose2,
                noseCMD3 = nose3,
                noseCMD4 = nose4,
                mouthCMD1 = mouth1,
                mouthCMD2 = mouth2,
                mouthCMD3 = mouth3,
                mouthCMD4 = mouth4,
                helpCMD1 = help1,
                helpCMD2 = help2,
            };
            InputBindings.Add(new KeyBinding(hair1, new KeyGesture(Key.D1, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(hair2, new KeyGesture(Key.D2, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(hair3, new KeyGesture(Key.D3, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(hair4, new KeyGesture(Key.D4, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(eyes1, new KeyGesture(Key.Q, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(eyes2, new KeyGesture(Key.W, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(eyes3, new KeyGesture(Key.E, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(eyes4, new KeyGesture(Key.R, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(nose1, new KeyGesture(Key.A, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(nose2, new KeyGesture(Key.S, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(nose3, new KeyGesture(Key.D, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(nose4, new KeyGesture(Key.F, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(mouth1, new KeyGesture(Key.Z, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(mouth2, new KeyGesture(Key.X, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(mouth3, new KeyGesture(Key.C, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(mouth4, new KeyGesture(Key.V, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(help1, new KeyGesture(Key.H, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(help2, new KeyGesture(Key.J, ModifierKeys.Control)));
        }

        private void SetupImages()
        {
            for (int i = 1; i < 5; i++)
            {
                hair.Add(new BitmapImage(new Uri("../../images/Guy"+i+"P1.png", UriKind.Relative)));
                eyes.Add(new BitmapImage(new Uri("../../images/Guy"+i+"P2.png", UriKind.Relative)));
                nose.Add(new BitmapImage(new Uri("../../images/Guy"+i+"P3.png", UriKind.Relative)));
                mouth.Add(new BitmapImage(new Uri("../../images/Guy"+i+"P4.png", UriKind.Relative)));
            }
        }
        
        private void GetImage(int xLoc1, int yLoc1, BitmapImage BMimg)
        {
            Image img = new Image();
            img.Source = BMimg;
            img.Width = BMimg.Width;
            img.Height = BMimg.Height;
            Canvas.SetLeft(img, xLoc1);
            Canvas.SetTop(img, yLoc1);
            myCanvas.Children.Add(img);
        }

        private void Combo_Changed(object sender, RoutedEventArgs e)
        {
            if (Combo.SelectedItem is ComboBoxItem selectedItem)
            {
                int value = int.Parse(selectedItem.Tag.ToString());
                GetImage(horizontalOffset, hairOffset, hair[value]);
            }
        }
        private void Eyes_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                int value = int.Parse(checkBox.Tag.ToString());
                GetImage(horizontalOffset, eyesOffset, eyes[value]);
            }       
        }

        private void Nose_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                int value = int.Parse(radioButton.Tag.ToString());
                GetImage(horizontalOffset, noseOffset, nose[value]);
            }
        }

        private void Value_Changed(object sender, RoutedEventArgs e)
        {
            GetImage(horizontalOffset, mouthOffset, mouth[(int)Slider.Value-1]);
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            GetImage(horizontalOffset, hairOffset, hair[random.Next(0, 4)]);
            GetImage(horizontalOffset, eyesOffset, eyes[random.Next(0, 4)]);
            GetImage(horizontalOffset, noseOffset, nose[random.Next(0, 4)]);
            GetImage(horizontalOffset, mouthOffset, mouth[random.Next(0, 4)]);
        }

        public void Help_Click(object sender, RoutedEventArgs e)
        {
            Get_Doc_Help();
        }

        public void Help_Click_2(object sender, RoutedEventArgs e)
        {
            Get_Web_Help();
        }

        public void Get_Doc_Help()
        {
            string filePath = @"..\..\FaceHelp.chm";
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void Get_Web_Help()
        {
            string url = "https://jermnet.github.io/CSharpAssignment5/FaceHelp.html";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
