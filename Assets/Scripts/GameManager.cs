using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null) instance = this as T;
        else if (instance != this) Destroy(gameObject);
    }
}

public class ScoreManager : Singleton<ScoreManager>
{
    private int TotalScore = 0;

    public void AddScore(int Points)
    {
        TotalScore += Points;
        Debug.Log("Score Updated: " + TotalScore);
    }

    public int GetScore() => TotalScore;

    public void ResetScore()
    {
        TotalScore = 0;
        Debug.Log("Score Reset: 0");
    }
}

public class GameManager : Singleton<GameManager>
{
    public FruitSpawner FruitSpawnerRef;
    public int HighScoreGoal = 500;

    private void Start()
    {
        Debug.Log("GameManager started");
        ScoreManager.Instance.ResetScore();

        if (FruitSpawnerRef != null)
        {
            Debug.Log("Calling FruitSpawnerEvent");
            FruitSpawnerRef.FruitSpawnerEvent();
        }
    }

    public void OnFruitEaten()
    {
        if (FruitSpawnerRef != null)
            FruitSpawnerRef.FruitSpawnerEvent();

        if (ScoreManager.Instance.GetScore() >= HighScoreGoal)
            Debug.Log("HIGH SCORE CHALLENGE COMPLETE");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 300, 40), "Score: " + ScoreManager.Instance.GetScore() + " / " + HighScoreGoal);
    }
}