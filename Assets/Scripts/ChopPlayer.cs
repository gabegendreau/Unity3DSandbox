using UnityEngine;

public class ChopPlayer : MonoBehaviour
{
    bool coolDown;

    // Start is called before the first frame update
    void Start()
    {
        coolDown = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!coolDown)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<HealthManager>().getHit();
                coolDown = true;
                Invoke("ResetCoolDown", 1.0f);
            }
        }
    }

    void ResetCoolDown()
    {
        coolDown = false;
    }
}
