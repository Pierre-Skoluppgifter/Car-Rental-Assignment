using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public string[] VehicleStatusNames { get; }
    public string[] VehicleTypeNames { get; }
    public string? Error = null;
    public bool WaitAsync { get; set; } = false;

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
    public async Task ReturnVehicle(int vehicleId, int distance)
    {
        var dateReturn = DateTime.Now;
        List<IBooking> _booking = new();
        var booking = _db.Single<IBooking>(b => b.Vehicle.Id == vehicleId && b.Status != VehicleStatus.Closed);
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        var rentCost = VehicleExtensions.Duration(booking.DateRented, booking.DateReturned, booking.Vehicle.CostKm, booking.Vehicle.CostDay, distance);

        WaitAsync = true;
        await Task.Delay(3000);
        vehicle.Odometer += distance;
        booking.KmReturn = vehicle.Odometer;
        booking.Status = VehicleStatus.Closed;
        vehicle.Status = VehicleStatus.Available;
        booking.RentCost = rentCost;
        WaitAsync = false;
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
                    Add(iv);

                }
                else
                    Error = "Reg.nr must have three letters + three numbers (in that order)!";
                return;
            }
            else
                Error = "Fields can't be empty except for Odometer!";
            return;
        }
        catch
        {

        }
    }

    public void AddPerson(IPerson iPerson)
    {
        if (iPerson.SSN.Length == 6)
        {
            iPerson.Id = _db.NextPersonId;
            Add(iPerson);
            Error = null;
        }
        else
        {
            Error = "Ssn can not be longer or shorter than 6 numbers! (123456)";
            return;
        }
    }
    public async Task RentVehicle(int vehicleId, int customerId)
    {
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        var customer = _db.Single<IPerson>(p => p.Id == customerId);
        WaitAsync = true;
        await Task.Delay(8000);
        AddBooking(vehicle, customer);
        WaitAsync = false;

    }
    public void AddBooking(IVehicle vehicle, IPerson person)
    {
        Booking booking = new(_db.NextBookingId, person, vehicle, vehicle.Odometer, null, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
        vehicle.Status = VehicleStatus.Booked;
        _db.Add<IBooking>(booking);
    }
    public void Add<T>(T item) where T : class
    {
        _db.Add(item);
    }
    //public string[] VehicleStatusNames()
    //{
    //    string[] status = new string[5];
    //    for (int i = 0; i < status.Length; i++)
    //    {
    //        status[i] = Enum.GetNames(typeof(VehicleBrands)).ToString();
    //    }
    //    return status;
    //}
    //public static string[] VehicleTypeNames()
    //{
    //    string[] type = new string[5];
    //public string[] VehicleStatusNames { get; }
    //    for (int i = 0; i < type.Length; i++)
    //    {
    //        type[i] = Enum.GetNames(typeof(VehicleBrands)).ToString();
    //    }
    //    return type;
    //}
    //public VehicleTypes GetVehicleType(string name) => Enum.GetNames(<VehicleTypes>(x => x == name);
}
