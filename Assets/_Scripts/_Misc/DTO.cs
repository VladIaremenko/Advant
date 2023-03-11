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
        public List<bool> Upgrades;

        public BuisnessState(int level, float incomeProgress)
        {
            Level = level;
            IncomeProgress = incomeProgress;
            Upgrades = new List<bool>() { false, false };
        }
    }
}


