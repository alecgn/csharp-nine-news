using System;
using System.Globalization;

namespace PatternMatchingEnhancements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"1. Testing pattern matching enhancements - Generating a SQL insert statement using type patterns, wich matches if a variable is a type.");
            Console.WriteLine("\nMETHOD CALL:\n\nConsole.WriteLine($\"INSERT INTO CreditCardOperation (CreditCardId, Amount, DateTime) VALUES (1, {Math.Round(new Random().NextDouble(), 2).ToSqlValue()}, {DateTime.Now.ToSqlValue()});\";");
            Console.WriteLine("\nTYPE PATTERN MATCHING METHOD:\n\npublic static string ToSqlValue(this object @object, SqlUserLanguage sqlUserLanguage = SqlUserLanguage.EnglishUnitedStates) =>");
            Console.WriteLine("@object switch");
            Console.WriteLine("{");
            Console.WriteLine("\tstring => ((string)@object).ToSqlString(),");
            Console.WriteLine("\tdouble => ((double)@object).ToSqlDouble(sqlUserLanguage),");
            Console.WriteLine("\tDateTime => ((DateTime)@object).ToSqlDateTime(sqlUserLanguage),");
            Console.WriteLine("\t_ => @object.ToString(),");
            Console.WriteLine("};");
            Console.Write("\nOUTPUT: ");
            var sqlInsert = $"\n\nINSERT INTO CreditCardOperation (CreditCardId, Amount, DateTime) VALUES (1, {Math.Round(new Random().NextDouble(), 2).ToSqlValue()}, {DateTime.Now.ToSqlValue()});";
            Console.Write(sqlInsert);
            Console.WriteLine($"\n\n2. Testing pattern matching enhancements - Verify if a character is a digit or separator using parenthesized, conjunctive 'and', disjunctive 'or' and relational patterns \n[@char is (>= '0' and <= '9') or '.' or ',']:");
            Console.Write("\nType a character to test if it is a digit or a separator: ");
            var cki = Console.ReadKey();
            Console.WriteLine($"\nCharacter [{cki.KeyChar}] is{(cki.KeyChar.IsDigitOrSeparator() ? " " : " not ")}a digit or separator.");
            Console.WriteLine($"\nTesting pattern matching enhancements - Verify if a character is a letter using negated 'not' pattern \n[@char is not (>= 'a' and <= 'z') and not (>= 'A' and <= 'Z')]:");
            Console.Write("\nType a character to test if it is not a letter: ");
            var cki2 = Console.ReadKey();
            Console.WriteLine($"\nCharacter [{cki2.KeyChar}] is{(cki2.KeyChar.IsNotLetter() ? " not " : " ")}a letter.");
        }
    }

    public enum SqlUserLanguage { EnglishUnitedStates = 0, PortugueseBrazil };

    public static class Extensions
    {
        public static string ToSqlValue(this object @object, SqlUserLanguage sqlUserLanguage = SqlUserLanguage.EnglishUnitedStates) =>
            @object switch
            {
                string => ((string)@object).ToSqlString(),
                double => ((double)@object).ToSqlDouble(sqlUserLanguage),
                DateTime => ((DateTime)@object).ToSqlDateTime(sqlUserLanguage),
                _ => @object.ToString(),
            };

        private static string ToSqlString(this string @string) => $"'{@string}'";

        private static string ToSqlDouble(this double @double, SqlUserLanguage sqlUserLanguage) =>
            @double.ToString(sqlUserLanguage.GetCultureInfo());

        private static string ToSqlDateTime(this DateTime dateTime, SqlUserLanguage sqlUserLanguage) =>
            $"'{dateTime.ToString(sqlUserLanguage.GetSqlDateTimeFormat())}'";

        private static CultureInfo GetCultureInfo(this SqlUserLanguage sqlUserLanguage) =>
            sqlUserLanguage switch
            {
                SqlUserLanguage.PortugueseBrazil => new CultureInfo("pt-BR"),
                _ => new CultureInfo("en-US")
            };

        private static string GetSqlDateTimeFormat(this SqlUserLanguage sqlUserLanguage) =>
            sqlUserLanguage switch
            {
                SqlUserLanguage.PortugueseBrazil => "dd/MM/yyyy HH:mm:ss.fff",
                _ => "yyyy-MM-dd HH:mm:ss.fff",
            };

        public static bool IsDigitOrSeparator(this char @char) =>
            @char is (>= '0' and <= '9') or '.' or ',';

        public static bool IsNotLetter(this char @char) =>
            @char is not (>= 'a' and <= 'z') and not (>= 'A' and <= 'Z');
    }
}
