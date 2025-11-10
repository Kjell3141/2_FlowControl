namespace FlowControlApp
{
    internal static class CinemaPriceRules
    {
        /// <remarks>
        /// Vid ändring här kan ändring även behöva göras i <see cref="CinemaPriceRules.GetCinemaPriceAsText"/>.
        /// </remarks>
        public static decimal GetCinemaPrice(int age)
        {
            if (age < 5)
                return 0;
            else if (age < 20)
                return 80;
            else if (age > 100)
                return 0;
            else if (age > 64)
                return 90;
            else
                return 120;
        }

        /// <remarks>
        /// Vid ändring här kan ändring även behöva göras i <see cref="CinemaPriceRules.GetCinemaPrice"/>.
        /// </remarks>
        public static string GetCinemaPriceAsText(int age)
        {
            decimal price = GetCinemaPrice(age);

            if (age < 5)
                return $"Pris för barn under 5 år: {price} kr";
            else if (age < 20)
                return $"Ungdomspris: {price} kr";
            else if (age > 100)
                return $"Pris för personer över 100 år: {price} kr";
            else if (age > 64)
                return $"Pensionärspris: {price} kr";
            else
                return $"Standardpris: {price} kr";
        }
    }
}
