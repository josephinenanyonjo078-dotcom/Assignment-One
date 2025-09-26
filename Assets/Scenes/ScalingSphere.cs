using UnityEngine;

public class ScalingSphere : MonoBehaviour
{
    public Vector3 bigScale = new Vector3(2, 2, 2);
    public Vector3 normalScale = Vector3.one;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle between big and normal size
            if (transform.localScale == normalScale)
                transform.localScale = bigScale;
            else
                transform.localScale = normalScale;
        }
    }
}
