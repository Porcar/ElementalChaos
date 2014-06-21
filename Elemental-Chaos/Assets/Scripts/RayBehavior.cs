using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

public class RayBehavior : MonoBehaviour
{

    public float AlphaCurve;
    private Animation Anim;
    public Color BeginColor = Color.white;
    public GameObject BeginLocation;
    private bool changed = true;
    public Color EndColor = Color.white;
    public GameObject EndLocation;
    public float FadeSpeed = 1f;
    private LineRenderer Line;
    private Vector3 Offset;
    public Vector3 PositionRange;
    public float RadiusA = 1f;
    public float RadiusB = 1f;
    public float WidthA = 1f;
    public float WidthB = 1f;


    public void ResetRay()
    {
        Offset = new Vector3(Random.Range(-PositionRange.x, PositionRange.x), Random.Range(-PositionRange.y, PositionRange.y), Random.Range(-PositionRange.z, PositionRange.z));
        changed = true;
    }

    private void Start()
    {
        Line = GetComponent<LineRenderer>();
        Anim = GetComponent<Animation>();
        Anim["RayAlphaCurve"].speed = FadeSpeed;
    }

    private void Update()
    {
        if (changed)
        {
            changed = false;
            UpdateLineData();
        }
        Line.SetColors(new Color(BeginColor.r, BeginColor.g, BeginColor.b, AlphaCurve), new Color(EndColor.r, EndColor.g, EndColor.b, AlphaCurve));
    }

    public void UpdateLineData()
    {
        Line.SetPosition(0, BeginLocation.transform.position + ((Vector3) (Offset * RadiusA)));
        Line.SetPosition(1, EndLocation.transform.position + ((Vector3) (Offset * RadiusB)));
        Line.SetWidth(WidthA, WidthB);
    }
}

 

