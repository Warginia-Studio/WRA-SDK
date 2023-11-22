namespace WRA.Utility.Raycasts
{
    public class RaycastHitInfo<T>
    {
        public T RaycastHit2D { get; set; }
        public float AliveTime { get; set; } = 0;
    }
}
