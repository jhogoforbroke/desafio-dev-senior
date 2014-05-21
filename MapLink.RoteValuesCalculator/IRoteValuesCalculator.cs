namespace MapLink.RoteValuesCalculator
{
    public interface IRoteValuesCalculator
    {
        RouteCost Calculate();
        RouteCost Calculate(RouteType roteType);
    }
}
