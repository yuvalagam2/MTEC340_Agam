using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    public GameObject _brickContainer;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        _brickContainer = GameObject.Find("Bricks");
    }

    // Update is called once per frame
    void Update()
    {
        if (_brickContainer.transform.childCount == 0) {
            Debug.Log("YOU WIN!!!");
        }
    }
}
