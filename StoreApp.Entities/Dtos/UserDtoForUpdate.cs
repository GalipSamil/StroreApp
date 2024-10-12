using StoreApp.Entities.;
using StoreApp.Entities.Dtos;

namespace StoreApp.Entities.Models
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}