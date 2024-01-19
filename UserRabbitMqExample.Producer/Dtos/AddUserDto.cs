namespace UserRabbitMqExample.Producer.Dtos
{
    public class AddUserDto
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
