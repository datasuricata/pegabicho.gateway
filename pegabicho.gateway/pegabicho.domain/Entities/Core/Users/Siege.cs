using pegabicho.domain.Entities.Base;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Siege : EntityBase
    {
        public virtual string AddressId { get; private set; }
        public virtual Address Address { get; private set; }

        public double Range { get; private set; }

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public double Altitude { get; private set; }

        #region [ ctor ]

        public Siege(string addressId, double range, double longitude, double latitude, double altitude)
        {
            AddressId = addressId;
            Range = range;
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }
        protected Siege()
        {

        }

        #endregion
    }
}