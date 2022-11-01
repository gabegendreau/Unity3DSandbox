using UnityEngine;

public class SpawnTetrisPiece : MonoBehaviour
{
    public GameObject squarePiece;
    public GameObject longPiece;
    public GameObject teePiece;
    public GameObject ellRPiece;
    public GameObject ellLPiece;
    public GameObject zagRPiece;
    public GameObject zagLPiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnPiece();
        }
    }

    void spawnPiece()
    {
        int randomNum = Random.Range(0, 6);
        GameObject newPiece;
        switch(randomNum)
        {
            case 0:
                newPiece = squarePiece;
                break;
            case 1:
                newPiece = longPiece;
                break;
            case 2:
                newPiece = teePiece;
                break;
            case 3:
                newPiece = ellRPiece;
                break;
            case 4:
                newPiece = ellLPiece;
                break;
            case 5:
                newPiece = zagRPiece;
                break;
            case 6:
                newPiece = zagLPiece;
                break;
            default:
                newPiece = longPiece;
                Debug.Log("A sufficient random number was not provided");
                break;
        }
        Instantiate(newPiece, gameObject.transform.position, Quaternion.identity);
    }
}
