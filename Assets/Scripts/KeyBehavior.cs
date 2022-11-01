using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public OpenChest chestToOpen;
    UIManager uiManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            chestToOpen.setHasKey();
            uiManager.updateKeyIcon(true);
            soundManager.playGetKey();
            Destroy(gameObject);
        }
    }
}
