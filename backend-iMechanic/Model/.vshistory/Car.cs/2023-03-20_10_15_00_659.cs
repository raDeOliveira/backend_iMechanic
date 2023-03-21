namespace backend_iMechanic.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Option { get; set; }
        public string EngineCylinders { get; set; }
        public string EngineDisplacement { get; set; }
        public string EnginePower { get; set; }
        public string EngineTorque { get; set; }
        public string EngineFuelSystem { get; set; }
        public string EngineFuel { get; set; }
        public string EngineC2o { get; set; }
        public string PerformanceTopSpeed { get; set; }
        public string PerformanceAcceleration { get; set; }
        public string FuelEconomyCity { get; set; }
        public string FuelEconomyHighway { get; set; }
        public string FuelEconomyCombined { get; set; }
        public string TransmissionDriveType { get; set; }
        public string TransmissionGearbox { get; set; }
        public string BrakesFront { get; set; }
        public string BrakesRear { get; set; }
        public string TiresSize { get; set; }
        public string DimensionsLength { get; set; }
        public string DimensionsWidth { get; set; }
        public string DimensionsHeigth { get; set; }
        public string DimensionsFrontRearTrack { get; set; }
        public string DimensionsWheelbase { get; set; }
        public string DimensionsGroundClearance { get; set; }
        public string DimensionsCargoVolume { get; set; }
        public string DimensionsCd { get; set; }
        public string WeigthUnladen { get; set; }
        public string WeigthLimit { get; set; }
    }
}
