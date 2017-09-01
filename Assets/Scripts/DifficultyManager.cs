using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {
    [Range(0, 1f)]
    public float coinChance = 0.1f;
    public int currentLevel = 0;
    public Levels[] levels;
    [System.Serializable]
    public struct Levels
    {
        public int startingScore;
        public bool randomSpeed;
        [Range(0, 1f)]
        public float rotatingChance;
        [Range(0, 1f)]
        public float slidingRotatingChance;
        [Range(0, 1f)]
        public float middleObstacleChance;
        public float asteroidSpeedMin;
        public float asteroidSpeedMax;
    }
    public void levelCheck() { 
    
        int score = GetComponent<Score>().score;
        for (int i = 0; i < levels.Length; i++)
        {
            if (score+3 <= levels[i].startingScore)
            {
                currentLevel = i -1;
                break;
            }
        }
    }
}
