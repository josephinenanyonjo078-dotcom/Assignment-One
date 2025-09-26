using UnityEngine;

public class CubeColorChange : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}