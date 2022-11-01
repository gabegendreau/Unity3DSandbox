using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;
    [SerializeField] float fireRate;
    bool canFire = true;
    float thresholdTime;
    [SerializeField] GameObject bulletHole;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float bulletHolePositionOffset;
    Camera mainCam;

    SoundManager soundManager;

    void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main; 
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (thresholdTime < Time.time) {
            canFire = true;
            thresholdTime = Time.time + fireRate;
        } else {
            canFire = false;
        }

        if(Input.GetMouseButton(0) && canFire) {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        HandleRaycast();
        HandleMuzzleFlash();
        soundManager.playGunShot();
    }

    private void HandleRaycast()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit hit, weaponRange, hittableLayer))
        {
            Debug.DrawLine(mainCam.transform.position, hit.point, Color.red, 4.5f);
            if (hit.collider.gameObject.tag == "AngryLog")
            {
                LogDamage shotLog = hit.collider.gameObject.GetComponent<LogDamage>();
                if (shotLog)
                {
                    if (!shotLog.GetIsBeingDestroyed())
                    {
                        Vector3 hitDirection = hit.normal * -1.0f;
                        shotLog.GetShot(hitDirection);
                    }
                }
            } else {
                Instantiate(bulletHole, hit.point + (hit.normal * bulletHolePositionOffset), Quaternion.LookRotation(hit.normal));
            }    
        }
    }

    private void HandleMuzzleFlash()
    {
        if (muzzleFlash.isPlaying)
            muzzleFlash.Stop();
        muzzleFlash.Play();
    }
}
