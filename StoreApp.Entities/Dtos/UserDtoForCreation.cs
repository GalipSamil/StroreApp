using StoreApp.Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities.Dtos
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }
    }
}