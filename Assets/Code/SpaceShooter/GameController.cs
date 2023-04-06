using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

namespace SpaceShooter
{
    public class GameController : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject[] asteroidPrefabs;
        
        public static GameController instance;
        
        public float timeElasped;
        
        public float maxAsteroidDelay = 2f;
        public float minAsteroidDelay = 0.2f;
        public float asteroidDelay;

        public TMP_Text textScore;
        public TMP_Text textMoney;
        public TMP_Text missileSpeedUpgradeText;
        public TMP_Text bonusUpgradeText;
        
        
        public int score;
        public int money;
        public float missileSpeed = 2f;
        public float bonusMultiplier = 1f;
        

        public GameObject explosionPrefab;


        public void UpgradeMissileSpeed()
        {
            int cost = Mathf.RoundToInt(25 * missileSpeed);
            if (cost <= money)
            {
                money -= cost;
                missileSpeed += 1f;
                missileSpeedUpgradeText.text = "Missile Speed $" + Mathf.RoundToInt(25 * missileSpeed);
            }
            
        }
        public void UpgradeBonus()
        {
            int cost = Mathf.RoundToInt(100 * bonusMultiplier);
            if (cost <= money)
            {
                money -= cost;
                bonusMultiplier += 1f;
                bonusUpgradeText.text = "Multiplier $" + Mathf.RoundToInt(100 * bonusMultiplier);
            }
            
        }
        void SpawnAsteroid()
        {
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
            int randomAsteroidIndex = Random.Range(0, asteroidPrefabs.Length);
            GameObject randomAsteroidPrefab = asteroidPrefabs[randomAsteroidIndex];
            //spawn
            Instantiate(randomAsteroidPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
   
        
        void Awake()
        {
            instance = this;
        }

        IEnumerator AsteroidSpawnTimer()
        {
            yield return new WaitForSeconds(asteroidDelay);
            SpawnAsteroid();
            StartCoroutine("AsteroidSpawnTimer");
        }
        
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("AsteroidSpawnTimer");

            score = 0;
            money = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timeElasped += Time.deltaTime;
            float decreaseDelayOverTime = maxAsteroidDelay - ((maxAsteroidDelay - minAsteroidDelay) / 30f * timeElasped);
            asteroidDelay = Mathf.Clamp(decreaseDelayOverTime, minAsteroidDelay, maxAsteroidDelay);

            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            textScore.text = score.ToString();
            textMoney.text = money.ToString();
        }

        
        

        public void EarnPoints(int pointAmount)
        {
            score += Mathf.RoundToInt(pointAmount * bonusMultiplier);
            money += Mathf.RoundToInt(pointAmount * bonusMultiplier);
        }
        

        
    }

}
