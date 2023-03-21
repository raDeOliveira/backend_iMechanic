namespace backend_iMechanic.Model
{
    public class UserNote
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Notes { get; set; } = null;
        public int IDChoosenCar { get; set; }
    }
}
