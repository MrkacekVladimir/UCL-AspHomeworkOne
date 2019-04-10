using System;
using System.ComponentModel.DataAnnotations;
using AspHomework.DAL.Entities;
using AspHomework.WebUI.ViewModels.Shared;

namespace AspHomework.WebUI.ViewModels.Reservations
{
    public class ConfirmationViewModel: BaseViewModel   
    {
        public ConfirmationViewModel()
        {
            this.PageTitle = "Confirmation";
        }
                
        [Required]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^\+[0-9]{3} [0-9]{3} [0-9]{3} [0-9]{3}$", 
            ErrorMessage = "Supplied phone number is in a wrong format. Ex. +XXX XXX XXX XXX")]
        public string Phone { get; set; }
        [MaxLength(500)]
        public string Note { get; set; }

        public Room Room { get; set; }
        public long RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}