namespace backend_iMechanic.Model
{
    public class UserNotes
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Notes { get; set; }
        public int Id_Choosen_Car { get; set; }
    }
}
