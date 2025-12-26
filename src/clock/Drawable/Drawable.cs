namespace clock.Drawable
{
    public class Drawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            var center = new PointF(dirtyRect.Center.X, dirtyRect.Center.Y);
            float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) * 0.45f;

            var currTime = TimeOnly.FromDateTime(DateTime.Now);
            if (currTime.Hour > 12.0f)
            {
                currTime = currTime.AddHours(12.0f);
            }
            
            canvas.StrokeColor = Colors.White;
            //canvas.DrawCircle(center, radius);
            canvas.DrawLine(center, GetSecondPoint(center, currTime.Minute, 60.0f, radius * 0.75f));
            canvas.StrokeSize = 1.5f;
            canvas.DrawLine(center, GetSecondPoint(center, currTime.Hour, 12.0f, radius * 0.5f));
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 0.5f;
            canvas.DrawLine(center, GetSecondPoint(center, currTime.Second, 60.0f, radius));


            canvas.SaveState();
        }

        private PointF GetSecondPoint(PointF center, int TimeUnit, float AmountOfUnit, float length)
        {
            var xz = (TimeUnit * 360) / AmountOfUnit;
            var xz_rad = Math.PI / 180 * xz;
            return new PointF((float)(length * Math.Sin(xz_rad)) + center.X, (float)(-length * Math.Cos(xz_rad)) + center.Y);
        }
    }
}
