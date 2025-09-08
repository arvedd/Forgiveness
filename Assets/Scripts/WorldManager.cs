using UnityEngine;

public enum WorldState
{
    Real,
    Spirit
}

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    public GameObject realWorld;
    public GameObject spiritWorld;
    public bool canSwitchWorld = false;
    public bool isAlreadyPickUp = false;

    public WorldState currentWorld = WorldState.Real;

    void Awake()
    {
        Instance = this;
    }

    public void SwitchWorld()
    {
        if (!canSwitchWorld || !isAlreadyPickUp)
        {
            Debug.Log("Can't switch world");
            return;
        }
        
        ScreenFader.Instance.StartCoroutine(ScreenFader.Instance.FadeTransition(() => 
        {

            bool toSpirit = currentWorld == WorldState.Real;

            realWorld.SetActive(!toSpirit);
            spiritWorld.SetActive(toSpirit);

            currentWorld = toSpirit ? WorldState.Spirit : WorldState.Real;

            Debug.Log("Switched to: " + currentWorld);
        }));
        
    }
}
