using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int levelLength = 18;

    [SerializeField] private List<GameObject> prefabs;
    private Dictionary<string, GameObject> prefabsMap = new Dictionary<string, GameObject>();

    [SerializeField] private float bigRadius = 10;
    [SerializeField] private float smallRadius = 2;

    [Range(0,1)] [SerializeField] private float enemyChance = 0.35f;
    [Range(0,1)] [SerializeField] private float springChance = 0.35f;
    [Range(0,1)] [SerializeField] private float keyChance = 0.35f;
    [Range(0,1)] [SerializeField] private float spikesChance = 0.35f;

    void Awake()
    {
        foreach(GameObject obj in prefabs)
        {
            prefabsMap.Add(obj.name, obj);
        }

        GenerateLevel(levelLength);
    }

    void GenerateLevel(int platformCount)
    {
        // Generate Start platform
        Vector2 prevPos = Vector2.zero;
        Instantiate(prefabsMap["PlatformLarge"], prevPos, Quaternion.identity, transform);

        List<Vector2> otherPlatforms = new List<Vector2>();
        for(int i = 0; i < platformCount; i++)
        {
            Vector2 currPos;
            do
            {
                int angle = Random.Range(20, 160); // Should probably be added as parameters
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)); // Normalized because sin^2 + cos^2 = 1
                Vector2 randomVector = direction * Random.Range(smallRadius, bigRadius);
                
                currPos = prevPos + randomVector;
            } while (!IsOkPlace(currPos, otherPlatforms));

            prevPos = currPos;
            CreatePlatform(currPos);
            otherPlatforms.Add(currPos);
        }

        // Generate final platform
        GameObject finalPlatform = Instantiate(prefabsMap["PlatformLarge"], prevPos + Vector2.up * bigRadius, Quaternion.identity, transform);
        tryAddToPlatform(finalPlatform.transform, prefabsMap["Objective"], 1);
    }

    GameObject CreatePlatform(Vector2 position)
    {
        GameObject newPlatform = Instantiate(prefabsMap["PlatformLarge"], position, Quaternion.identity, transform);
        tryAddToPlatform(newPlatform.transform, prefabsMap["Enemy"], enemyChance);
        tryAddToPlatform(newPlatform.transform, prefabsMap["Key"], keyChance);
        tryAddToPlatform(newPlatform.transform, prefabsMap["Spring"], springChance);
        tryAddToPlatform(newPlatform.transform, prefabsMap["Spikes"], spikesChance);
        return newPlatform;
    }

    private void tryAddToPlatform(Transform parent, GameObject item, float chance)
    {
       if(Random.value <= chance)
       {
            List<Transform> possiblePostions = new List<Transform>();
            for(int i = 0; i < parent.childCount; i++)
            {
                if(parent.GetChild(i).childCount == 0)
                {
                    possiblePostions.Add(parent.GetChild(i));
                }
            }
            if(possiblePostions.Count > 0)
            {
                int indexChosen = Mathf.FloorToInt(Random.Range(0, possiblePostions.Count));
                Transform choice = possiblePostions[indexChosen];
                Instantiate(item, choice, false);
            }
       }
    }

    private bool IsOkPlace(Vector2 currentPos, List<Vector2> others)
    {
        foreach(Vector2 other in others)
        {
            if(Vector2.Distance(other, currentPos) < smallRadius)
            {
                return false;
            }
        }
        return true;
    }
}
