using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {
    private int score;
    public Text countText;


    private void Start()
    {
        score = 0;
        SetCountText();
     }


    //void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.CompareTag("Ring"))
    //    {
    //        other.gameObject.SetActive(false);
    //    }
    //}

    void AddScore (int newScore)
    {
        score += newScore;
        SetCountText();

    }

    void SetCountText()
    {
        countText.text = "Score:  " + score.ToString();
    }
}
