using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bpm : MonoBehaviour {

    public GameObject note;
    public GameObject[] laneStart;
    private float BPM = 110f;
    private float lastTime, deltaTime, timer;


    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Chooses a random lane to create the note in
        int rand = Random.Range(0, 4);

        deltaTime = GetComponent<AudioSource>().time - lastTime;
        timer += deltaTime;

        if (timer >= (60f / BPM))
        {
            //Create the note
            ((GameObject)Instantiate(note, laneStart[rand].transform.position, laneStart[rand].transform.rotation)).GetComponent<Transform>().parent = GetComponent<Transform>();
            timer -= (60f/BPM);
        }

        lastTime = GetComponent<AudioSource>().time;
    }
}
