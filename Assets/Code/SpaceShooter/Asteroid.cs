using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceShooter
{
    public class Asteroid : MonoBehaviour
    {
        Rigidbody2D _rb;
        // Start is called before the first frame update
        float randomSpeed;
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            randomSpeed = Random.Range(0.5f, 3f);
        }

        // Update is called once per frame
        void Update()
        {
            _rb.velocity = Vector2.left * randomSpeed;
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
        
    }

}
