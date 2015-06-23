using UnityEngine;
using System.Collections;

public class Shefler : Singleton<Shefler>
{
	[System.NonSerialized]
	public int numberOfClks = 0;
	[System.NonSerialized]
	public int numberOfClksNeeded = 0;

	public Rigidbody2D shef_Rigid;
	bool swiping;
	Vector3 firstPosition;
	public float shef_Speed = -1;
	public bool canMove = true;

	StopSign currentStopSignScript;
	TextDisplay uiText;
	public float teleportDistance = 1;

	public SheflerHand sheflerhand;
	public ScreenShaker screenshake;

	// Use this for initialization
	void Start ()
	{
		shef_Rigid = gameObject.GetComponent<Rigidbody2D> ();
		uiText = gameObject.GetComponent<TextDisplay> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(canMove == true)
		{
			if (Input.GetMouseButton(0))
				{
					if (swiping == false)
				{
					swiping = true;
					firstPosition = Input.mousePosition;
					return;
				}
				else
				{
					Vector3 direction = Input.mousePosition - firstPosition;
					if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
					{
						if (direction.x > 0) 
						{
							
						}
						else
						{
							MoveLeft();
						}
					}
				}
				swiping = false;
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				numberOfClks++;
				uiText.UpdateText();
				if(numberOfClks == numberOfClksNeeded)
				{
					DestroySign();
					numberOfClks = 0;
					sheflerhand.ResetSprite();
					screenshake.Shake(0.2f,0.1f);
				}
			}
		}
	}
	void MoveLeft()
	{
		shef_Rigid.velocity += new Vector2(shef_Speed*Time.deltaTime,0);
	}


	void OnTriggerEnter2D(Collider2D col)
	{
			if(col.gameObject.tag == "Yam")
			{
				Yam yamscript = col.gameObject.GetComponent<Yam>();
				if(yamscript.visable == false)
				{
					print ("GameOver");
				}
			else if(yamscript.visable == true)
				{
					print ("YouMadeIt");
				}
				
			}
	}

	void DestroySign()
	{
		currentStopSignScript.DestroyMe();
		uiText.ResetText();
		canMove = true;
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - teleportDistance, gameObject.transform.position.y, gameObject.transform.position.z);
	}
	public void StopSignEnter(StopSign signScript)
	{
		canMove = false;
		shef_Rigid.velocity = Vector2.zero;
		numberOfClksNeeded  = Random.Range (1,5);
		currentStopSignScript = signScript;
		uiText.UpdateText();
	}
}
