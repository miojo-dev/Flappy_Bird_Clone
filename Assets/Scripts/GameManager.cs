using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool running = true;

    private void Awake() => Instance = this;
}