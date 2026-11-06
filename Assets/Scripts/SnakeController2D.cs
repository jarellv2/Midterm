using System.Collections.Generic;
using UnityEngine;

public class SnakeController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject tailPrefab;
    private List<Transform> bodySegments = new List<Transform>();

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, v, 0).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        for (int i = bodySegments.Count - 1; i > 0; i--)
            bodySegments[i].position = Vector3.Lerp(bodySegments[i].position, bodySegments[i - 1].position, Time.deltaTime * 12f);

        if (bodySegments.Count > 0)
            bodySegments[0].position = Vector3.Lerp(bodySegments[0].position, transform.position, Time.deltaTime * 12f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FruitBase fruit = other.GetComponent<FruitBase>();
        if (fruit != null)
        {
            fruit.Collect(); 
            GrowTail2D();
            GameManager.Instance.OnFruitEaten(); 
        }
    }

    private void GrowTail2D()
    {
        GameObject seg = new GameObject("TailSegment");
        SpriteRenderer sr = seg.AddComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.color = new Color(0.2f, 0.8f, 0.2f);
        seg.transform.localScale = transform.localScale * 0.85f;
        seg.transform.position = transform.position;
        bodySegments.Add(seg.transform);
    }
}