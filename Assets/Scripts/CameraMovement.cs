using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed = 2.0f;
    public float yOffset = 3.5f;
    public Transform target;

    public void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10.0f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
    
}
