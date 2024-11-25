using DispatcherService.Domain.Entities;

namespace DispatcherService.Domain.Test;

public class TestDataProvider
{
    public List<Transport> transports = new()
    {
        new Transport(1) {Id = 1, RegistrationNumber = "A123BC", Type = "Автобус", Model = "MAN Lion's City", IsLowFloor = true, MaxCapacity = 80, YearOfManufacture = 2018 },
        new Transport(2) {Id = 2, RegistrationNumber = "B456DE", Type = "Троллейбус", Model = "Тролза Мегаполис", IsLowFloor = false, MaxCapacity = 120, YearOfManufacture = 2015 },
        new Transport(3) {Id = 3, RegistrationNumber = "C789FG", Type = "Трамвай", Model = "ЛМ-99", IsLowFloor = false, MaxCapacity = 200, YearOfManufacture = 2010 },
        new Transport(4) {Id = 4, RegistrationNumber = "D101HI", Type = "Автобус", Model = "Volvo 7900", IsLowFloor = true, MaxCapacity = 90, YearOfManufacture = 2020 },
        new Transport(5) {Id = 5, RegistrationNumber = "E202JK", Type = "Троллейбус", Model = "Богдан Т701", IsLowFloor = false, MaxCapacity = 110, YearOfManufacture = 2017 }
    };

    public List<Driver> drivers = new()
    {
        new Driver(1) {Id = 1, FullName = "Иванов Иван Иванович", Passport = "1234 567890", DriverLicense = "A1234567", Address = "г. Москва, ул. Ленина, д. 1", PhoneNumber = "+7-123-456-78-90" },
        new Driver(2) {Id = 2, FullName = "Петров Петр Петрович", Passport = "2345 678901", DriverLicense = "B2345678", Address = "г. Санкт-Петербург, ул. Пушкина, д. 2", PhoneNumber = "+7-987-654-32-10" },
        new Driver(3) {Id = 3, FullName = "Сидоров Сидор Сидорович", Passport = "3456 789012", DriverLicense = "C3456789", Address = "г. Казань, ул. Гоголя, д. 3", PhoneNumber = "+7-654-321-98-76" },
        new Driver(4) {Id = 4, FullName = "Кузнецов Михаил Александрович", Passport = "4567 890123", DriverLicense = "D4567890", Address = "г. Новосибирск, ул. Чехова, д. 4", PhoneNumber = "+7-321-654-87-65" },
        new Driver(5) {Id = 5, FullName = "Федоров Федор Федорович", Passport = "5678 901234", DriverLicense = "E5678901", Address = "г. Екатеринбург, ул. Тургенева, д. 5", PhoneNumber = "+7-432-109-87-65" }
    };

    public List<Schedule> schedules;

    public TestDataProvider()
    {
        schedules = new List<Schedule>
        {
            new Schedule(1)
            {
                Id = 1,
                TransportId = 1,
                DriverId = 1,
                RouteNumber = "101",
                StartTime = new DateTime(2024, 11, 15, 6, 0, 0),
                EndTime = new DateTime(2024, 11, 15, 14, 0, 0),
                Transport = transports[0],
                Driver = drivers[0]
            },
            new Schedule(2)
            {
                Id = 2,
                TransportId = 2,
                DriverId = 2,
                RouteNumber = "202",
                StartTime = new DateTime(2024, 11, 15, 7, 0, 0),
                EndTime = new DateTime(2024, 11, 15, 15, 0, 0),
                Transport = transports[1],
                Driver = drivers[1]
            },
            new Schedule(3)
            {
                Id = 3,
                TransportId = 3,
                DriverId = 3,
                RouteNumber = "303",
                StartTime = new DateTime(2024, 11, 15, 8, 0, 0),
                EndTime = new DateTime(2024, 11, 15, 16, 0, 0),
                Transport = transports[2],
                Driver = drivers[2]
            },
            new Schedule(4)
            {   
                Id = 4,
                TransportId = 4,
                DriverId = 4,
                RouteNumber = "404",
                StartTime = new DateTime(2024, 11, 15, 9, 0, 0),
                EndTime = new DateTime(2024, 11, 15, 17, 0, 0),
                Transport = transports[3],
                Driver = drivers[3]
            },
            new Schedule(5)
            {
                Id = 5,
                TransportId = 5,
                DriverId = 5,
                RouteNumber = "505",
                StartTime = new DateTime(2024, 11, 15, 10, 0, 0),
                EndTime = new DateTime(2024, 11, 15, 18, 0, 0),
                Transport = transports[4],
                Driver = drivers[4]
            }
        };
    }
}
