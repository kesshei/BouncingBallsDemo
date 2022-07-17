using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BouncingBallsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SKTypeface Font;
        public BouncingBalls bouncingBalls;
        public MainWindow()
        {
            InitializeComponent();
            bouncingBalls = new BouncingBalls();
            skContainer.PaintSurface += SkContainer_PaintSurface;
            // 获取宋体在字体集合中的下标
            var index = SKFontManager.Default.FontFamilies.ToList().IndexOf("微软雅黑");
            // 创建宋体字形
            Font = SKFontManager.Default.GetFontStyles(index).CreateTypeface(0);
            _ = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            skContainer.InvalidateVisual();
                        });
                        SpinWait.SpinUntil(() => false, 1000 / 60);
                    }
                    catch
                    {
                        break;
                    }
                }
            });
        }
        private void SkContainer_PaintSurface(object? sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            bouncingBalls.Render(canvas, Font, e.Info.Width, e.Info.Height);
        }
    }
}
