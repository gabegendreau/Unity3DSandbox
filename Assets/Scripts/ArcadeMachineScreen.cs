using UnityEngine;

public class ArcadeMachineScreen : MonoBehaviour
{
    public Material activeScreenMaterial;
    public Material defaultScreenMaterial;
    Material[] arcadeMachineMats;
    GameObject machine;
    MeshRenderer arcadeRenderer;
    LoadTetris gameLoadScript;

    // Start is called before the first frame update
    void Start()
    {
        machine = GameObject.Find("ArcadeMesh");
        arcadeRenderer = machine.GetComponent<MeshRenderer>();
        arcadeMachineMats = arcadeRenderer.materials;
        gameLoadScript = GetComponent<LoadTetris>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            arcadeMachineMats[6] = activeScreenMaterial;
            arcadeRenderer.materials = arcadeMachineMats;
            gameLoadScript.setCanPlay(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            arcadeMachineMats[6] = defaultScreenMaterial;
            arcadeRenderer.materials = arcadeMachineMats;
            gameLoadScript.setCanPlay(false);
        }
    }
}
