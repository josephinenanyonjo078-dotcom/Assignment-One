using UnityEngine;

public class ClickChangeShapeOnly : MonoBehaviour
{
    public Mesh[] meshes;   // Assign Cube, Sphere, Cylinder meshes in Inspector
    private MeshFilter mf;

    void Start()
    {
        mf = GetComponent<MeshFilter>();

        if (meshes.Length == 0)
        {
            Debug.LogError("Please assign meshes in the Inspector!");
        }
    }

    void OnMouseDown()
    {
        // Randomly select a mesh from the array
        int index = Random.Range(0, meshes.Length);
        mf.mesh = meshes[index];
    }
}
