namespace BookingProject.Web.ViewModels.Places
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookingProject.Data.Models;
    using BookingProject.Services.Mapping;

    public class EditPlaceViewModel : IMapTo<Place>, IMapFrom<Place>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето 'Категория' е задължително.")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Полето 'Град' е задължително.")]
        [Range(1, int.MaxValue)]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public string CityName { get; set; }

        [Required(ErrorMessage = "Полето 'Адрес' е задължително.")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Полето 'Описание' е задължително.")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето 'Цена за нощувка' е задължително.")]
        [Range(1, int.MaxValue, ErrorMessage = "Въведете стойност, по-голяма от 0.")]

        public int PriceByNight { get; set; }

        [Required(ErrorMessage = "Полето 'Брой спални стаи' е задължително.")]
        public int BedroomsNum { get; set; }

        [Required(ErrorMessage = "Полето 'Брой бани' е задължително.")]

        public int BathroomsNum { get; set; }

        [Required(ErrorMessage = "Полето 'Брой легла' е задължително.")]
        [Range(1, 30, ErrorMessage = "Въведете стойност между 1 и 30.")]
        [Display(Name = "BedsNum")]

        public int BedsNum { get; set; }

        [Required(ErrorMessage = "Полето 'Максимум гости' е задължително.")]
        [Range(1, 30, ErrorMessage = "Въведете стойност между 1 и 30.")]

        public int MaxGuest { get; set; }

        public bool Pets { get; set; }

        public bool Smoking { get; set; }

        public List<PlaceExtra> PlaceExtras { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }

        public IEnumerable<CityDropDownViewModel> Cities { get; set; }

        public List<ExtraViewModel> Extras { get; set; }

        public ApplicationUser User { get; set; }
    }
}
