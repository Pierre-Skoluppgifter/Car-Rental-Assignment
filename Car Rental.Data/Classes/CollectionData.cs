using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new();
        readonly List<IVehicle> _vehicles = new();
        readonly List<IBooking> _bookings = new();

        public CollectionData() => SeedData();

        void SeedData()
        {
            var car1 = new Car("HGE654", VehicleBrands.Volvo, 3500, 3, VehicleTypes.SUV, 200, VehicleStatuses.Available);
            _vehicles.Add(car1);
            var car2 = new Car("DRF547", VehicleBrands.Tesla, 5000, 2.3, VehicleTypes.Sedan, 250, VehicleStatuses.Available);
            _vehicles.Add(car2);
            var car3 = new Car("HJJ223", VehicleBrands.VolksWagen, 2300, 2.5, VehicleTypes.Stationwagon, 150, VehicleStatuses.Closed);
            _vehicles.Add(car3);
            var car4 = new Car("MNB159", VehicleBrands.Jeep, 550, 3, VehicleTypes.Jeep, 300, VehicleStatuses.Available);
            _vehicles.Add(car4);
            var motorcycle1 = new Motorcycle("OSK444", VehicleBrands.Yamaha, 1650, 1.5, VehicleTypes.Motorcycle, 150, VehicleStatuses.Booked);
            _vehicles.Add(motorcycle1);

            var person1 = new Customer(123456, "Pierre", "Ottosson");
            _persons.Add(person1);

            var person2 = new Customer(159357, "Kristoffer", "Ottosson");
            _persons.Add(person2);

            _bookings.Add(new Booking(123456, car3, car3.RegNumber, person1.FirstName, person1.LastName, 5000, 5500, DateTime.Now, DateTime.Now.AddDays(+1), car3.VehicleStatus));
            _bookings.Add(new Booking(753159, motorcycle1, motorcycle1.RegNumber, person2.FirstName, person2.LastName, 1650, 2050, DateTime.Now, null, motorcycle1.VehicleStatus));
        }
        public IEnumerable<IVehicle> GetVehicles() => _vehicles;
        public IEnumerable<IPerson> GetPersons() => _persons;
        public IEnumerable<IBooking> GetBookings() => _bookings;
    }
}
