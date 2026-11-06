using UnityEngine;

public class FruitBase : MonoBehaviour
{
    public virtual void Collect()
    {
        Debug.Log("Base Fruit Collected!");
    }
}

public class Fruit_Apple : FruitBase
{
    public override void Collect()
    {
        Debug.Log("Apple Collected! +100");
        ScoreManager.Instance.AddScore(100);
        Destroy(gameObject);
    }
}