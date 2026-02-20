using UnityEngine;

namespace SpaceShooter.Score
{
    [CreateAssetMenu(fileName = "NewScoreData", menuName = "StaticData/ScoreData")]
    public class ScoreDataSO : ScriptableObject
    {
        public int LastSessionScore;
    }
}

