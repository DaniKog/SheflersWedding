using UnityEngine;
using System.Collections;

public class StopSign : MonoBehaviour
{
	public Sprite brokenSprite;
	SpriteRenderer mysprite;
	BoxCollider2D myCol;

	// Use this for initialization
	void Start ()
	{
		mysprite = gameObject.GetComponent<SpriteRenderer> ();
		myCol = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Shefler")
		{
			//Shefler entered Trigger.
		}
	}
	public void DestroyMe()
	{
		myCol.enabled = false;
		mysprite.sprite = brokenSprite;
		print (gameObject.name);
	}
}
