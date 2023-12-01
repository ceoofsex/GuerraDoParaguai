using Photon.Pun;
using Photon.Pun.UtilityScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Image ammoCircle;
    public int damege;

    public Camera camera;

    public float fireRate;

    [Header("VFX")]
    public GameObject hitVFX;

    private float nextFire;

    [Header("Ammo")]
    public int mag = 5;

    public int ammo = 30;
    public int magAmmo = 30;

    [Header("UI")]
    public TextMeshProUGUI magText;
    public TextMeshProUGUI ammoText;

    [Header("Animation")]
    public Animation animation;
    public AnimationClip reload;

    [Header("Recoil Settings")]
    //[Range(0,1)]
    //public float recoilPercent = 0.3f;

    [Range(0, 2)]
    public float recoverPercent = 0.7f;

    [Space]
    public float recoilUp = 1f;
    public float recoilBack = 0f;


    private Vector3 originalPosition;
    private Vector3 recoilVelocity = Vector3.zero;

    private float recoilLength;
    private float recoverLength;


    private bool recoiling;
    private bool recovering;

    void SetAmmo()
    {
        ammoCircle.fillAmount = (float)ammo / magAmmo;
    }



    void Start()
    {
        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;

        SetAmmo();

        originalPosition = transform.localPosition;

        recoilLength = 0;
        recoverLength = 1 / fireRate * recoverPercent;

    }

    // Update is called once per frame
    async void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire1") && nextFire <= 0 && ammo > 0 && animation.isPlaying == false)
        {
            nextFire = 1 / fireRate;

            ammo--;

            magText.text = mag.ToString();
            ammoText.text = ammo + "/" + magAmmo;

            SetAmmo();

            Fire();
            //await Task.Delay(1000);
        }

        if (Input.GetKeyDown(KeyCode.R) && mag > 0)
        {
            Reload();
        }

        if (recoiling)
        {
            Recoil();
        }
        if (recovering)
        {
            Recovering();
        }
    }


    void Reload()
    {
        animation.Play(reload.name);
        if (mag > 0)
        {
            mag--;

            ammo = magAmmo;
        }

        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
        SetAmmo();
    }

    void Fire()
    {

        recoiling = true;
        recovering = false;

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        RaycastHit hit;

        PhotonNetwork.LocalPlayer.AddScore(1);


        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {
            PhotonNetwork.Instantiate(hitVFX.name, hit.point, Quaternion.identity);
            Debug.Log("Efeito");

            if (hit.transform.gameObject.CompareTag("TNT"))
            {
                Debug.LogError("colidindo tnt");
                Tnt boom = hit.transform.gameObject.GetComponentInParent<Tnt>();
                Debug.LogError(boom);
                boom.TakeDamage(damege);
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.AllBufferedViaServer, damege);
            }
            if (hit.transform.gameObject.GetComponent<Health>())
            {
                PhotonNetwork.LocalPlayer.AddScore(damege);

                if (damege >= hit.transform.gameObject.GetComponent<Health>().health)
                {

                    RoomManager.instance.kills++;
                    RoomManager.instance.SetHashes();

                    PhotonNetwork.LocalPlayer.AddScore(100);

                }

                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamege", RpcTarget.AllBufferedViaServer, damege);
            }




        }
    }

    void Recoil()
    {
        Vector3 finalPosition = new Vector3(originalPosition.x, originalPosition.y + recoilUp, originalPosition.z - recoilBack);


        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, finalPosition, ref recoilVelocity, recoilLength);

        if (transform.localPosition == finalPosition)
        {
            recoiling = false;
            recovering = true;
        }
    }

    void Recovering()
    {
        Vector3 finalPosition = originalPosition;


        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, finalPosition, ref recoilVelocity, recoverLength);

        if (transform.localPosition == finalPosition)
        {
            recoiling = true;
            recovering = false;
        }
    }
}
