using UnityEngine;

public class HealthManager : MonoBehaviour
{
    int health;
    public int defaultHealth;
    UIManager uiManager;
    ShootingRangeGateway gatewayScript;

    // Start is called before the first frame update
    void Start()
    {
        health = defaultHealth;    
    }

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        gatewayScript = FindObjectOfType<ShootingRangeGateway>();
    }

    public void getHit()
    {
        health--;
        checkHealth();
    }

    void checkHealth()
    {
        uiManager.updateHealthMeter(health);
        if (health == 0)
        {
            gatewayScript.ExitShootingArena();
            health = defaultHealth;
        }
    }
}
