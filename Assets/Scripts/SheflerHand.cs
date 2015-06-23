using UnityEngine;
using System.Collections;

public class SheflerHand : MonoBehaviour
{
	GameObject currentStopSign;
	StopSign currentStopSignScript;
	public Sprite grabbingHandSprite;
	public Sprite scrathingHandSprite;
	SpriteRenderer mySpriteRend;
	// Use this for initialization
	void Start ()
	{
		mySpriteRend = gameObject.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(gameObject.tag == "Shefler")
		{
			if(col.gameObject.tag == "StopSign")
			{
				currentStopSign = col.gameObject;
				currentStopSignScript = currentStopSign.GetComponent<StopSign>();
				Shefler.Instance.StopSignEnter(currentStopSignScript);
				mySpriteRend.sprite = grabbingHandSprite;
			}
		}
	}
	public void ResetSprite()
	{
		mySpriteRend.sprite = scrathingHandSprite;
	}
}
