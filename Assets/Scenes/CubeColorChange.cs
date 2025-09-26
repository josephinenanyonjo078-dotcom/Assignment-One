using UnityEngine;

public class CubeColorChange : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Ccc))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}