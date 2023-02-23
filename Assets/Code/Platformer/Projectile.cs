using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Projectile : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
        private Rigidbody2D _rigidbody2D;
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = transform.right * 10f;
        }

        // Update is called once per frame
        void Update()
        {
            
            
        }
    }
}

