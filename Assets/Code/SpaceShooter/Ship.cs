using System.Collections;
using System.Collections.Generic;
using SpaceShooter;
using UnityEngine;

namespace SpaceShooter
{
    public class Ship : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject projectilePrefab;
        public float firingDelay = 1f;
        void Start()
        {
            StartCoroutine("FiringTimer");
        }

        void FireProjectile()
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        IEnumerator FiringTimer()
        {
            yield return new WaitForSeconds(firingDelay);
            FireProjectile();
            StartCoroutine("FiringTimer");
        }
        

        // Update is called once per frame
        void Update()
        {
            float yPosition = Mathf.Sin(GameController.instance.timeElasped) * 3f;
            transform.position = new Vector2(0, yPosition);
        }

        
    }
}
