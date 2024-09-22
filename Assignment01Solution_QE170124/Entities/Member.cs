namespace Assignment01Solution_QE170124.Entities;

public class Member
{
    public int MemberID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; } // "Admin" or "User"
}