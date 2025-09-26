using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Movement vector
        Vector3 movement = new Vector3(moveX, 0, moveZ);

        // Move cube
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
