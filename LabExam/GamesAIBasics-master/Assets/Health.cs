using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	int	health = 10;

		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void OnTriggerEnter(Collider theEnterer )
		{
			if( theEnterer.tag == "Lazer")
			{
				if(health >=1)
				{
					health = health - 1;

						if(health <= 0)
						{
							Destroy(this.gameObject);
						}
				}
			}
			
		}
}

