using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flapStrength = 15;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float bottomScreen = -25;
    public float topScreen = 25;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            rigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < bottomScreen || transform.position.y > topScreen) {
            endGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        endGame();
    }

    private void endGame() {
        logic.gameOver();
        birdIsAlive = false;
    } 
}
