namespace backend.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Option { get; set; }
        public string Engine_Cylinders { get; set; }
        public string Engine_Displacement { get; set; }
        public string Engine_Power { get; set; }
        public string Engine_Torque { get; set; }
        public string Engine_Fuel_System { get; set; }
        public string Engine_Fuel { get; set; }
        public string Engine_C2o { get; set; }
        public string Engine_Top_Speed { get; set; }
        public string Engine_Acceleration { get; set; }
        public string Fuel_Economy_City { get; set; }
        public string Fuel_Economy_Highway { get; set; }
        public string Fuel_Economy_Combined { get; set; }
        public string Transmission_Drive_Type { get; set; }
        public string Transmission_Gearbox { get; set; }
        public string Brakes_Front { get; set; }
        public string Brakes_Rear { get; set; }
        public string Tires_Size { get; set; }
        public string Dimensions_Length { get; set; }
        public string Dimensions_Width { get; set; }
        public string Dimensions_Height { get; set; }
        public string Dimensions_Front_Rear_Track { get; set; }
        public string Dimensions_Wheelbase { get; set; }
        public string Dimensions_Ground_Clearence { get; set; }
        public string Dimensions_Cargo_Volume { get; set; }
        public string Dimensions_Cd { get; set; }
        public string Weight_Unladen { get; set; }
        public string Weight_Limit { get; set; }
    }
}
