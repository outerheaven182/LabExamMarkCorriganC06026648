using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

class HealthSeekState:State
{
   	GameObject HealthGameObject;
	bool LowHealth = true;
	GameObject teaser = GameObject.FindGameObjectWithTag("teaser");

    public override string Description()
    {
        return "Seeking Health State";
    }

    public HealthSeekState(GameObject myGameObject, GameObject HealthGameObject):base(myGameObject)
    {
        this.HealthGameObject = HealthGameObject;
    }

    public override void Enter()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = true;
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursuitOffset = new Vector3(0, 0, 5);
        myGameObject.GetComponent<SteeringBehaviours>().offsetPursueTarget = HealthGameObject;
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        float range = 10.0f;
        float fov = Mathf.PI / 4.0f;
        // Can I see the enemy?

        if (LowHealth == false)
        {
            myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, HealthGameObject));
        }
        else
        {
            float angle;
            Vector3 toHealth = (HealthGameObject.transform.position - myGameObject.transform.position);
            toHealth.Normalize();
            angle = (float) Math.Acos(Vector3.Dot(toHealth, myGameObject.transform.forward));
            
			if (angle < fov)
            {
				if (HealthGameObject.transform.position == myGameObject.transform.position)
                {
					teaser.GetComponent<FullHealth>().enabled = true;
					LowHealth = false;
                }
            }
        }
    }
}
