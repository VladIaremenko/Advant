using System.Collections.Generic;

namespace Sagra.Assets._Scripts
{
    public class UserBuisnesesState
    {
        public List<BuisnesState> BuisnesStates = new List<BuisnesState>();
    }

    public class BuisnesState
    {
        public int Level;
        public float IncomeProgress;
    }
}


