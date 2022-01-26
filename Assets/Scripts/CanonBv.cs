using UnityEngine;
using System.Collections;

public class CanonBv : MonoBehaviour
{
    public GameObject plane;
    public GameObject aim;
    public GameObject bullet;
    public static bool doCreate = false;
    public static float bulletSpeed = 0.8f;
    public static float bulletSpeedToUI = 0.8f;
    public static float shotFault = 0f;
    public static float shotDensity = 0.1f;
    public static float queue = 3f;
    float time = 1f;
    bool flag = true;

    void Start()
    {
        CreatePlane();
    }

    void Update()
    {
        bulletSpeed = bulletSpeedToUI;

        Aim.canonPos = transform.position;
        Aim.bulletSpeed = bulletSpeed;
        
        float fault = Random.Range(-shotFault, shotFault);

        Vector2 direction = aim.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,-angle+fault);

        if(doCreate)
        {
            CreatePlane();
        }
    }

    public void CreatePlane()
    {
        Instantiate(plane);
        doCreate = false;
    }

    public void Fire()
    {
        if(flag)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine(Wait(time));
            flag=false;
        }
    }

    public void FireWithQueue()
    {
        if(flag)
        {
            StartCoroutine(WaitAndShot(shotDensity));
            flag=false;
        }
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        flag = true;
    }

    private IEnumerator WaitAndShot(float waitTime)
    {
        byte i = 0;
        while(i<queue)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(bullet, transform.position, transform.rotation);
            i++;
        }
        flag = true;
    }
}
