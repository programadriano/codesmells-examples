namespace CodeSmells.Exemplos.exemplo4
{
    public class MagicNumbers
    {
        public void CalculaIdadeEmMinutos()
        {
            int daysInYear = 365;
            int age = 30;

            int minutesInYear = daysInYear * 24 * 60;//aqui
            int ageInMinutes = age * minutesInYear;

            Console.WriteLine("Sua idade em minutos é aproximadamente: " + ageInMinutes);
        }

        private const int HoursPerDay = 24;
        private const int MinutesPerHour = 60;

        public void CalculaIdadeEmMinutosAjustado()
        {

            int daysInYear = 365;
            int age = 30;

            int minutesInYear = daysInYear * HoursPerDay * MinutesPerHour;
            int ageInMinutes = age * minutesInYear;

            Console.WriteLine("Sua idade em minutos é aproximadamente: " + ageInMinutes);
        }
    }
}
