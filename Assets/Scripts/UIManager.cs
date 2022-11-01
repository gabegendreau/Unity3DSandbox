using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
public TextMeshProUGUI moneyText;
public TextMeshProUGUI tacoText;
public TextMeshProUGUI logsTitleText;
public TextMeshProUGUI logsText;
PlayerWallet playerWallet;
TacoManager tacoManager;
public GameObject keyIcon;
public GameObject healthMeter;
public Sprite health_6;
public Sprite health_5;
public Sprite health_4;
public Sprite health_3;
public Sprite health_2;
public Sprite health_1;
public Sprite health_0;


    // Start is called before the first frame update
    void Start()
    {
        playerWallet = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWallet>();
        tacoManager = GameObject.FindGameObjectWithTag("Player").GetComponent<TacoManager>();
        updateMoneyText();
        updateTacoText();
    }

    public void updateMoneyText()
    {
        moneyText.text = playerWallet.getWalletAmount().ToString();
    }

    public void updateTacoText()
    {
        tacoText.text = tacoManager.getNumTacos().ToString();
    }

    public void updatelogsText()
    {
        int wasParsed;
        int currentAmount;
        if (int.TryParse(logsText.text, out wasParsed))
        {
            currentAmount = int.Parse(logsText.text);
            currentAmount++;
            logsText.text = currentAmount.ToString();
        }
    }

    public void resetLogText()
    {
        logsText.text = "0";
    }

    public void toggleLogsUI(bool active)
    {
        if (active)
        {
            logsText.GetComponent<TextMeshProUGUI>().enabled = true;
            logsTitleText.GetComponent<TextMeshProUGUI>().enabled = true;
        } else {
            logsText.GetComponent<TextMeshProUGUI>().enabled = false;
            logsTitleText.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    public void updateKeyIcon(bool hasKey)
    {
        if(hasKey)
        {
            keyIcon.SetActive(true);
        } else {
            keyIcon.SetActive(false);
        }
    }

    public void updateHealthMeter(int health)
    {
        switch(health)
        {
            case 0:
                healthMeter.GetComponent<Image>().sprite = health_0;
                break;
            case 1:
                healthMeter.GetComponent<Image>().sprite = health_1;
                break;
            case 2:
                healthMeter.GetComponent<Image>().sprite = health_2;
                break;
            case 3:
                healthMeter.GetComponent<Image>().sprite = health_3;
                break;
            case 4:
                healthMeter.GetComponent<Image>().sprite = health_4;
                break;
            case 5:
                healthMeter.GetComponent<Image>().sprite = health_5;
                break;
            case 6:
                healthMeter.GetComponent<Image>().sprite = health_6;
                break;
            default: 
                healthMeter.GetComponent<Image>().sprite = health_0;
                break;
        }
    }

    public void showHideHealth(bool show)
    {
        if(show)
        {
            healthMeter.GetComponent<Image>().enabled = true;
        }
        if(!show)
        {
            healthMeter.GetComponent<Image>().enabled = false;
        }
    }
}
