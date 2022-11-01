using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    Vector3 dropAmountVector;
    public float dropAmount;
    public float dropDelay;
    bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        dropAmountVector = new Vector3(0.0f, dropAmount, 0.0f);
        isActive = true;
        dropPiece();
    }

    public void dropPiece()
    {
        gameObject.transform.position -= dropAmountVector;
        Invoke("checkToContinue", dropDelay);
    }

    public void checkToContinue()
    {
        if (isActive)
        {
            dropPiece();
        } else {
            Debug.Log("dead piece");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asdasd");
        isActive = false;
    }
}
