using CannonLaser.Repository.Models;

namespace CannonLaser.Domain.Services
{
    public interface ICannonLoader
    {
        int GetCannonCount(MeasuredHeights heights);
    }
}
