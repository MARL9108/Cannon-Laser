using CannonLaser.Repository.Response;

namespace CannonLaser.Repository.Models
{
    public class MeasuredHeights
    {
        public MeasuredHeights(List<uint> height)
        {
            Height = height;
        }
        public List<uint> Height { get; set; }
    }
}
