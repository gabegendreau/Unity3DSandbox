using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool hasKey;
    public GameObject openedChest;
    UIManager uiManager;
    bool canOpenChest;
   
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        uiManager = FindObjectOfType<UIManager>();
        canOpenChest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenChest)
        {
            openChest();
        }
    }

    public bool getHasKey()
    {
        return hasKey;
    }

    public void setHasKey()
    {
        hasKey = true;
    }

    private void openChest()
    {
        uiManager.updateKeyIcon(false);
        hasKey = false;
        Vector3 SpawnLocation = gameObject.transform.position;
        Quaternion SpawnRotation = gameObject.transform.rotation;
        Destroy(gameObject);
        Instantiate(openedChest, SpawnLocation, SpawnRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasKey)
        {
            canOpenChest = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpenChest = false;
        }
    }
}
