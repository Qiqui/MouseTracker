using Microsoft.EntityFrameworkCore;
using MouseTracker.Application.Services;
using MouseTracker.Domain.Models;
using MouseTracker.Infrastructure;
using MouseTracker.Infrastructure.Repositories;

namespace MouseTracker.Tests
{
    public class HomeControllerTests
    {
        private DatabaseContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new DatabaseContext(options);
        }

        [Fact]
        public async Task SaveMouseData_ShouldSaveDataToDatabase()
        {
            using (var context = GetInMemoryDbContext())
            {
                var repository = new MouseMovementRepository(context);
                var service = new MouseMovementService(repository);
                var testData = new List<MouseData>
                {
                    new MouseData() { X = 100, Y = 200, T = 123456789 },
                    new MouseData() { X = 150, Y = 250, T = 123456790 }
                };

                await service.SaveMouseDataAsync(testData);

                // Assert
                var savedData = await context.MouseMovements.FirstOrDefaultAsync();

                Assert.NotNull(savedData);
                Assert.Equal(System.Text.Json.JsonSerializer.Serialize(testData), savedData.Data);
            }
        }
    }
}