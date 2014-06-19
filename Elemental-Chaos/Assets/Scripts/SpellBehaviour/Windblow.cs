using UnityEngine;
using System.Collections;

public class Windblow : MonoBehaviour {

	public static float magnitude = 10;
	public static void Cast(Vector3 pos,Vector3 forward){
		Collider[] colliders = Physics.OverlapSphere (pos, 3f);
		foreach (Collider c in colliders) {
			float angle = Vector3.Angle(forward,c.gameObject.transform.position-pos);
			if(angle<30){
				Vector3 direction = (c.gameObject.transform.position-pos).normalized;
				c.rigidbody.AddForce(direction*magnitude,ForceMode.Impulse);
			}
		}
	}
}
