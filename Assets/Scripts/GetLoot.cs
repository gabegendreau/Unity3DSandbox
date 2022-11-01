using UnityEngine;

public class GetLoot : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip chestOpenSound;
    public float fadeOutAmount;
    public float delayBeforeFade;
    Color tempColor;
    private bool coinsAreFading;
    PlayerWallet playerWallet;
    public int lootAmount;

    // Start is called before the first frame update
    void Start()
    {
        coinsAreFading = false;
        playerWallet = FindObjectOfType<PlayerWallet>();
        tempColor = GameObject.FindGameObjectWithTag("PileOfCoins").GetComponent<MeshRenderer>().material.color;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(chestOpenSound);
        Invoke("fadeOutCoins", delayBeforeFade);
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsAreFading)
        {
            tempColor.a -= fadeOutAmount * Time.deltaTime;
            GameObject.FindGameObjectWithTag("PileOfCoins").GetComponent<MeshRenderer>().material.color = tempColor;
            if (tempColor.a <= 0.00f)
            {
                GameObject.FindGameObjectWithTag("PileOfCoins").GetComponent<MeshRenderer>().enabled = false;
                coinsAreFading = false;
            }
        }
    }

    void fadeOutCoins()
    {
        coinsAreFading = true;
        playerWallet.addCoin(lootAmount);
    }

    public int getValue()
    {
        return lootAmount;
    }
}
