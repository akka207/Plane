using UnityEngine;

public class Aim : MonoBehaviour
{
    public static Vector3 planePos;
    public static float planeSpeed;
    public static Vector3 canonPos;
    public static float bulletSpeed;

    public static Vector3 trajectoryKoefPos;
    public static Vector3 trajectoryKoefRedAxis;

    public static Vector3 BulletTrajectoryPos;
    public static float BulletTrajectoryRotation;
    public static Vector3 BulletTrajectoryGreenAxis;

    void Update()
    {
        BulletTrajectoryPos = canonPos;
        Vector2 direction;
        float i = 0.01f;
        float newDistance = 0;
        float lastDistance = searchDistance(BulletTrajectoryPos, trajectoryKoefPos);
        while(true)
        {
            trajectoryKoefPos = planePos;
            BulletTrajectoryPos = canonPos;
            trajectoryKoefPos -= i * planeSpeed * trajectoryKoefRedAxis;
            direction = trajectoryKoefPos - BulletTrajectoryPos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            BulletTrajectoryRotation = angle-90;
            BulletTrajectoryPos += BulletTrajectoryGreenAxis * i * bulletSpeed;

            newDistance = searchDistance(BulletTrajectoryPos, trajectoryKoefPos);
            i += 0.01f;
            if(newDistance < lastDistance)
            {
                lastDistance = newDistance;
                continue;
            }
            else
            {
                break;
            }
        }
        transform.position = trajectoryKoefPos;
        trajectoryKoefPos = planePos;
        BulletTrajectoryPos = canonPos;
    }

    public static float searchDistance(Vector3 a, Vector3 b)
    {
        float x = Mathf.Abs(b.x-a.x);
        float y = Mathf.Abs(b.y-a.y);
        float c = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
        return c;
    }
}
