using System.Collections.Generic;
using System.Threading.Tasks;
using TwoSense.Angry.Infrastructure.Services;
using Xunit;

namespace TwoSense.Angry.Application.Test
{
    public class AngryDetectionUnitTest
    {
        [Fact]
        public async Task IsAngryAsync_Success_NoAngry()
        {
            //Arrange
            var periods = new List<int> { 0, 100, 200, 399, 400 };
            var service = new AngryDetectionService();
            //Act
            var actual = await service.IsAngryAsync(periods);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public async Task IsAngryAsync_Success_Angry()
        {
            //Arrange
            var periods = new List<int> { 0, 100, 200, 399, 401 };
            var service = new AngryDetectionService();
            //Act
            var actual = await service.IsAngryAsync(periods);

            //Assert
            Assert.True(actual);
        }
    }
}
