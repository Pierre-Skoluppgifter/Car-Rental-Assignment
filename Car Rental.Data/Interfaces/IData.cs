using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    IEnumerable<IVehicle> GetVehicles();
    IEnumerable<IPerson> GetPersons();
    IEnumerable<IBooking> GetBookings();
}
