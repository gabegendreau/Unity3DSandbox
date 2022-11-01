using UnityEngine;

public class ShootingRangeGateway : MonoBehaviour
{
    bool playerInside;
    bool canEnter;
    bool canExit;
    bool hasTenBucks;
    public GameObject player;
    public Vector3 teleportDistance;
    public GameObject ToggleLight;
    public GameObject toggleCrosshair;
    public GameObject toggleWeapon;
    SpawnLog logSpawner;
    UIManager uiManager;
    PlayerWallet wallet;
    public GameObject gameOverSpawnLocation;
    Vector2 exitShootingLocation;

    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        canEnter = false;
        canExit = false;
        hasTenBucks = false;
    }

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        wallet = FindObjectOfType<PlayerWallet>();
        logSpawner = FindObjectOfType<SpawnLog>();
        exitShootingLocation = gameOverSpawnLocation.transform.position;
    }

    void Update()
    {
        if (canEnter || canExit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                useGateway();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerInside)
            {
                canExit = true;
            }
            if (!playerInside && hasTenBucks)
            {
                canEnter = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerInside)
            {
                canExit = false;
            }
            if (!playerInside)
            {
                canEnter = false;
            }
        }        
    }

    void useGateway()
    {
        Vector3 currentPosition = player.transform.position;
        Vector3 newPosition = currentPosition;
        // What happens when you go in
        if (canEnter) {
            canEnter = false;
            canExit = true;
            ToggleLight.SetActive(false);
            toggleWeapon.SetActive(true);
            toggleCrosshair.SetActive(true);
            uiManager.showHideHealth(true);
            uiManager.toggleLogsUI(true);
            logSpawner.SetPlayerInArena(true);
            wallet.deductMoney(10);
        }
        if (playerInside)
        {
            ExitShootingArena();
        }
        else if (!playerInside)
        {
            newPosition = currentPosition + teleportDistance;
            playerInside = true;
            player.transform.position = newPosition;
        }
    }

    void ClearLogsAndHoles()
    {
        LogRun[] leftoverLogs = FindObjectsOfType<LogRun>();
        if (leftoverLogs.Length != 0)
        {
            foreach (LogRun angryLog in leftoverLogs)
            {
                Destroy(angryLog.gameObject);
            }
        }
        GameObject[] leftoverBulletHoles = GameObject.FindGameObjectsWithTag("BulletHole");
        foreach (GameObject leftoverBulletHole in leftoverBulletHoles)
        {
            Destroy(leftoverBulletHole);
        }
    }

    public void setHasTenBucks(bool value)
    {
        if (value)
        {
            hasTenBucks = true;
        } else {
            hasTenBucks = false;
        }
    }

    public void ExitShootingArena()
    {
        toggleCrosshair.SetActive(false);
        toggleWeapon.SetActive(false);
        ToggleLight.SetActive(true);
        uiManager.showHideHealth(false);
        player.transform.position = exitShootingLocation;
        playerInside = false;
        canExit = false;
        canEnter = true;
        logSpawner.SetPlayerInArena(false);
        Invoke("resetShootingArena", 3.0f);
    }

    void resetShootingArena()
    {
        uiManager.toggleLogsUI(false);
        ClearLogsAndHoles();
        uiManager.resetLogText();

    }
}
