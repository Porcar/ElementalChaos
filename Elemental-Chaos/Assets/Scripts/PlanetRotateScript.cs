using UnityEngine;
using System.Collections;

public class PlanetRotateScript : MonoBehaviour
{
    public int speed = 1;

    public void Update()
    {
        transform.Rotate((Vector3) ((Vector3.up * Time.deltaTime) * speed));
    }
}

