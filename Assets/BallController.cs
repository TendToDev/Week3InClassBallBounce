using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    AudioSource myAudio;
    Rigidbody myBod;

    
    //public properties
    public AudioClip bounceSound; //Initialised in the inspector.

    

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myAudio = GetComponent<AudioSource>();
        myBod = GetComponent<Rigidbody>();

        myBod.velocity = new Vector3(1, 5, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAudio.PlayOneShot(bounceSound);
    }
}
