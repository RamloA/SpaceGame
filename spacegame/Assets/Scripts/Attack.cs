using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;
using System.Threading;
using System.Collections.ObjectModel;

namespace Valve.VR.InteractionSystem
{
    public class Attack : MonoBehaviour
    {
        public Hand hand;
        public AudioClip music;

        private int score;
        public Text countText;


        void Start()
        {
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = music;

            if (countText.isActiveAndEnabled == true)
            {
                score = 0;
                SetCountText();
            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("projectile"))
            {
                GetComponent<AudioSource>().Play();
                print("Collide");
                hand.TriggerHapticPulse(0.5f, 25, 30);
                score += 5;
                SetCountText();
          
                Destroy(other.gameObject);
                
            }
        }
        
        void SetCountText()
        {
            countText.text = score.ToString();
        }
    }
}

