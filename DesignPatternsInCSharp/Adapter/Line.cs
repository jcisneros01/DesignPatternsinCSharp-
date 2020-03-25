namespace DesignPatternsInCSharp.Adapter
{
    public class Line
    {
        public Point Start;
        public Point End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}