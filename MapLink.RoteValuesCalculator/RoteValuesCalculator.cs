using System;
using System.Collections.Generic;
using MapLink.RoteValuesCalculator.RouteService;

namespace MapLink.RoteValuesCalculator
{
    public class RoteValuesCalculator : IRoteValuesCalculator
    {
        public List<Address> Addresses { get; set; }

        private Vehicle _vehicle;

        private readonly string _token = Config.AccessToken;

        private readonly RouteOptions _routeOptions;
        private RouteDetails _routeDetails;
        private RouteInfo _routeInfo;

        public RoteValuesCalculator(Vehicle vehicle)
        {
            _vehicle = vehicle;

            _routeOptions = new RouteOptions();
            _routeOptions.language = Config.Language;
            _routeOptions.routeDetails = _routeDetails;
            _routeOptions.vehicle = _vehicle;
        }

        public RouteCost Calculate()
        {
            return RequestRouteCost(RouteType.Default);
        }

        public RouteCost Calculate(RouteType routeType)
        {
            return RequestRouteCost(routeType);
        }

        private RouteCost RequestRouteCost(RouteType routeType)
        {
            _routeDetails = new RouteDetails();
            _routeDetails.descriptionType = Config.DesciptionType;
            _routeDetails.optimizeRoute = true;
            _routeDetails.routeType = Convert.ToInt32(routeType);

            _routeOptions.routeDetails = _routeDetails;

            using (var routeSoapClient = new RouteSoapClient())
            {
                _routeInfo = routeSoapClient.getRoute(GenerateRouteStop(), _routeOptions, _token);
            }

            return new RouteCost
            {
                TotalDistance = _routeInfo.routeTotals.totalDistance,
                TotalFuelCost = _routeInfo.routeTotals.totalfuelCost,
                TotalCostWithToll = _routeInfo.routeTotals.totalCost,
                TotalTimeRote = _routeInfo.routeTotals.totalTime
            };
        }

        private RouteStop[] GenerateRouteStop()
        {
            if (Addresses.Count > 0 || Addresses != null)
            {
                var routes = new RouteStop[Addresses.Count];

                int i = 0;
                foreach (var address in Addresses)
                {
                    var RoutePoint = new RouteService.Point
                    {
                        x = address.Point.x,
                        y = address.Point.y
                    };

                    routes[i++] = new RouteStop
                    {
                        description = address.ToString(),
                        point = RoutePoint
                    };
                }

                return routes;
            }
            else
                throw new ArgumentNullException("Adresses");
        }
    }
}
