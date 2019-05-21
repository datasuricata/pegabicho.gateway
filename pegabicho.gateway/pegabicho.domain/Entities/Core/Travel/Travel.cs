﻿using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace pegabicho.domain.Entities.Core.Travel {
    public class Travel : EntityBase {

        #region [ attributes ]

        public string OrderId { get; private set; }
        public Order Order { get; private set; }

        public double FromLongitude { get; private set; }
        public double FromLatitude { get; private set; }

        public double ToLongitude { get; private set; }
        public double ToLatitude { get; private set; }

        /// <summary>
        /// Usada para o agendamento
        /// </summary>
        public DateTimeOffset? Scheduled { get; private set; }

        #endregion

        #region [ ctor ]

        protected Travel() {

        }

        public Travel(string orderId, double fromLg, double fromLt, double toLg, double toLt, DateTimeOffset? scheduled) {
            OrderId = orderId;
            FromLongitude = fromLg;
            FromLatitude = fromLt;
            ToLongitude = toLg;
            ToLatitude = toLt;
            Scheduled = scheduled;
        }

        #endregion

        #region [ methods ]

        public void ChangeDestination(double longitude, double latitude) {
            ToLongitude = longitude;
            ToLatitude = latitude;
        }

        public void ChangeLocation(double longitude, double latitude) {
            FromLatitude = latitude;
            FromLongitude = longitude;
        }

        #endregion
    }
}
