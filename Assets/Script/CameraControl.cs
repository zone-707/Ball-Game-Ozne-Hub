using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = this.transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = ball.transform.position + offset;
    }
}
