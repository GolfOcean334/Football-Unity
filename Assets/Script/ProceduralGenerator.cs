using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfPrefabInstances = 200;
    public Vector3 generationAreaSize = new Vector3(100f, 1f, 100f);
    public Transform parentContainer;

    public float absoluteGroundLevel = 0f;

    public bool useCustomSeed = false;
    public int customSeed = 0;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, absoluteGroundLevel, transform.position.z);

        if (useCustomSeed)
        {
            Random.InitState(customSeed);
        }
        else
        {
            // Génère une seed aléatoire basée sur le temps
            int randomSeed = (int)System.DateTime.Now.Ticks;
            Random.InitState(randomSeed);
        }

        Generate();
    }

    void Generate()
    {
        if (prefab == null || parentContainer == null)
        {
            Debug.LogError("Prefab ou parentContainer n'est pas initié correctement.");
            return;
        }

        for (int i = 0; i < numberOfPrefabInstances; i++)
        {
            Vector3 randomPosition = GetRandomPositionInGenerationArea();
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            Instantiate(prefab, randomPosition, randomRotation, parentContainer);
        }
    }

    Vector3 GetRandomPositionInGenerationArea()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-generationAreaSize.x / 2, generationAreaSize.x / 2), 0f, Random.Range(-generationAreaSize.z / 2, generationAreaSize.z / 2));
        return transform.position + randomPosition;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, generationAreaSize);
    }

    private void CustomSeed()
    {
        useCustomSeed = true;
    }

    private void DontUseCustomSeed()
    {
        useCustomSeed = false;
    }
}
