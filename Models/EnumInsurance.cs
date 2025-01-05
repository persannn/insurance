namespace Insurance_Two_Tables.Models
{
    [Flags]
    public enum Insurance
    {
        None = 0,
        Life = 1,
        Health = 2,
        House = 4,
        Car = 8
    }
}