using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public float cooling;
    private float _cooldown;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cooldown = cooling;
        scoreManager = GameObject
            .FindGameObjectWithTag("ScoreManager")
            .GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
        Time.timeScale = 1 + ((scoreManager.score + 1) * 0.02f);
    }

    void Cooldown()
    {
        cooling -= Time.deltaTime;
        if (cooling <= 0f)
        {
            SpawnObstacle();
            cooling = _cooldown;
        }
    }

    void SpawnObstacle()
    {
        if (!GameManager.Instance.running)
            return;
        Instantiate(
            obstacle,
            new Vector3(5, Random.Range(-3, 3), 0),
            Quaternion.identity
        );
    }
}