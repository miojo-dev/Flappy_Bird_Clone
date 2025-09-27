using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.running)
            return;
        MoveTower();
    }

    void MoveTower()
    {
        transform.position += new Vector3(
            -speed * Time.deltaTime, 0, 0
        );
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.enabled = false;
        }
    }
}