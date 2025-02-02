using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float sectionSpawnZ;
    [SerializeField] private float sectionLength;
    [SerializeField] private int sectionSpawnCount;
    
    [SerializeField] private GameObject[] prefabs;

    private Transform sectionContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sectionContainer = new GameObject("Sections").transform;

        for (int i = 0; i < sectionSpawnCount; i++)
        {
            SpawnSection();
        }
    }

    public void OnPlayerEnteredTrigger()
    {
        SpawnSection();
    }

    void SpawnSection()
    {
        GameObject instantiate = Instantiate(prefabs[Random.Range(0, prefabs.Length)], Vector3.forward * sectionSpawnZ,
            Quaternion.identity);

        instantiate.transform.SetParent(sectionContainer);

        if (sectionContainer.childCount > sectionSpawnCount + 1)
        {
            Destroy(sectionContainer.GetChild(0).gameObject);
        }

        sectionSpawnZ += sectionLength;
    }
}