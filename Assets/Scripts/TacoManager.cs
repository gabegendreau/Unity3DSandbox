using UnityEngine;

public class TacoManager : MonoBehaviour
{
    public UIManager uiManager;
    private int numTacos;
    
    // Start is called before the first frame update
    void Start()
    {
        numTacos = 0;
    }

    public int getNumTacos()
    {
        return numTacos;
    }

    public void addTaco()
    {
        numTacos++;
        uiManager.updateTacoText();
    }
}
