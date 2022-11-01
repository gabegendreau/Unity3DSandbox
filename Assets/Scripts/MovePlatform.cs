using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    public Vector3 moveDistance;
    public float moveSpeed;
    bool isLerpVector3;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        endPosition = startPosition + moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Vector3LerpCoroutineForward(GameObject obj, Vector3 target, float speed)
    {
        float time = 0f;

        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time/Vector3.Distance(startPosition, target))*speed);
            time += Time.deltaTime;
            yield return null;
        }   
    }

    IEnumerator Vector3LerpCoroutineReturn(GameObject obj, Vector3 target, float speed)
    {
        float time = 0f;
        Vector3 currentPos = obj.transform.position;

        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(currentPos, target, (time/Vector3.Distance(currentPos, target))*speed);
            time += Time.deltaTime;
            yield return null;
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Vector3LerpCoroutineForward(gameObject, endPosition, moveSpeed));
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Vector3LerpCoroutineReturn(gameObject, startPosition, moveSpeed));
            other.transform.parent = null;
        }
    }
}
