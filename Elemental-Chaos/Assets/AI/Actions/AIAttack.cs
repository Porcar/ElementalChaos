using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class AIAttack : RAINAction{

public GameObject wizard;
public RaycastHit hit;
public Transform spell;
public string animAttack;
public float delay, reach, delayAnim;
float counterDelay;
public float damagePoints;
bool shootPrepared;
Vector3 direction;
	public GameObject yo;

    public AIAttack()
    {
        actionName = "AIAttack";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
		wizard = GameObject.FindGameObjectWithTag ("Shootme");
		yo = GameObject.FindGameObjectWithTag ("IShoot");
    }

    public override ActionResult Execute(AI ai)
    {

		direction =  wizard.transform.position - yo.transform.position;
		direction.Normalize ();
		Healt.currHealth -= damagePoints;
						
				
        return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}