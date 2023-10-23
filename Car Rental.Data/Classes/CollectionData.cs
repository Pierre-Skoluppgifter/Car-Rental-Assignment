using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Exceptions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        private readonly List<IPerson> _persons = new();
        private readonly List<IVehicle> _vehicles = new();
        private readonly List<IBooking> _bookings = new();

        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
        public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;
        

        public CollectionData() => SeedData();

        void SeedData()
        {
            var car1 = new Car(NextVehicleId, "ABC123", VehicleBrand.Volvo, 3500, 3, VehicleType.SUV, 200, VehicleStatuses.Available);
            _vehicles.Add(car1);
            var car2 = new Car(NextVehicleId, "DRF547", VehicleBrand.Tesla, 5000, 2.3, VehicleType.Sedan, 250, VehicleStatuses.Available);
            _vehicles.Add(car2);
            var car3 = new Car(NextVehicleId, "HJJ223", VehicleBrand.VolksWagen, 2300, 2.5, VehicleType.Stationwagon, 150, VehicleStatuses.Closed);
            _vehicles.Add(car3);
            var car4 = new Car(NextVehicleId, "MNB159", VehicleBrand.Jeep, 550, 3, VehicleType.Jeep, 300, VehicleStatuses.Available);
            _vehicles.Add(car4);
            var motorcycle1 = new Motorcycle(NextVehicleId, "OSK444", VehicleBrand.Yamaha, 1650, 1.5, VehicleType.Motorcycle, 150, VehicleStatuses.Booked);
            _vehicles.Add(motorcycle1);

            var person1 = new Person(NextPersonId, 123456, "Pierre", "Ottosson");
            _persons.Add(person1);

            var person2 = new Person(NextPersonId, 159357, "Kristoffer", "Ottosson");
            _persons.Add(person2);

            var booking1 = new Booking(NextBookingId, 123456, "HJJ223", person1.FirstName, person1.LastName, 5000, 5500, DateTime.Now, DateTime.Now.AddDays(+1), car3.CostPerKilometer, car3.CostPerDay, car3.VehicleStatus);
            _bookings.Add(booking1);
            var booking2 = new Booking(NextBookingId, 753159, "OSK444", person2.FirstName, person2.LastName, 1650, 2050, DateTime.Now, null, motorcycle1.CostPerKilometer, motorcycle1.CostPerDay, motorcycle1.VehicleStatus);
            _bookings.Add(booking2);
        }
        public IEnumerable<IVehicle> GetVehicles() => _vehicles;
        public IEnumerable<IPerson> GetPersons() => _persons;
        public IEnumerable<IBooking> GetBookings() => _bookings;

        public List<T> Get<T>(Expression<Func<T, bool>>? expression)
        {
            try
            {
                var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly) ?? throw new InvalidDataException();
                
                var value = collections.GetValue(this) ?? throw new InvalidDataException();
                
                var collection = ((List<T>)value).AsQueryable();
                
                if (expression is null) return collection.ToList();
                
                return collection.Where(expression).ToList();
            }
            catch
            {
                throw new DataNullException("!");
            }
        }
        public List<T> Single<T>(Expression<Func<T, bool>>? expression)
        {
            try
            {
                var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly) ?? throw new InvalidDataException();
                var value = collections.GetValue(this) ?? throw new InvalidDataException();
                var collection = ((List<T>)value).AsQueryable();
                if (expression is null) return collection.ToList();
                return collection.Where(expression).ToList();
            }
            catch (Exception ex)
            {
                throw new DataNullException("!");
            }
        }
        public List<T> Add<T>(Expression<Func<T, bool>>? expression)
        {
            try
            {
                var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly) ?? throw new InvalidDataException();
                var value = collections.GetValue(this) ?? throw new InvalidDataException();
                var collection = ((List<T>)value).AsQueryable();
                if (expression is null) return collection.ToList();
                return collection.Where(expression).ToList();
                
            }
            catch (Exception ex)
            {
                throw new DataNullException("!");
            }
        }

        public void Add<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
