namespace Sagra.Assets._Scripts._Misc
{
    public static class BuisnessCalculator
    {
        public static float CalculateUpdgradePrice(int level, float basicPrice)
        {
            return (level + 1) * basicPrice;
        }

        public static float CalculateIncome(int level, float basicIncome, float upgrade1Multiplier, float upgrade2Multiplier)
        {
            return level * basicIncome * (1 + upgrade1Multiplier/100f + upgrade2Multiplier/100f);
        }
    }
}


