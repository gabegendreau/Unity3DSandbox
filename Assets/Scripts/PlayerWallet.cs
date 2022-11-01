using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    GameObject player;
    int walletValue;
    UIManager uiManager;
    GetTaco tacoScript;
    LoadTetris tetrisScript;
    GameObject shooterEnterSign;
    public Material shootingRangeActive;
    public Material shootingRangeFaded;
    ShootingRangeGateway shootingGateway;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        walletValue = 0; 
    }

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();   
        tacoScript = FindObjectOfType<GetTaco>();
        tetrisScript = FindObjectOfType<LoadTetris>();
        shooterEnterSign = GameObject.Find("ShootingEnterSign");
        shootingGateway = FindObjectOfType<ShootingRangeGateway>();
    }

    public void addCoin(int value)
    {
        walletValue += value;
        uiManager.updateMoneyText();
        checkTacoMoney();
        checkForDollar();
        checkShootingMoney();
    }

    public int getWalletAmount()
    {
        return walletValue;
    }

    public void checkTacoMoney()
    {
        if (walletValue < 5)
        {
            tacoScript.setHasEnoughMoney(false);
        }
        else if (walletValue >= 5)
        {
            tacoScript.setHasEnoughMoney(true);
        }
    }

    public void checkShootingMoney()
    {
        if (walletValue < 10)
        {
            shooterEnterSign.GetComponent<MeshRenderer>().material = shootingRangeFaded;
            shootingGateway.setHasTenBucks(false);
        } else if (walletValue >= 10)
        {
            shooterEnterSign.GetComponent<MeshRenderer>().material = shootingRangeActive;
            shootingGateway.setHasTenBucks(true);
        }
    }

    public void deductMoney(int value)
    {
        walletValue -= value;
        uiManager.updateMoneyText();
        checkTacoMoney();
        checkForDollar();
        checkShootingMoney();
    }

    public void checkForDollar()
    {
        if (walletValue > 0)
        {
            tetrisScript.setGottaDollar(true);
        } else {
            tetrisScript.setGottaDollar(false);
        }
    }
}
