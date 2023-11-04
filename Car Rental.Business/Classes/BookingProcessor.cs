using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public string? Error = null;
    public int Distance { get; set; }
    public bool WaitAsync { get; set; } = false;
    //public DateTime? DateReturned { get; set; }
    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(b => b != null);
    public IBooking GetBooking(int vehicleId) => _db.Single<Booking>(v => v.Id == vehicleId);
    public IEnumerable<IPerson> GetPersons() => _db.Get<IPerson>(p => p != null);
    public IPerson GetPerson(string ssn) => _db.Single<Person>(p => p.SSN == ssn);
    public IEnumerable<IVehicle> GetVehicles() => _db.Get<IVehicle>(v => v != null);
    public IVehicle GetVehicle(int vehicleId) => _db.Single<Vehicle>(v => v.Id == vehicleId);
    public IVehicle GetVehicle(string regNo) => _db.Single<Vehicle>(v => v.RegNumber == regNo);
    //public async Task<IBooking> RentVehicle(int vehicleId, int customerId);
    public IBooking ReturnVehicle(int vehicleId, int distance)
    {
        List<IBooking> _booking = new();
        var booking = _db.Single<IBooking>(b => b.Vehicle.Id == vehicleId && b.Status != VehicleStatus.Closed);
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        var rentCost = VehicleExtensions.Duration(booking.DateRented, booking.DateReturned, booking.Vehicle.CostKm, booking.Vehicle.CostDay, distance);

        vehicle.Odometer += distance;
        booking.KmReturn = vehicle.Odometer;
        booking.Status = VehicleStatus.Closed;
        vehicle.Status = VehicleStatus.Available;
        booking.RentCost = rentCost;
        return booking;
    }

    public void AddVehicle(IVehicle iv)
    {
        var vehicles = GetVehicles();

        try
        {
            if (iv.CostKm != 0 || iv.CostKm! > 5 || iv.Odometer! > 20000 || iv.CostDay != 0 || iv.CostDay! > 300)
            {
                if (iv.RegNumber.Length == 6 && iv.RegNumber[..3].All(char.IsLetter) && iv.RegNumber[3..].All(char.IsNumber))
                {
                    iv.RegNumber = iv.RegNumber.ToUpper();
                    foreach (var vehicle in vehicles)
                    {
                        if (vehicle.RegNumber == iv.RegNumber)
                        {
                            Error = "Registrationnumber already exists!";
                            return;
                        }
                    }
                    Error = null;
                    iv.Status = VehicleStatus.Available;
                    iv.Id = _db.NextVehicleId;
                    _db.Add(iv);
                }
                else
                    Error = "Reg.nr must have three letters + three numbers (in that order)!";
                return;
            }
            else
                Error = "Fields can't be empty";
            return;
        }
        catch
        {

        }
    }

    public void AddPerson(IPerson iPerson) { iPerson.Id = _db.NextPersonId; _db.Add(iPerson); }
    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    {
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        var customer = _db.Single<IPerson>(p => p.Id == customerId);
        WaitAsync = true;
        await Task.Delay(8000);
        var booking = AddBooking(vehicle, customer);
        WaitAsync = false;
        return booking;
    }
    public Booking AddBooking(IVehicle vehicle, IPerson person)
    {
        Booking booking = new(_db.NextBookingId, person, vehicle, vehicle.Odometer, null, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
        vehicle.Status = VehicleStatus.Booked;
        _db.Add<IBooking>(booking);
        return booking;
    }
    public void Add<T>(T item) where T : class
    {
            _db.Add(item);
    }
}

//public lägg till asynkron returdata typ RentVehicle(int vehicleId, int customerId)
//{
//    // Använd Task.Delay för att simulera tiden det tar
//    // att hämta data från ett API.
//}
// Calling Default Interface Methods
//public string[] VehicleStatusNames => _db.VehicleStatusNames;
//public string[] VehicleTypeNames => _db.VehicleTypeNames;
//public VehicleType GetVehicleType(string name) => _db.GetVehicleType(name);
//public string CheckVehicleType(IVehicle vehicle) { }
