namespace API.Entities;

public class AppUser
{
    // Id is by convention for Entity Framework Table: It will be primary key.
    // Or we can tag it with [Key]. Beware of auto-incrementing integers?
    public int Id { get; set; }
    public required string UserName { get; set; }
}
