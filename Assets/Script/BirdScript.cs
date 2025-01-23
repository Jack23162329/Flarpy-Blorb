using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdScript : MonoBehaviour {
    // Start is called before the first frame update

    public Rigidbody2D myRigidbody;
    public float flapStregth;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource EndSound;
    public bool soundPlayed = false;

    //Tring to make multiple sound effect to same object
    public AudioSource[] soundEffects;
    public int randomIndex = 0;
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // so we can talk to LogicScript.cs directly
    }

    // Update is called once per frame
    void Update() {
        overWindow();

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) {
            PlayRandomSound();
            myRigidbody.velocity = Vector2.up * flapStregth;
        }

    }

    private void PlayRandomSound() {
        if (soundEffects.Length > 0 && randomIndex < 3) {
            soundEffects[randomIndex].Play();
            randomIndex += 1;
        }
        else {
            soundEffects[randomIndex].Play();
            randomIndex = 0;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!soundPlayed) {
            EndSound.Play();
            soundPlayed = true;
        }
        logic.gameOver();
        birdIsAlive = false;
    }
    private void overWindow() {
        if (transform.position.y >= 3.4 || transform.position.y < -27) {
            if (!soundPlayed) {
                EndSound.Play();
                soundPlayed = true;
            }
            logic.gameOver();
            birdIsAlive = false;

        }
    }
}
