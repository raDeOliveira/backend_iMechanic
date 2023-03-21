namespace backend_iMechanic.Model
{
    public class UserNotes
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Notes { get; set; }
        public int IDChoosenCar { get; set; }
    }
}
