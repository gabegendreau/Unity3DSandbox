using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioSource audioSource;
    public AudioClip coinCollect;
    public AudioClip tacoEat;
    public AudioClip getKey;
    public AudioClip gunShot;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void playCoinCollect()
    {
        audioSource.PlayOneShot(coinCollect);
    }

    public void playTacoEat()
    {
        audioSource.PlayOneShot(tacoEat);
    }

    public void playGetKey()
    {
        audioSource.PlayOneShot(getKey);
    }

    public void playGunShot()
    {
        audioSource.PlayOneShot(gunShot);
    }
}
