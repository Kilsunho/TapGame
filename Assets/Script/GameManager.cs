using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singleton = new GameObject("GameManager");
                instance = singleton.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public GameController GameController;
    public UIManager uiManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameController.Init();
        uiManager.Init();
    }
}