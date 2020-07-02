using BookingProject.Data.Models;
using BookingProject.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingProject.Web.ViewModels.Reservations
{
    public class CreateReservationViewModel : IMapFrom<Reservation>, IMapTo<Reservation>
    {
        public int PlaceId { get; set; }

        public string Dates { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PriceByNight { get; set; }

        public int TotalPrice { get; set; }

        public int NumNights { get; set; }

        //public bool Active { get; set; } = true;

        //public bool Reviewed { get; set; } = false;
    }
}
