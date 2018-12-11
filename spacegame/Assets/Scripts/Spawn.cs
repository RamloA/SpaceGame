using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public int max;
    public GameObject objects;
    private float horizontalMin = -1.5f;
    private float horizontalMax = 1.5f;

    private float yposMin = -1f;
    private float yposMax = -0.1f;
    public Text winText;
    private float verticalMin = 52f;
    private float verticalMax = 54f;
    private float SpawnTime = 1.5f;
    public Text countDown;
    public Text score;
    public AudioClip music;


    private Vector3 orginPosition;
    // Use this for initialization1
    void Start()
    {

        orginPosition = transform.position;
        StartCoroutine(CountD(10));      // Countdown
        objects.SetActive(false);          // remove first ring
        winText.text = "";
        bool state = objects.gameObject.activeSelf;
        countDown.text = "";
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = music;
        score.enabled = false;

    }

    IEnumerator CountD(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            yield return new WaitForSeconds(1);
            countDown.text = count.ToString();
          count--;
            winText.text = "Catch the batteries!";
        }

        objects.SetActive(true);
        StartCoroutine(Spawnwait(max));


    }

    public void SpawnFunction()
    {
       
            Vector3 randomPosition = new Vector3(Random.Range(horizontalMin, horizontalMax), Random.Range(yposMin, yposMax), Random.Range(verticalMin, verticalMax));
            Instantiate(objects, randomPosition, Quaternion.identity);
            orginPosition = randomPosition;
    }

    IEnumerator Spawnwait(int max)
    {
        int count = 0;
        while (count < max)
        {
            score.enabled = true;
            countDown.text = "";
            winText.text = "";
           
            print("Count:  " + count);
            SpawnFunction();
            yield return new WaitForSeconds(SpawnTime);
            count++;

        }
        if (count > 1)
        {
            winText.text = "You Win";
            GetComponent<AudioSource>().Play();
        }
    }
}
