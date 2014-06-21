using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class PlanetMouseOrbit : MonoBehaviour
{
	public Transform target;
    public float distance = 10f;
    private float x;
    private float y;
    public int yMaxLimit = 80;
    public int yMinLimit = -20;
	public float xSpeed = 250f;
    public float ySpeed = 120f;
    public int zoomRate = 0x19;

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    public void Main()
    {
    }

    public void Start()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        x = eulerAngles.y;
        y = eulerAngles.x;
    }

    public void Update()
    {
        if (target != null)
        {
            x += (Input.GetAxis("Mouse X") * xSpeed) * 0.02f;
            y -= (Input.GetAxis("Mouse Y") * ySpeed) * 0.02f;
            distance += (-(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate) * Mathf.Abs(distance);
            y = ClampAngle(y, (float) yMinLimit, (float) yMaxLimit);
            Quaternion quaternion = Quaternion.Euler(y, x, (float) 0);
            Vector3 vector = ((Vector3) (quaternion * new Vector3((float) 0, (float) 0, -distance))) + target.position;
            transform.rotation = quaternion;
            transform.position = vector;
        }
    }
}

 
