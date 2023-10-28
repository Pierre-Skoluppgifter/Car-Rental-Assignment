using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public string Error { get; set; }
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(b => b != null);
    public IEnumerable<IPerson> GetPersons() => _db.Get<IPerson>(p => p != null);
    public IEnumerable<IVehicle> GetVehicles() => _db.Get<IVehicle>(v => v != null);
    public void AddVehicle(IVehicle iv) { iv.Id = _db.NextVehicleId;iv.Status = VehicleStatus.Available; _db.Add(iv); }
    public void AddPerson(IPerson ip) => _db.Add(ip);
    public void AddBooking(IBooking ib) => _db.Add(ib);

    //public void Add<T>(T item) where T : class => _db.Add(item);

    //public IBooking ReturnVehicle(int vehicleId, double distance)
    //{
    //    List<T>.RemoveAll(Predicate < T > match)
    //}
    //public IPerson? GetPerson(string ssn) { }
    //public IVehicle? GetVehicle(int vehicleId) { }
    //public IVehicle? GetVehicle(string regNo) { }
    //public lägg till asynkron returdata typ RentVehicle(int vehicleId, int customerId)
    //{
    //    // Använd Task.Delay för att simulera tiden det tar
    //    // att hämta data från ett API.
    //}
    // Calling Default Interface Methods
    //public string[] VehicleStatusNames => _db.VehicleStatusNames;
    //public string[] VehicleTypeNames => _db.VehicleTypeNames;
    //public VehicleType GetVehicleType(string name) => _db.GetVehicleType(name);
}

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