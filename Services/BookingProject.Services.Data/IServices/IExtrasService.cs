namespace BookingProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IExtrasService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);
    }
}
