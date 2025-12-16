using gihub_actions_api.Controllers;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace github_actions_api.Tests
{

    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_ReturnsWeatherForecastsWithValidProperties()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var forecasts = controller.Get().ToList();

            // Assert
            foreach (var forecast in forecasts)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
                Assert.False(string.IsNullOrEmpty(forecast.Summary));
                Assert.NotEqual(default, forecast.Date);
            }
        }
    }
}