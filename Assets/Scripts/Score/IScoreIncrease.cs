using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Score
{
    public interface IScoreIncrease
    {
        public void IncreaseScore(int value);
    }
}
