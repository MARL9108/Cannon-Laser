using CannonLaser.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CannonLaser.Domain.Services
{
    public class Validator<T>
    {
        public string ValidateRequest(T request)
        {
            var response = String.Empty;

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(List<uint>))
                {
                    var value = (List<uint>)property.GetValue(request);
                    if (value == null || value.Count == 0)
                    {
                        response = $"Property {property.Name} cannot be empty.";
                        return response;
                    }
                }
                else
                {
                    response = $"Property {property.Name} must be an collection of numbers.";
                }
            }
            return response;
        }
    }
}
