using UnityEngine;
using TMPro;

public class ShowCoinsValue : MonoBehaviour
{
    int coinAmount;
    public GameObject popupPrefab;
    public float floatUpAmount;
    Vector3 floatUpVector;
    Vector3 spawnLocation;
    Quaternion spawnRotation;
    bool fadeOut;
    public float fadeOutDelay;
    public float fadeOutAmount;
    Color tempColor;
    GameObject popupObject;

    // Start is called before the first frame update
    void Start()
    {   
        coinAmount = FindObjectOfType<GetLoot>().getValue();
        spawnLocation = gameObject.transform.position;
        spawnRotation = Quaternion.identity;
        spawnRotation *= Quaternion.Euler(0, -90, 0);
        popupObject = Instantiate(popupPrefab, spawnLocation, spawnRotation) as GameObject;
        popupObject.GetComponent<TextMeshPro>().text = coinAmount.ToString();
        Debug.Log(popupObject.name);
        floatUpVector = new Vector3(0.0f, floatUpAmount, 0.0f);
        tempColor = popupObject.GetComponent<TextMeshPro>().color;
        fadeOut = false;
        Invoke("startFadeOut", fadeOutDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (popupObject != null)
        {
            popupObject.transform.position += floatUpVector * Time.deltaTime;
            Debug.Log("up amount: " + floatUpVector * Time.deltaTime);
            if (fadeOut)
            {
                tempColor.a -= fadeOutAmount * Time.deltaTime;
                Debug.Log("fading step amt: " + fadeOutAmount * Time.deltaTime);
                popupObject.GetComponent<TextMeshPro>().color = tempColor;
                Debug.Log(tempColor.a);
                if (popupObject.GetComponent<TextMeshPro>().color.a <= 0)
                {
                    Destroy(popupObject);
                    Debug.Log("Destroyed");
                    fadeOut = false;
                }
            }

        }
    }

    void startFadeOut()
    {
        fadeOut = true;
    }
}
 