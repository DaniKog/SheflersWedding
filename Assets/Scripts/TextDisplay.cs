using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{

	public Text clksToClick;
	public Text clksClicked;
	Shefler shefler_Script;
	// Use this for initialization
	void Start ()
	{
		shefler_Script = gameObject.GetComponent < Shefler> ();
	}
	

	public void UpdateText()
	{
		clksToClick.text = ("Clicks To Click: " + shefler_Script.numberOfClksNeeded.ToString ());
		clksClicked.text = ("Clicks Clicked: " + shefler_Script.numberOfClks.ToString());
	}

	public void ResetText()
	{
		clksToClick.text = ("Clicks To Click: 0");
		clksClicked.text = ("Clicks Clicked: 0");
	}
}
