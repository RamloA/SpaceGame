using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flying : MonoBehaviour
{
    private float horizontalSpeed = -0.2f;
    public Vector3 tempPosition;
    bool start1;

    public GameObject objects;

  //  public Text countText;

    // Use this for initialization
    void Start()
    {
        objects.gameObject.SetActive(true); 
       start1 = objects.gameObject.activeSelf;
        print("active " + start1);
        
        if (start1 == true)
        {
          //  countText.enabled = false;
            tempPosition = transform.position;
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime); //rotate object

        if(Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();
 

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempPosition.z += horizontalSpeed;

        transform.position = tempPosition;
    }
   
}
