using UnityEngine;

public class GetTaco : MonoBehaviour
{
    private bool hasEnoughMoney;
    private bool canBuyTaco;
    Collider boxCollider;
    public GameObject TacoPrefab;
    PlayerWallet wallet;
    public GameObject spawnLocationObject;
    public float spawnXoffset;
    public float spawnZoffset;
    public Material standOpen;
    public Material standClosed;
    Renderer standRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        hasEnoughMoney = false;
        canBuyTaco = false;
        boxCollider = gameObject.GetComponent<Collider>();
        wallet = FindObjectOfType<PlayerWallet>();
        standRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canBuyTaco)
            {
                spawnTaco();
            }
        }
    }

    public void setHasEnoughMoney(bool hasTheCash)
    {
        if (hasTheCash)
        {
            hasEnoughMoney = true;
            standRenderer.material = standOpen;
        }
        else if (!hasTheCash)
        {
            hasEnoughMoney = false;
            standRenderer.material = standClosed;
            canBuyTaco = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasEnoughMoney)
        {
            canBuyTaco = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBuyTaco = false;
        }
    }

    public void spawnTaco()
    {   
        Vector3 tacoStandPosition = gameObject.transform.position;
        Vector3 spawnLocation = spawnLocationObject.transform.position;
        float xOffset = Random.Range(-spawnXoffset, spawnXoffset);
        float zOffset = Random.Range(-spawnZoffset, spawnZoffset);
        Vector3 offsetSpawnLocation = new Vector3(spawnLocation.x - xOffset, spawnLocation.y, spawnLocation.z - zOffset);
        Instantiate(TacoPrefab, offsetSpawnLocation, Quaternion.identity);
        wallet.deductMoney(5);
    }
}
