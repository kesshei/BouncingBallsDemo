using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBallsDemo
{
    public class BouncingBalls
    {
        private List<Circles> circles;
        public BouncingBalls()
        {
            circles = new List<Circles>();
            for (int i = 0; i < 100; i++)
            {
                circles.Add(new Circles());
            }
        }
        /// <summary>
        /// 渲染
        /// </summary>
        public void Render(SKCanvas canvas, SKTypeface Font, int Width, int Height)
        {
            canvas.Clear(SKColors.White);
            DrawGrid(canvas, SKColors.LightGray, Width, Height, 10, 10);
            AdjustPosition(canvas, Font, Width, Height);

            string by = $"by 蓝创精英团队";
            using var paint = new SKPaint
            {
                Color = SKColors.Blue,
                IsAntialias = true,
                Typeface = Font,
                TextSize = 24
            };
            canvas.DrawText(by, 600, 400, paint);
        }
        /// <summary>
        /// 调整位置
        /// </summary>
        public void AdjustPosition(SKCanvas canvas, SKTypeface Font, int Width, int Height)
        {
            foreach (var circle in circles)
            {
                using var paint = new SKPaint
                {
                    Color = circle.Color,
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true,
                    StrokeWidth = 1
                };
                canvas.DrawCircle(circle.X, circle.Y, circle.Radius, paint);

                if (circle.X + circle.VelocityX + circle.Radius > Width || circle.X + circle.VelocityX - circle.Radius < 0)
                {
                    circle.VelocityX = -circle.VelocityX;
                }
                if (circle.Y + circle.VelocityY + circle.Radius > Height || circle.Y + circle.VelocityY - circle.Radius < 0)
                {
                    circle.VelocityY = -circle.VelocityY;
                }
                circle.X += circle.VelocityX;
                circle.Y += circle.VelocityY;
            }
        }
        /// <summary>
        /// 画格子
        /// </summary>
        public void DrawGrid(SKCanvas canvas, SKColor sKColor, int Width, int Height, int StepX, int StepY)
        {
            using var paint = new SKPaint
            {
                Color = sKColor,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 0.5f,
                IsStroke = true,
                IsAntialias = true
            };
            for (var i = 0.5; i < Width; i += StepX)
            {
                var path = new SKPath();
                path.MoveTo((float)i, 0);
                path.LineTo((float)i, Height);
                path.Close();
                canvas.DrawPath(path, paint);
            }
            for (var i = 0.5; i < Height; i += StepY)
            {
                var path = new SKPath();
                path.MoveTo(0, (float)i);
                path.LineTo(Width, (float)i);
                path.Close();
                canvas.DrawPath(path, paint);
            }
        }
    }
}
