using Records.RecordObjects;
using System;
using System.Text.Json;

namespace Records
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Info]: all records used in this program uses init only setters, a new featura from C# 9 too.");

            StateTax icms12;
            Console.WriteLine($"\nTesting Records - Creating new instance of [{nameof(StateTax)}] named [{nameof(icms12)}]:");
            icms12 = new()
            {
                Initials = "ICMS",
                Name = "Imposto sobre Circulacao de Mercadorias e Servicos",
                PercentageRage = 12,
                StateCode = "SP"
            };
            ShowRecordData(icms12);

            StateTax icms08;
            Console.WriteLine($"\nTesting Records - Creating new instance of [{nameof(StateTax)}] named [{nameof(icms08)}] based on the previous one using \"with\" expression to change [{nameof(StateTax.StateCode)}] and [{nameof(StateTax.PercentageRage)}]:");
            icms08 = icms12 with { StateCode = "MG", PercentageRage = 8 };
            ShowRecordData(icms08);

            CityTax iss05;
            Console.WriteLine($"\nTesting Records - Creating new instance of [{nameof(CityTax)}] named [{nameof(iss05)}]:");
            iss05 = new("ISS", "Imposto sobre Servico", 5, "Sao Paulo");
            ShowRecordData(iss05);

            CityTax iss05New;
            Console.WriteLine($"\nTesting Records - Creating new instance of [{nameof(CityTax)}] named [{nameof(iss05New)}] with exactly the same values as [{nameof(iss05)}]:");
            iss05New = new("ISS", "Imposto sobre Servico", 5, "Sao Paulo");
            ShowRecordData(iss05New);

            Console.WriteLine($"\nTesting Equality - Records can compare equality by value, not by reference:");
            Console.WriteLine($"[{nameof(iss05New)} == {nameof(iss05)}]: {(iss05New == iss05)}");
        }

        private static void ShowRecordData(object record) =>
            Console.WriteLine(JsonSerializer.Serialize(record));
    }
}
