using UnityEngine;

public class CapsuleSpin : MonoBehaviour
{
    public float spinSpeed = 180f; // degrees per second

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
            {
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
            }
    }
}
