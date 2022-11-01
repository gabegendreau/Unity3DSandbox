using UnityEngine;

public class RotateObject : MonoBehaviour
{
    GameObject objectToRotate;
    public float xRotate;
    public float yRotate;
    public float zRotate;

    // Start is called before the first frame update
    void Start()
    {
        objectToRotate = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        objectToRotate.transform.Rotate(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime, Space.Self);
    }
        
}
