using UnityEngine;

public class BulletTrajectoryKoef : MonoBehaviour
{
    void Update()
    {
        transform.position = Aim.BulletTrajectoryPos;
        transform.eulerAngles = new Vector3 (0, 0, Aim.BulletTrajectoryRotation);
        Aim.BulletTrajectoryGreenAxis = transform.up;
    }
}
