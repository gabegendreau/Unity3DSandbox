using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    GameObject coin;
    Collider boxCollision;
    private bool coinVisible;
    public int value;
    public int respawnTime;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        coin = gameObject;    
        boxCollision = gameObject.gameObject.GetComponent<Collider>();
        coinVisible = true;
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && coinVisible == true)
        {
            PlayerWallet wallet = other.gameObject.GetComponent<PlayerWallet>();
            wallet.addCoin(value);
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            soundManager.playCoinCollect();
            coinVisible = false;
            Invoke("newCoin", respawnTime);
        }
    }

    private void newCoin()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        coinVisible = true;
    }
}
