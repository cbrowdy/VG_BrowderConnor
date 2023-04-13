using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        AudioSource audioSource;
        public AudioClip missSound;
        public AudioClip hitSound;
        private void Awake()
        {
            instance = this;
        }

        public void PlaySoundHit()
        {
            audioSource.PlayOneShot(hitSound);
        }

        public void PlaySoundMiss()
        {
            audioSource.PlayOneShot(missSound);
        }
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


