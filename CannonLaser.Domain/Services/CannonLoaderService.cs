using CannonLaser.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonLaser.Domain.Services
{
    public class CannonLoaderService : ICannonLoader
    {
        public int GetCannonCount(MeasuredHeights heights)
        {
            int n = heights.Height.Count();

            // Find the peak heights
            List<int> peaks = new List<int>();
            for (int i = 1; i < n - 1; i++)
            {
                if (heights.Height.ElementAt(i) > heights.Height.ElementAt(i - 1) 
                    && heights.Height.ElementAt(i) > heights.Height.ElementAt(i + 1))
                {
                    peaks.Add(i);
                }
            }

            // Place cannons on peaks
            int cannonsPlaced = 0;
            int prevCannonPos = -1;
            foreach (int peak in peaks)
            {
                if (prevCannonPos == -1 || peak - prevCannonPos >= cannonsPlaced + 1)
                {
                    cannonsPlaced++;
                    prevCannonPos = peak;
                }
            }

            return cannonsPlaced;
        }
    }
}
