using FluentAssertions;
using HelloIoCConfiguration;
using Xunit;

namespace UnitTests
{
    public class ConfigurationTests
    {
        private readonly Configuration _sut;

        public ConfigurationTests()
        {
            _sut = new Configuration(key => $"FAKE-{key}");
        }

        [Fact]
        public void NumberOfFriends_Should_Return_Expected()
        {
            var result = _sut.NumberOfFriends;

            result.Should().Be("FAKE-NumberOfFriends");
        }

        [Fact]
        public void RandomPersonGeneratorApiLocation_Should_Return_Expected()
        {
            var result = _sut.RandomPersonGeneratorApiLocation;

            result.Should().Be("FAKE-RandomPersonGeneratorApiLocation");
        }
    }
}
