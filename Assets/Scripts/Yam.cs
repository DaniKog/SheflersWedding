using UnityEngine;
using System.Collections;

public class Yam : MonoBehaviour {

	float timeTobeOut = 5;
	float timer;
	SpriteRenderer myrender;
	public bool visable = true;
	// Use this for initialization
	void Start () 
	{
		myrender = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (visable == true)
		{
			timer += Time.deltaTime;
			if(timer > timeTobeOut)
			{
				myrender.color = new Color(255,255,255,0);
				visable = false;
			}
		}
	}
	void OnMouseDown()
	{
		visable = true;
		myrender.color = new Color(255,255,255,255);
		timer = 0;
		timeTobeOut = Random.Range (1, 5);
	}
}
