using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float startPos, length;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect; //0 = move with camera || 1 = wont move || 0.5 = half
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        //if background's bounds have been reached, adjust for infinite scrolling
        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
