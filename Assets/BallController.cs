using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Audio source component for playing sounds.
    AudioSource myAudio;
    
    // Rigidbody component for physics operations.
    Rigidbody myBod;

    FloorController floorCon;
    
    // Sound clip to play when the ball bounces. Set this in Unity's inspector.
    public AudioClip bounceSound;

    // Start is called before the first frame update.
    void Start()
    {
        // Initialize the AudioSource and Rigidbody components attached to this GameObject.
        myAudio = GetComponent<AudioSource>();
        myBod = GetComponent<Rigidbody>();
        floorCon = GameObject.Find("Floor").GetComponent<FloorController>();

        // Generate a random horizontal velocity for the ball at the start.
        float x = Random.Range(-3f, 3f); // Randomly choose a value between -3 and 3.
        // Set the ball's initial velocity.
        myBod.velocity = new Vector3(x, 5, 0); // 5 units upwards and a random x velocity.
    }

    // Update is called once per frame.
    void Update()
    {
        // This method is called every frame. You can check for user input or other conditions here.
    }

    // This method is called when the GameObject collides with another GameObject.
    private void OnCollisionEnter(Collision collision)
    {
        // Play the bounce sound whenever a collision is detected.
        myAudio.PlayOneShot(bounceSound);
    }

    // This method is triggered when the GameObject enters a Trigger Collider.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject colliding is named "BonusBox".
        if(other.name == "BonusBox")
        {
            // Instantiate a new copy of this GameObject.
            GameObject g = Instantiate(gameObject);
            // Set the new GameObject's position.
            g.transform.position = new Vector3(0, 13, 0); // Place it at position (0, 5, 0).

            floorCon.ballCounter++;

        }
    }    
}
