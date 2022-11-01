using UnityEngine;

public class LoadTetris : MonoBehaviour
{
    bool canPlay;
    bool gottaDollar;
    PlayerWallet wallet;

    // Start is called before the first frame update
    void Start()
    {
        gottaDollar = false;
        wallet = FindObjectOfType<PlayerWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Looks like this machine ate your money...");
                wallet.deductMoney(1);
                setCanPlay(true);
            }
        }
    }

    public void setCanPlay(bool value)
    {
        if (value && gottaDollar)
        {
            canPlay = true;
        }
        if (!value)
        {
            canPlay = false;
        }
        if (!gottaDollar)
        {
            canPlay = false;
        }
    }

    public void setGottaDollar(bool value)
    {
        if (value)
        {
            gottaDollar = true;
        } else {
            gottaDollar = false;
        }
    }
}
