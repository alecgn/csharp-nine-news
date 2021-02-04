namespace CSharpNineNews.Records
{
    public record Tax
    {
        public Tax() { }

        public Tax(string initials, string name, float percentageRate) => 
            (Initials, Name, PercentageRage) = (initials, name, percentageRate);

        public string Initials { get; init; }
        public string Name { get; init; }
        public float PercentageRage { get; init; }
    }

    public record StateTax : Tax
    {
        public string StateCode { get; init; }
    }

    public record CityTax : Tax
    {
        public string CityName { get; init; }

        public CityTax(string initials, string name, float percentageRate, string cityName) :
            base(initials, name, percentageRate) => (CityName) = (cityName);
    }
}
