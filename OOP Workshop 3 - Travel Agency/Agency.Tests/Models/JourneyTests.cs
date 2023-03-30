using Agency.Exceptions;
using Agency.Models;
using Agency.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agency.Tests.Models
{
    [TestClass]
    public class JourneyTests
    {
        [TestMethod]
        [DataRow(Journey.StartLocationMinLength - 1)]
        [DataRow(Journey.StartLocationMaxLength + 1)]
        public void Constructor_Should_Throw_When_StartLocationLengthOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Journey(
                    id: 1,
                    startLocation: new string('x', testValue),
                    destination: new string('x', Journey.DestinationMinLength),
                    distance: Journey.DistanceMinValue,
                    vehicle: TestHelpers.GetTestVehicle()));
        }

        [TestMethod]
        [DataRow(Journey.DestinationMinLength - 1)]
        [DataRow(Journey.DestinationMaxLength + 1)]
        public void Constructor_Should_Throw_When_DestinationLengthOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Journey(
                    id: 1,
                    startLocation: new string('x', Journey.StartLocationMinLength),
                    destination: new string('x', testValue),
                    distance: Journey.DistanceMinValue,
                    vehicle: TestHelpers.GetTestVehicle()));
        }

        [TestMethod]
        [DataRow(Journey.DistanceMinValue - 1)]
        [DataRow(Journey.DistanceMaxValue + 1)]
        public void Constructor_Should_Throw_When_DistanceOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Journey(
                    id: 1,
                    startLocation: new string('x', Journey.StartLocationMinLength),
                    destination: new string('x', Journey.DestinationMinLength),
                    distance: testValue,
                    vehicle: TestHelpers.GetTestVehicle()));
        }
    }
}
