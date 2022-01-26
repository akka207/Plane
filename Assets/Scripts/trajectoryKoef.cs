using UnityEngine;

public class trajectoryKoef : MonoBehaviour
{
    void Start()
    {
        Aim.trajectoryKoefPos = transform.position;
    }

    void Update()
    {
        transform.position = Aim.trajectoryKoefPos;
        Aim.trajectoryKoefRedAxis = transform.right;
    }
}
