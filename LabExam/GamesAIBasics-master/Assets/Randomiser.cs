using UnityEngine;
using System.Collections;

public class Randomiser : MonoBehaviour
{
	public GameObject gameObject = null;

	void Start ()
	{
		
		for(int i = 1; i <=10; i++)
		{
			Vector3 position = new Vector3(Random.Range(-100,100), Random.Range(-100,100), Random.Range(-100,100));
			gameObject = Instantiate(Resources.Load("Prefabs/Ammo"), position, Quaternion.identity) as GameObject;
		}
	}

	void Update ()
	{

	}
}

