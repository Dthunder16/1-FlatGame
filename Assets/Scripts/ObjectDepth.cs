using UnityEngine;

public class ObjectDepth : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = -(int)(transform.position.y * 100);
    }
}
