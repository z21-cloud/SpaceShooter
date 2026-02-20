using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Score
{
    public interface IScoreDecrease
    {
        public void DecreaseScore(int value);
    }
}
