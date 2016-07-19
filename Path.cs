namespace RouterSample
{
    public class Path<T>
    {
        public T Source { get; set; }
        public T Destination { get; set; }
        public int Cost { get; set; }
    }
}
