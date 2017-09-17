using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace TestApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage ="Поле ФИО не может быть пустым")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле Телефон не может быть пустым")]
        [RegularExpression(@"^\+7\([0-9]{3}\)[0-9]{3}\s[0-9]{2}\s[0-9]{2}$", ErrorMessage = "Введите номер в формате +7(ХХХ)ХХХ ХХ ХХ")]
        [MaxLength(16)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле Email не может быть пустым")]
        [RegularExpression(@"^\S+@\S+$")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Display(Name="Город")]
        [Required(ErrorMessage = "Поле Город не может быть пустым")]
        [MaxLength(50)]
        public string City { get; set; }

        public bool saveUser()
        {
            SqlConnection conn = null;
           
            int result = -1;

            try
            {
                string conString = Startup.configurationRoot.GetSection("ConnectionStrings")["DefaultConnection"];
                conn = new SqlConnection(conString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_add_user", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@Name", Name));
                cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@City", City));

                result = cmd.ExecuteNonQuery();
                                
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            if (result < 0)
            {
                return false; //error
            }
            else
            {
                return true; //all good
            }
        }
    }
}
