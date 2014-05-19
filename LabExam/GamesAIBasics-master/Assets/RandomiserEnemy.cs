using UnityEngine;
using System.Collections;

public class RandomiserEnemy : MonoBehaviour
{
	public GameObject gameObject = null;

	void Start ()
	{
		
		for(int i = 1; i <=5; i++)
		{
			Vector3 position = new Vector3(Random.Range(-20,20), Random.Range(-20,20), Random.Range(-20,20));
			gameObject = Instantiate(Resources.Load("Prefabs/Enemy"), position, Quaternion.identity) as GameObject;
		}
	}

	void Update ()
	{

	}
}

