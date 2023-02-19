using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Microsoft.Win32;

namespace LogPolarTransform
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(openFileDialog.FileName, UriKind.Absolute);
                bitmapImage.CreateOptions = BitmapCreateOptions.DelayCreation;
                bitmapImage.EndInit();
                imageControlLeft.Source = bitmapImage;
                imageControlRight.Source = bitmapImage;
                rotateButton.Visibility = Visibility.Visible;
            }
        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {
            if (imageControlRight.Source != null)
            {
                var bitmapImage = imageControlRight.Source as BitmapImage;
                if (bitmapImage != null)
                {
                    bitmapImage.Rotation = Rotation.Rotate90;
                    var rotatedBitmap = new TransformedBitmap(bitmapImage, new RotateTransform(90));
                    imageControlRight.Source = rotatedBitmap;
                }
            }
        }
    }
}
