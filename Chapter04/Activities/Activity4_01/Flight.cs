namespace Chapter04.Activities.Activity4_01
{
    internal record Flight(string Agency, double PaidFare, string TripType, string RouteType, string TicketClass,
        string DepartureDate, string Origin, string Destination, string DestinationCountry, string Carrier);
}