using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.Models;

namespace TestApp.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public SelectList CityList { get; set; }
    }
}
