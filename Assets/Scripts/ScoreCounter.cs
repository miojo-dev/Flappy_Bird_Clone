using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject
            .FindGameObjectWithTag("ScoreManager")
            .GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.score++;
        }
    }
}