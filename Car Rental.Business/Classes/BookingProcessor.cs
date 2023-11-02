using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Text.RegularExpressions;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public string? Error = null;

    //public string CheckVehicleType(IVehicle vehicle) { }

    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(b => b != null);
    public IBooking? GetBooking(int vehicleId) => _db.Single<Booking>(v => v.Vehicle.Id == vehicleId);
    public IEnumerable<IPerson> GetPersons()  => _db.Get<IPerson>(p => p != null);
    public IPerson? GetPerson(string ssn) => _db.Single<Person>(p => p.SSN == ssn);
    public IEnumerable<IVehicle> GetVehicles() => _db.Get<IVehicle>(v => v != null);
    public IVehicle? GetVehicle(int vehicleId) => _db.Single<IVehicle>(v => v.Id == vehicleId);
    public IVehicle? GetVehicle(string regNo) => _db.Single<IVehicle>(v => v.RegNumber == regNo);
    //public async Task<IBooking> RentVehicle(int vehicleId, int customerId);
    public IBooking? ReturnVehicle(int? vehicleId, int? distance)
    {
        double rentCost = 0;
        List<IBooking> _booking = new();
        var booking = _db.Single<IBooking>(b => b.Vehicle.Id == vehicleId && b.Status != VehicleStatus.Closed);
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
       if (booking != null && vehicle != null)
        {
            rentCost = VehicleExtensions.Duration(booking.DateRented, booking.DateReturned, vehicle, distance);
            booking.RentCost = rentCost;
            booking.Status = VehicleStatus.Closed;
            return booking;
        }
        else
        return null;
    }
    public void AddVehicle(IVehicle? iv)
    {
        var vehicles = GetVehicles();

        try
        {
            if (iv.CostKm != null || iv.Odometer != null || iv.Odometer !> 20000 || iv.CostKm != 0 || iv.CostKm! > 5 || iv.CostKm != null || iv.CostDay != null || iv.CostDay != 0 || iv.CostDay! > 300)
            {
                if (iv.RegNumber.Length == 6 && iv.RegNumber[..3].All(char.IsLetter) && iv.RegNumber[3..].All(char.IsNumber))
                {
                    var toUpper = iv.RegNumber.ToUpper();
                    iv.RegNumber = toUpper;
                    foreach (var vehicle in vehicles)
                    {
                        if (vehicle.RegNumber == iv.RegNumber)
                        {
                            Error = "Registrationnumber already exists!";
                            return;
                        }
                        else
                        {
                            Error = null;
                            _db.Add(iv);
                        }
                    }
                    
                }
                else
                    Error = "Registrationnumber must begin with three letters and end with three numbers and not be longer than 6 characters!";
            }
            else
                Error = "Registrationnumber must begin with three letters and end with three numbers and not be longer than 6 characters!";
        }
        catch
        {
            Error = "Fields can't be empty";
        }
    }

    //public lägg till asynkron returdata typ RentVehicle(int vehicleId, int customerId)
    //{
    //    // Använd Task.Delay för att simulera tiden det tar
    //    // att hämta data från ett API.
    //}
    // Calling Default Interface Methods

    public void AddPerson(IPerson ip) { ip.Id = _db.NextPersonId; _db.Add(ip); }
    public void AddBooking(IVehicle vehicle, string ssn)
    {
        var isVehicleBooked = GetBooking(vehicle.Id);
            
            if (isVehicleBooked != null)
            {
                var customer = _db.Single<IPerson>(b => b.SSN == ssn);

                if (customer == null) return;
                else
                {
                    Booking booking = new(_db.NextBookingId, customer, vehicle, (int)vehicle.Odometer, 0, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
                    _db.Add<IBooking>(booking);
                }
            }
            else
                return;
    }

    public void Add<T>(T item) where T : class => _db.Add(item);
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


//{
//    var checkType = iv.Get(Type) ? VehicleTypes.Motorcycle 
//    {
//        iv.Type = VehicleTypes.Motorcycle;
//    }
//    iv.Type == (Type)Car_Rental.Common.Classes.Car;
//    if (iv.RegNumber != string.Empty)
//    {
//        var regNr = new Regex(@"^\w{3}\d{3}$");
//        if (!regNr.IsMatch(iv.RegNumber))
//        {
//            _db.Add("Registration.nr is not correct, should be in format: (ABC123) or (abc123)!");
//        }
//        iv.RegNumber = iv.RegNumber.ToUpper();
//    }
//    Error = "Field(s) can not be empty!";
//    _db.Add(Error);

//    if (iv.Odometer != default)
//    {
//        var odometer = new Regex(@"^[0-9]*[1-9][0-9]*${6}");
//        var odmtr = iv.Odometer.ToString();

//        if (!odometer.IsMatch(odmtr))
//        {
//            _db.Add("CostKm is not correct, should be in format: Integer or double");
//        }
//    }
//    Error = "Field(s) can not be empty!";
//    _db.Add(Error);
//    if (iv.CostKm != default)
//    {
//        var kmCost = new Regex(@"(^\d{2}(?:\.\d{1})$)|(^\d{2}$)");
//        var kmC = iv.CostKm.ToString();
//        if (!kmCost.IsMatch(kmC))
//        {
//            _db.Add("Odometer is not correct, should be in format: (1 - 9)!");
//        }
//    }
//    Error = "Field(s) can not be empty!";
//    _db.Add(Error);
//}