namespace Entities.Dtos
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
       //HashSet ayni eleman bir daha eklenemez. Bir tane daha User Role eklenemez.
    }
}