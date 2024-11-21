using DispatcherService.Domain.Test;

namespace DispatchService.Domain.Test;

public class DispatchServiceTest(TestDataProvider testDataProvider) : IClassFixture<TestDataProvider>
{
    private readonly TestDataProvider _testDataProvider = testDataProvider;

    /// <summary>
    /// ������� ��� �������� � ���������� ������������ ��������.
    /// </summary>
    [Fact]
    public void TestGetTransportDetails()
    {
        var transportId = 1;
        var transport = _testDataProvider.transports.FirstOrDefault(t => t.Id == transportId);

        Assert.NotNull(transport);
        Assert.Equal(transportId, transport.Id);
    }

    /// <summary>
    /// ������� ���� ���������, ����������� ������� �� �������� ������, ����������� �� ���.
    /// </summary>
    [Fact]
    public void TestGetDriversByTripPeriod()
    {
        DateTime startDate = new DateTime(2024, 11, 14, 6, 0, 0);
        DateTime endDate = new DateTime(2024, 11, 16, 14, 0, 0);

        var drivers = _testDataProvider.schedules
            .Where(s => s.StartTime >= startDate && s.EndTime <= endDate)
            .Select(s => s.Driver)
            .Distinct()
            .OrderBy(d => d.FullName)
            .ToList();

        Assert.NotEmpty(drivers);
    }

    /// <summary>
    /// ������� ��������� ����� ������� ������������� �������� ������� ���� � ������.
    /// </summary>
    [Fact]
    public void TestTotalTripTimeByTransportTypeAndModel()
    {
        var transportSummary = _testDataProvider.schedules
            .GroupBy(s => new { s.Transport.Type, s.Transport.Model })
            .Select(g => new
            {
                TransportType = g.Key.Type,
                Model = g.Key.Model,
                TotalTime = g.Sum(s => (s.EndTime - s.StartTime).TotalHours)
            })
            .ToList();

        Assert.NotEmpty(transportSummary);
        Assert.All(transportSummary, item => Assert.True(item.TotalTime >= 0));
    }

    /// <summary>
    /// ������� ��� 5 ��������� �� ������������ ���������� �������.
    /// </summary>
    [Fact]
    public void TestTop5DriversByTripCount()
    {
        var topDrivers = _testDataProvider.schedules
            .GroupBy(s => s.Driver)
            .Select(g => new
            {
                Driver = g.Key,
                TripCount = g.Count()
            })
            .OrderByDescending(d => d.TripCount)
            .Take(5)
            .ToList();

        Assert.Equal(5, topDrivers.Count);
    }

    /// <summary>
    /// ������� ���������� � ���������� �������, ������� ������� � ������������ ������� ������� ��� ������� ��������.
    /// </summary>
    [Fact]
    public void TestDriverTripStatistics()
    {
        var driverStats = _testDataProvider.schedules
            .GroupBy(s => s.Driver)
            .Select(g => new
            {
                Driver = g.Key,
                TripCount = g.Count(),
                AverageTime = g.Average(s => (s.EndTime - s.StartTime).TotalHours),
                MaxTime = g.Max(s => (s.EndTime - s.StartTime).TotalHours)
            })
            .ToList();

        Assert.NotEmpty(driverStats);
        Assert.All(driverStats, stats => Assert.True(stats.TripCount > 0));
    }

    /// <summary>
    /// ������� ���������� � ������������ ���������, ����������� ������������ ����� ������� �� ��������� ������.
    /// </summary>
    [Fact]
    public void TestMostTripsByTransportInPeriod()
    {
        DateTime startDate = new DateTime(2024, 11, 14, 6, 0, 0);
        DateTime endDate = new DateTime(2024, 11, 16, 14, 0, 0);

        var transportTrips = _testDataProvider.schedules
            .Where(s => s.StartTime >= startDate && s.EndTime <= endDate)
            .GroupBy(s => s.Transport)
            .Select(g => new
            {
                Transport = g.Key,
                TripCount = g.Count()
            })
            .OrderByDescending(t => t.TripCount)
            .ToList();

        var maxTripCount = transportTrips.FirstOrDefault()?.TripCount ?? 0;
        var mostUsedTransports = transportTrips.Where(t => t.TripCount == maxTripCount).ToList();

        Assert.NotEmpty(mostUsedTransports);
        Assert.All(mostUsedTransports, t => Assert.Equal(maxTripCount, t.TripCount));
    }
}