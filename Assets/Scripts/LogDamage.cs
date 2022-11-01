using UnityEngine;

public class LogDamage : MonoBehaviour
{
    public int hitsToKill;
    int timesHit;
    bool isBeingDestroyed;
    public GameObject shotParticle;
    public GameObject smokeParticle;
    public float knockBackAmount;
    UIManager uiManager;

    public void Start()
    {
        timesHit = 0;
        isBeingDestroyed = false;
    }

    public void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void GetShot(Vector3 shotDirection)
    {
        if (!isBeingDestroyed)
        {
            timesHit++;
            if (timesHit >= hitsToKill)
            {
                Die();
            }
            Instantiate(shotParticle, gameObject.transform.position, Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().AddForce(shotDirection * knockBackAmount, ForceMode.Impulse);
        }
    }

    void Die()
    {
        Instantiate(smokeParticle, gameObject.transform.position, Quaternion.identity);
        uiManager.updatelogsText();
        isBeingDestroyed = true;
        Destroy(gameObject);
    }

    public bool GetIsBeingDestroyed()
    {
        return isBeingDestroyed;
    }
}
