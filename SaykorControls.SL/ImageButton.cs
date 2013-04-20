using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LunarBase.Library.Extensions;

namespace SaykorControls.SL
{
    public class ImageButton : Button
    {
        Image btnNormalImage;
        Image btnPressedImage;

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(ImageButton), new PropertyMetadata(null, OnImageSourcePropertyChanged));
        private static void OnImageSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImageButton uc = (ImageButton)sender;
            uc.ImageSource = (BitmapImage)e.NewValue;
        }
        public BitmapImage ImageSource
        {
            get
            {
                return (BitmapImage)base.GetValue(ImageSourceProperty);
            }
            set
            {
                base.SetValue(ImageSourceProperty, value);
            }
        }

        public static readonly DependencyProperty PressedImageSourceProperty = DependencyProperty.Register("PressedImageSource", typeof(BitmapImage), typeof(ImageButton), new PropertyMetadata(null, OnPressedImageSourcePropertyChanged));
        private static void OnPressedImageSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ImageButton uc = (ImageButton)sender;
            uc.PressedImageSource = (BitmapImage)e.NewValue;
        }

        public BitmapImage PressedImageSource
        {
            get
            {
                return (BitmapImage)base.GetValue(PressedImageSourceProperty);
            }
            set
            {
                base.SetValue(PressedImageSourceProperty, value);
            }
        }

        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            btnNormalImage = this.GetTemplateChild("btnNormalImage") as Image;
            if (btnNormalImage != null)
                btnNormalImage.SetBinding(Image.SourceProperty, this, "ImageSource");
            btnPressedImage = this.GetTemplateChild("btnPressedImage") as Image;
            if (btnPressedImage != null)
                btnPressedImage.SetBinding(Image.SourceProperty, this, "PressedImageSource");
        }

        void btnNormalImage_Loaded(object sender, RoutedEventArgs e)
        {
            //ChangeImageSource();
        }

        //private void ChangeImageSource()
        //{
        //    if (ImageSource != null && btnNormalImage != null)
        //        btnNormalImage.Source = new BitmapImage(new Uri(ImageSource, UriKind.RelativeOrAbsolute));
        //}

        void btnPressedImage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (PressedImageSource != null)
            //    btnPressedImage.Source = new BitmapImage(new Uri(PressedImageSource, UriKind.RelativeOrAbsolute));
        }

        public void InvokeClick()
        {
            base.OnClick();
        }
    }
}
