using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static private GameController instance;
    [SerializeField] GameObject character;
    [SerializeField] private GameObject player;
    int levelNamber = 1;
    [SerializeField] GameObject curLevelPlatform;
    [SerializeField] private DataLevel dataLevel;
    private GameController() {}
    public static GameController Instance { get => instance;}

    private void Awake()
    {
        if(Instance == null) { instance = this; }
    }

    public void NextLevel() {
        levelNamber++;
        var levelPrefab = dataLevel.GetLevelPrefab(levelNamber);
        if (levelPrefab != null)
        {
            Destroy(curLevelPlatform.gameObject);
            curLevelPlatform = Instantiate(dataLevel.GetLevelPrefab(levelNamber), dataLevel.LevelPoint.parent);
            PlayerDefaultSetup();
            CleanSticksAround();
        }
        else return;
        
    }
    public void ReturnLevel() {
        Destroy(curLevelPlatform.gameObject);
        curLevelPlatform = Instantiate(dataLevel.GetLevelPrefab(0), dataLevel.LevelPoint.parent);
        PlayerDefaultSetup(); 
        CleanSticksAround(); 
    }

   void CleanSticksAround()
    {
        StickManManager[] stickManManagers = player.transform.GetComponentsInChildren<StickManManager>();
        for (int i = 1; i < stickManManagers.Length; i++)
        {
            Destroy(stickManManagers[i].gameObject);
        }
    }
    void PlayerDefaultSetup()
    {
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        playerManager.roadSpeed = 2f;
        player.transform.position = dataLevel.PlayerPoint.position;
        var characterGo = Instantiate(character);
        characterGo.transform.localScale = new Vector3(1,1,1);
        characterGo.transform.SetParent(player.transform);
        characterGo.transform.localPosition = new Vector3(0f, -0.55f, 0f);
        player.gameObject.SetActive(true);
        characterGo.SetActive(true);
        playerManager.FinishLine = false;
        playerManager.gameState = true;
        playerManager.Road = curLevelPlatform.transform;
        var textObj = player.transform.GetChild(0).gameObject;
        textObj.GetComponentInChildren<TextMeshPro>().text = "0".ToString();
        textObj.SetActive(true);
        
        
    }

    public bool IsDied()
    {
        if (player.transform.GetChildCount() < 3) { return true; } else return false;
    }
}
