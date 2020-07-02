namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICitiesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
