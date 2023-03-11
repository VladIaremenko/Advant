using System.Collections.Generic;

namespace Sagra.Assets._Scripts._Misc
{
    public class UserDataContainer
    {
        public List<BuisnessState> BuisnesStates = new List<BuisnessState>();

        public UserDataContainer(List<BuisnessState> buisnesStates)
        {
            BuisnesStates = buisnesStates;
        }
    }

    public class BuisnessState
    {
        public int Level;
        public float IncomeProgress;
        public bool Upgrade1Bought;
        public bool Upgrade2Bought;

        public BuisnessState(int level, float incomeProgress, bool upgrade1Bought = false, bool upgrade2Bought = false)
        {
            Level = level;
            IncomeProgress = incomeProgress;
            Upgrade1Bought = upgrade1Bought;
            Upgrade2Bought = upgrade2Bought;
        }
    }
}


