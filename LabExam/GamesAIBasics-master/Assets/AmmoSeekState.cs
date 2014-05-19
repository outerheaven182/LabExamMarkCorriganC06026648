using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

class AmmoSeekState:State
{
   	GameObject AmmoGameObject;
	bool OutofAmmo = false;
	GameObject leader = GameObject.FindGameObjectWithTag("leader");

    public override string Description()
    {
        return "Seeking Ammo State";
    }

    public AmmoSeekState(GameObject myGameObject, GameObject AmmoGameObject):base(myGameObject)
    {
        this.AmmoGameObject = AmmoGameObject;
    }

    public override void Enter()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = true;
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursuitOffset = new Vector3(0, 0, 5);
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursueTarget = AmmoGameObject;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        float range = 10.0f;
        float fov = Mathf.PI / 4.0f;
        // Can I see the enemy?

        if (OutofAmmo == false)
        {
            myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, AmmoGameObject));
        }
        else
        {
            float angle;
            Vector3 toAmmo = (AmmoGameObject.transform.position - myGameObject.transform.position);
            toAmmo.Normalize();
            angle = (float) Math.Acos(Vector3.Dot(toAmmo, myGameObject.transform.forward));
            
			if (angle < fov)
            {
				if (AmmoGameObject.transform.position == myGameObject.transform.position)
                {
					leader.GetComponent<AmmoCount>().enabled = true;
					OutofAmmo = false;
                }
            }
        }
    }
}
