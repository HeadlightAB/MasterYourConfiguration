using System.Configuration;

namespace HelloValidateConfiguration
{
    public interface IConfiguration
    {
        [RegexStringValidator("^https?:\\/\\/")]
        string RandomPersonGeneratorApiLocation { get; }

        [IntegerValidator(MinValue = 1)]
        int NumberOfFriends { get; }
    }
}
