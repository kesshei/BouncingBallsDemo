using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBallsDemo
{
/// <summary>
/// 圆圈
/// </summary>
internal class Circles
{
    private Random r = new Random();
    public Circles()
    {
        VelocityX = GetRandom(0, 3);
        VelocityY = GetRandom(0, 3);
        Radius = GetRandom(0, 50);
        Color = new SKColor((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255));
    }
    public float X { get; set; } = 100;
    public float Y { get; set; } = 100;
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
    public float Radius { get; set; }
    public SKColor Color { get; set; }

    public float GetRandom(int min, int max)
    {
        var result = r.Next(min * 100, max * 100);
        return (float)(result / 100.0);
    }
}
}
