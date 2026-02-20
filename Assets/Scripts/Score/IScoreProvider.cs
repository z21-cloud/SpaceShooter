using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Score
{
    public interface IScoreProvider
    {
        public int CurrentScore { get; }
    }
}
