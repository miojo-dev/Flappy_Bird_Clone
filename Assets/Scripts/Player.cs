using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jump = 5f;
    public ScoreManager scoreManager;
    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().mass = 0;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        GameManager.Instance.running = false;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody2D>().mass = 2;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            GameManager.Instance.running = true;
            gameObject.GetComponent<Rigidbody2D>()
                .linearVelocity = Vector2.up * jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            this.enabled = false;
            gameOver.gameObject.SetActive(true);
            GameManager.Instance.running = false;
        }
    }
}