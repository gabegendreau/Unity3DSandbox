using UnityEngine;

public class TacoBehavior : MonoBehaviour
{
    TacoManager tacoManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        tacoManager = FindObjectOfType<TacoManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eatTaco();
        }
    }

    void eatTaco()
    {
        tacoManager.addTaco();
        soundManager.playTacoEat();
        Destroy(gameObject);
    }
}
