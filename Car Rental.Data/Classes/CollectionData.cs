﻿using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new();
        readonly List<IVehicle> _vehicles = new();
        readonly List<IBooking> _bookings = new();

        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
        public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        public CollectionData() => SeedData();

        void SeedData()
        {
            var car1 = new Car(NextVehicleId, "ABC123", VehicleBrands.Volvo, 3500, 3, VehicleTypes.SUV, 200, VehicleStatus.Available);
            _vehicles.Add(car1);
            var car2 = new Car(NextVehicleId, "DRF547", VehicleBrands.Tesla, 5000, 2.3, VehicleTypes.Sedan, 250, VehicleStatus.Available);
            _vehicles.Add(car2);
            var car3 = new Car(NextVehicleId, "HJJ223", VehicleBrands.VolksWagen, 2300, 2.5, VehicleTypes.Stationwagon, 150, VehicleStatus.Available);
            _vehicles.Add(car3);
            var car4 = new Car(NextVehicleId, "MNB159", VehicleBrands.Jeep, 550, 3, VehicleTypes.Jeep, 300, VehicleStatus.Available);
            _vehicles.Add(car4);
            var motorcycle1 = new Motorcycle(NextVehicleId, "OSK444", VehicleBrands.Yamaha, 1650, 1.5, VehicleTypes.Motorcycle, 150, VehicleStatus.Available);
            _vehicles.Add(motorcycle1);

            var person1 = new Person(NextPersonId, "123456", "John", "Doe");
            _persons.Add(person1);
            var person2 = new Person(NextPersonId, "159357", "Jane", "Doe");
            _persons.Add(person2);

            var booking = new Booking(NextBookingId, person2, car1, (int)car1.Odometer, 0, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
            _bookings.Add(booking);
            var booking1 = new Booking(NextBookingId, person2, car3, (int)car3.Odometer, 3500, VehicleExtensions.Duration(DateTime.Now, DateTime.Now.AddDays(+2), car3, 1200), DateTime.Now, DateTime.Now.AddDays(+2), VehicleStatus.Closed);
            _bookings.Add(booking1);
            var booking2 = new Booking(NextBookingId, person1, motorcycle1, (int)motorcycle1.Odometer, 0, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
            _bookings.Add(booking2);
        }

        public List<T> Get<T> (Func<T, bool>? expression)
        {
            var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly) ?? throw new InvalidDataException();

            var value = collections.GetValue(this) ?? throw new InvalidDataException();
            
            var collection = ((List<T>)value).AsQueryable();
            
            if (expression is null) return collection.ToList();
            
            return collection.Where(expression).ToList();
        }

        T? IData.Single<T>(Expression<Func<T, bool>> expression) where T : default
        {
            try
            {
                var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                    ?? throw new InvalidDataException();

                var value = collections.GetValue(this) ?? throw new InvalidDataException();
                var collection = ((List<T>)value).AsQueryable();
                return collection.Single(expression) ?? throw new InvalidDataException();
            }
            catch
            {
                throw new InvalidDataException();
            }

        }
        void IData.Add<T>(T item)
        {
            var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidDataException();
            var value = collections.GetValue(this) as List<T> ?? throw new InvalidDataException();
            value.Add(item);
        }
    }
}
