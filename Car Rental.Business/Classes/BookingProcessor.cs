using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{

    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<IBooking> GetBooking() => _db.Get<Booking>(null);

    public IEnumerable<IPerson> GetPerson() => _db.Get<Person>(null);
    //public IPerson? GetPerson(string ssn) { }
    public IEnumerable<IVehicle> GetVehicles() => _db.Get<Vehicle>(null);
    //public IVehicle? GetVehicle(int vehicleId) { }
    //public IVehicle? GetVehicle(string regNo) { }
    //public lägg till asynkron returdata typ RentVehicle(int vehicleId, int customerId)
    //{
    //    // Använd Task.Delay för att simulera tiden det tar
    //    // att hämta data från ett API.
    //}
    //public IBooking ReturnVehicle(int vehicleId, double ditance) { }
    //public void AddVehicle<T>() => _db.Add<T>();

    //public void AddCustomer(Person person) => _db.Add(typeof(Person));
    // Calling Default Interface Methods
    //public string[] VehicleStatusNames => _db.VehicleStatusNames;
    //public string[] VehicleTypeNames => _db.VehicleTypeNames;
    //public VehicleType GetVehicleType(string name) => _db.GetVehicleType(name);
}