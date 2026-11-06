using UnityEngine;
public class FruitSpawner : MonoBehaviour
{
    public FruitBase FruitClass;

    public virtual FruitBase FruitSpawnerEvent()
    {
        Debug.Log("Entered FruitSpawner -> FruitSpawnerEvent");
        Debug.Log("SpawnFruitEvent started");

        Vector2 randomPos = new Vector2(Random.Range(-6f, 6f), Random.Range(-3.5f, 3.5f));
        return Instantiate(FruitClass, randomPos, Quaternion.identity);
    }
}

public class FruitSpawner_Apple : FruitSpawner
{  
    public override FruitBase FruitSpawnerEvent()
    {
        return base.FruitSpawnerEvent();
    }
}