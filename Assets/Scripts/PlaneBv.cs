using UnityEngine;

public class PlaneBv : MonoBehaviour
{
    Vector2 startPos;
    public static float speed;
    public static float speedToUI;
    public static bool useRandomSpeed = true;
    public static int xPos;
    public static int[,] trajectory;
    Vector3 flyTo;
    int trIndex = 0;
    public GameObject explode;
    

    void Start()
    {
        xPos = Random.Range(0,2)==0?-1:1;
        SetTrajectory();
        flyTo = new Vector3(trajectory[0, 0], trajectory[0, 1], 0);
        if(xPos == 1)
        {
            trIndex = trajectory.Length/2-1;
        }
        ChangePosition();
        speed = Random.Range(0.1f, 0.4f);
    }

    void Update()
    {
        if(!useRandomSpeed)
        {
            speed = speedToUI;
        }

        Move();
        Aim.planeSpeed = speed;
        Aim.planePos = transform.position;
        
        Vector2 direction = flyTo - transform.position;
        float angle = xPos==-1
                    ?Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg
                    :Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(xPos < 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,180,angle-90);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,0,angle+180);
        }
        if(transform.position.y>6)
        {
            DestroyAndCreateNew();
        }
    }

    void Move()
    {
        Vector3 moreRandomize = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0) ;

        transform.position = Vector2.MoveTowards(transform.position, flyTo, speed * Time.deltaTime);
        
        if (transform.position.x == flyTo.x)
        {
            trIndex -= xPos;
        }
        if(trIndex < 0 || trIndex > trajectory.Length/2-1)
        {
            DestroyAndCreateNew();
        }
        flyTo = new Vector3(trajectory[trIndex, 0], trajectory[trIndex, 1], 0);
    }

    public void ChangePosition()
    {
        startPos = new Vector2(trajectory[trIndex, 0], trajectory[trIndex, 1]);
        transform.position = startPos;
    }

    void SetTrajectory()
    {
        byte num = (byte)Random.Range(0, 4);
        byte moreRnd = (byte)Random.Range(-1, 4);
        switch(num)
        {
            case 0:
            trajectory = new int[,] {{-10,moreRnd},{-3,1},{3,1},{10,moreRnd}};
            break;

            case 1:
            trajectory = new int[,] {{-10,moreRnd},{10,moreRnd}};
            break;

            case 2:
            trajectory = new int[,] {{-10,moreRnd},{1,-1},{10,moreRnd}};
            break;

            case 3:
            trajectory = new int[,] {{-10,moreRnd},{-2,-1},{4,3},{10,moreRnd}};
            break;
        }
    }

    void DestroyAndCreateNew()
    {
        CanonBv.doCreate = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            Instantiate(explode, transform.position, transform.rotation);
            DestroyAndCreateNew();
            Destroy(col.gameObject);
        }
    }
}
