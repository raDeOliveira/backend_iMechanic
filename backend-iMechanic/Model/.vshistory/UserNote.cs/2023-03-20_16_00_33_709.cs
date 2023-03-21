namespace backend_iMechanic.Model
{
    public class UserNote
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string? Notes { get; set; } = null;
        public int Id_Choosen_Car { get; set; }
    }
}
