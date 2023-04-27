using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public int jump = 0;
    public Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody.velocity = Vector2.up * flapStrength;
            jump++;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            jump++;
        }

        if(jump > 3)
        {
            instruction.gameObject.SetActive(false);
        }

        if(myRigidbody.position.y < -80)
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
