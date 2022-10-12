using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
       
        if(materialName == "Safe (Instance)")
        {
            //The ball hits the safe area
        }else if(materialName == "UnSafe (Instance)"){
            //The ball hits the unsafe area       
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if(materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            //Level is completed
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
