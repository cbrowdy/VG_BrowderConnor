using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

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

        public GameObject explosionPrefab;

        

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
        }

        // Update is called once per frame
        void Update()
        {
            timeElasped += Time.deltaTime;
            float decreaseDelayOverTime = maxAsteroidDelay - ((maxAsteroidDelay - minAsteroidDelay) / 30f * timeElasped);
            asteroidDelay = Mathf.Clamp(decreaseDelayOverTime, minAsteroidDelay, maxAsteroidDelay);

        }
    }

}
