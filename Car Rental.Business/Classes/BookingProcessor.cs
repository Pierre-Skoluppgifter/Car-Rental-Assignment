using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    public int Distance { get; set; }
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

    public async Task RentVehicle(int vehicleId, int customerId)
    {
        WaitAsync = true;
        await Task.Delay(5000);
        _db.RentVehicle(vehicleId, customerId);
        WaitAsync = false;
    }
    public async Task ReturnVehicle(int vehicleId, int distance)
    {
        var booking = _db.Single<IBooking>(b => b.Vehicle.Id == vehicleId && b.Status != VehicleStatus.Available);
        
        WaitAsync = true;
        await Task.Delay(2000);
        WaitAsync = false;
        booking.KmReturn = distance;
        _db.ReturnVehicle(vehicleId);
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
                    _db.Error = null;
                    iv.Status = VehicleStatus.Available;
                    _db.Add(iv);
                }
                else
                    _db.Error = "Reg.nr must have three letters + three numbers (in that order)!";
                return;
            }
            else
                _db.Error = "One or more field(s) are incorrect!";
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
            _db.Add(iPerson);
            _db.Error = null;
        }
        else
        {
            _db.Error = "Ssn can not be longer or shorter than 6 numbers! (123456)";
            return;
        }
    }
}
