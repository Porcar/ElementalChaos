using UnityEngine;
using System.Collections;

public class BillboardScript : MonoBehaviour
{

    public void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(Vector3.left * -90);
    }
}

