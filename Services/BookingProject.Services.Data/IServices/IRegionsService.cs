using System;
using System.Collections.Generic;
using System.Text;

namespace BookingProject.Services.Data
{
    public interface IRegionsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        T GetById<T>(int id);
    }
}
