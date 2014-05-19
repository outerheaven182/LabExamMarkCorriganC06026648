using UnityEngine;
using System.Collections;

public class RandomiserAmmo : MonoBehaviour
{
	public GameObject gameObject = null;

	void Start ()
	{
		
		for(int i = 1; i <=10; i++)
		{
			Vector3 position = new Vector3(Random.Range(-20,20), Random.Range(-20,20), Random.Range(-20,20));
			gameObject = Instantiate(Resources.Load("Prefabs/Ammo"), position, Quaternion.identity) as GameObject;
		}
	}

	void Update ()
	{

	}
}

