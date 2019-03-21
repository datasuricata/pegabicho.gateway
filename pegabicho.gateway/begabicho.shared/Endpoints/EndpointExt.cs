using System;
using System.Collections.Generic;
using System.Text;

namespace begabicho.shared.Endpoints
{
    public static class EndpointExt
    {
        #region [ parameters ]

        // # google host
        public const string Google = "https://www.google.com.br/";

        // # google api
        public const string GoogleApi = "https://maps.googleapis.com/";

        #endregion

        #region [ Google ]

        /// <summary>
        /// Use this to retrive route of public transport, with many type of vehicles
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="key"></param>
        /// <returns>Url Google Direction API</returns>
        public static string GoogleDirection(string origin, string destination, string key)
        {
            var b = new StringBuilder();

            b.Append(GoogleApi);
            b.Append(GDirections);
            b.Append("origin=" + origin);
            b.Append("&destination=" + destination);
            b.Append("&language=pt-BR");
            b.Append("&key=" + key);

            return b.ToString();
        }

        /// <summary>
        /// Use this to retrive calc about time travel to many directions
        /// </summary>
        /// <param name="origins"></param>
        /// <param name="destinations"></param>
        /// <param name="key"></param>
        /// <returns>Google infos with many locations</returns>
        public static string GoogleMatrix(string[] origins, string[] destinations, string key)
        {
            var b = new StringBuilder();

            b.Append(GoogleApi);
            b.Append(GMatrix);
            //            b.Append("origin=" + origin);|
            //            b.Append("&destination=" + destination);
            b.Append("&language=pt-BR");
            b.Append("&key=" + key);

            return b.ToString();
        }

        /// <summary>
        /// Use this to retrive a precise traject with vehicle
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GoogleRoads(string origin, string destination, string key)
        {
            var b = new StringBuilder();

            return b.ToString();
        }

        /// <summary>
        /// Use this to retrive a map search using url between plataforms
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns>Google url to make a map</returns>
        public static string GoogleMapUrl(string origin, string destination)
        {
            var b = new StringBuilder();

            b.Append(Google);
            b.Append(GMaps);
            b.Append("&origin=" + origin.Replace(" ", "+"));
            b.Append("&destination=" + destination.Replace(" ", "+"));
            b.Append("&travelmode=driving");

            return b.ToString();
        }

        /// <summary>
        /// Use this to retrive a new search from google url
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Google url to make a search</returns>
        public static string GoogleMapUrlSearch(string parameter)
        {
            var b = new StringBuilder();

            b.Append(Google);
            b.Append(GMapsSearch);
            b.Append(parameter.Replace(" ", "+"));

            return b.ToString();
        }

        #region [ Private ]

        // # action - google api directions
        private const string GDirections = "maps/api/directions/json?";

        // # action - google api matrix (direction metrics)
        private const string GMatrix = "distancematrix/json?";

        // # action - google api roads
        private const string GRoads = "roads";

        // # action - google url maps
        private const string GMaps = "maps/dir/?api=1";

        // # action - google url maps search
        private const string GMapsSearch = "maps/search/?api=1&query=";

        #endregion

        #endregion
    }
}
