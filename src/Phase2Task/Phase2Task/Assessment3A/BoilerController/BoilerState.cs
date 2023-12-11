namespace BoilerController
{
    public partial class Boiler
    {
        public enum BoilerStatus
        {
            Ready = 1,
            Lockout,
            PrePurge,
            Ignition,
            Operational,
        }
    }
}