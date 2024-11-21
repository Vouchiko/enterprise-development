using DispatcherService.Domain.Entities;

namespace DispatcherService.Domain.Test;

public class TestDataProvider
{
    public List<Transport> transports = new()
    {
        new Transport(1, "A123BC", "Автобус", "MAN Lion's City", true, 80, 2018) { Id = 1 },
        new Transport(2, "B456DE", "Троллейбус", "Тролза Мегаполис", false, 120, 2015) { Id = 2 },
        new Transport(3, "C789FG", "Трамвай", "ЛМ-99", false, 200, 2010) { Id = 3 },
        new Transport(4, "D101HI", "Автобус", "Volvo 7900", true, 90, 2020) { Id = 4 },
        new Transport(5, "E202JK", "Троллейбус", "Богдан Т701", false, 110, 2017) { Id = 5 }
    };

    public List<Driver> drivers = new()
    {
        new Driver(1, "Иванов Иван Иванович", "1234 567890", "A1234567", "г. Москва, ул. Ленина, д. 1", "+7-123-456-78-90") { Id = 1 },
        new Driver(2, "Петров Петр Петрович", "2345 678901", "B2345678", "г. Санкт-Петербург, ул. Пушкина, д. 2", "+7-987-654-32-10") { Id = 2 },
        new Driver(3, "Сидоров Сидор Сидорович", "3456 789012", "C3456789", "г. Казань, ул. Гоголя, д. 3", "+7-654-321-98-76") { Id = 3 },
        new Driver(4, "Кузнецов Михаил Александрович", "4567 890123", "D4567890", "г. Новосибирск, ул. Чехова, д. 4", "+7-321-654-87-65") { Id = 4 },
        new Driver(5, "Федоров Федор Федорович", "5678 901234", "E5678901", "г. Екатеринбург, ул. Тургенева, д. 5", "+7-432-109-87-65") { Id = 5 }
    };

    public List<Schedule> schedules;

    public TestDataProvider()
    {
        schedules = new List<Schedule>
        {
            new Schedule(1, 1, 1, "101", new DateTime(2024, 11, 15, 6, 0, 0), new DateTime(2024, 11, 15, 14, 0, 0))
            {
                Transport = transports[0],
                Driver = drivers[0],
                Id = 1
            },
            new Schedule(2, 2, 2, "202", new DateTime(2024, 11, 15, 7, 0, 0), new DateTime(2024, 11, 15, 15, 0, 0))
            {
                Transport = transports[1],
                Driver = drivers[1],
                Id = 2
            },
            new Schedule(3, 3, 3, "303", new DateTime(2024, 11, 15, 8, 0, 0), new DateTime(2024, 11, 15, 16, 0, 0))
            {
                Transport = transports[2],
                Driver = drivers[2],
                Id = 3
            },
            new Schedule(4, 4, 4, "404", new DateTime(2024, 11, 15, 9, 0, 0), new DateTime(2024, 11, 15, 17, 0, 0))
            {
                Transport = transports[3],
                Driver = drivers[3],
                Id = 4
            },
            new Schedule(5, 5, 5, "505", new DateTime(2024, 11, 15, 10, 0, 0), new DateTime(2024, 11, 15, 18, 0, 0))
            {
                Transport = transports[4],
                Driver = drivers[4],
                Id = 5
            }
        };
    }
}
