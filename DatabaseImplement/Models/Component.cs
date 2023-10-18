namespace DatabaseImplement.Models;

public class Component
{
    public int Id { get; set; }

    public string ComponentName { get; set; }
    
    public virtual List<ProductComponent> ProductComponents { get; set; }
}
