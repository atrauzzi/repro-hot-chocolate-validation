namespace WebApplication;

[OneOf]
public class ParameterInput
{
    public interface Parameter
    {
    }

    public record ColorParameters(int Red, int Green, int Blue, int Alpha) : Parameter;

    public record FileParameters(Guid Id) : Parameter;

    public record WebPaymentParameters(
        bool AllowFeeCoverage,
        bool CoverFeesByDefault,
        bool AllowCurrencySelection,
        string DefaultIso4217Code,
        IDictionary<string, WebPaymentParameters.CurrencySettings> Currencies
    ) : Parameter
    {
        public record CurrencySettings(string Iso4217Code, IList<CurrencySettings.Step> Steps)
        {
            public record Step(
                int AmountSmallestUnit
            );
        }
    }

    public ColorParameters? Color { get; init; }

    public FileParameters? File { get; init; }

    public WebPaymentParameters? WebPayment { get; init; }

    [GraphQLIgnore]
    public Parameter Value => (Color, File, WebPayment) switch
    {
        (null, {} file, null) => file,
        ({} color, null, null) => color,
        (null, null, {} webPayment) => webPayment,
        _ => throw new ArgumentOutOfRangeException(),
    };
}
