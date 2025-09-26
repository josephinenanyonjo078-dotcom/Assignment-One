using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Trail Settings")]
    public GameObject spherePrefab;   // assign a small sphere prefab in Inspector
    public float spawnInterval = 0.2f;
    public float sphereLifetime = 5f;

    [Header("Camera Follow")]
    public Transform cameraTransform; 
    public Vector3 cameraOffset = new Vector3(0, 5, -7);
    public float followSmoothness = 5f;

    private float spawnTimer;

    void Update()
    {
        // --- Movement ---
        float h = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float v = Input.GetAxis("Vertical");   // W/S or Up/Down arrows
        Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // --- Trail spawning ---
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && move.magnitude > 0f)
        {
            SpawnTrailSphere();
            spawnTimer = 0f;
        }

        // --- Camera follow ---
        if (cameraTransform != null)
        {
            Vector3 targetPos = transform.position + cameraOffset;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPos, followSmoothness * Time.deltaTime);
            cameraTransform.LookAt(transform);
        }
    }

    void SpawnTrailSphere()
    {
        GameObject s = Instantiate(spherePrefab, transform.position, Quaternion.identity);
        Destroy(s, sphereLifetime);

        // Add color cycling
        TrailSphereColor tsc = s.AddComponent<TrailSphereColor>();
        tsc.colorSpeed = Random.Range(0.5f, 2f); // each sphere gets a slightly different cycle speed
    }
}

// Handles color cycling for trail spheres
public class TrailSphereColor : MonoBehaviour
{
    public float colorSpeed = 1f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float h = Mathf.PingPong(Time.time * colorSpeed, 1f);
        rend.material.color = Color.HSVToRGB(h, 1f, 1f);
    }
}
