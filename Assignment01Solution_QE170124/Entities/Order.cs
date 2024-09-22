namespace Assignment01Solution_QE170124.Entities;

public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int MemberID { get; set; }
}