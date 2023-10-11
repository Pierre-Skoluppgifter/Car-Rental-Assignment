using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor : IData
{
    private IData _data;
    public BookingProcessor(IData data)
    {
        _data = data;
    }
    public IEnumerable<IVehicle> GetVehicles() => _data.GetVehicles().ToList();
    public IEnumerable<IPerson> GetPersons() => _data.GetPersons().ToList();
    public IEnumerable<IBooking> GetBookings() => _data.GetBookings().ToList();




}
