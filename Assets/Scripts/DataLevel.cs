using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Custom/Level Data")]
public class DataLevel : ScriptableObject
{
    [SerializeField] private GameObject[] prefabsLevels;
    [SerializeField] private Transform levelPoint;
    [SerializeField] private Transform playerPoint;
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;
    public GameObject[] EnemyPrefabs { get => enemyPrefabs; }
    public Transform LevelPoint { get => levelPoint; }
    public Transform PlayerPoint { get => playerPoint; }

    public GameObject GetLevelPrefab(int curLevel)
    {
        try
        {
            return prefabsLevels[curLevel];
        }
        catch (System.Exception)
        {
           Debug.Log("levelIsnot");
        }
        return prefabsLevels[0];
    }

}

