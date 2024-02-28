using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfPrefabInstances = 200;
    public Vector3 generationAreaSize = new Vector3(100f, 1f, 100f);

    public Transform parentContainer;

    private float absoluteGroundLevel;

    void Start()
    {
        absoluteGroundLevel = gameObject.transform.position.y;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, absoluteGroundLevel, gameObject.transform.position.z);

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < numberOfPrefabInstances; i++)
        {
            Vector3 randomPosition = GetRandomPositionInGenerationArea();
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            Instantiate(prefab, randomPosition, randomRotation, parentContainer.transform);
        }
    }

    Vector3 GetRandomPositionInGenerationArea()
    {
        Vector3 randomPosition = new Vector3(
           Random.Range(-generationAreaSize.x / 2, generationAreaSize.x / 2),
           0f,
           Random.Range(-generationAreaSize.z / 2, generationAreaSize.z / 2)
       );
        return transform.position + randomPosition;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, generationAreaSize);
    }
}