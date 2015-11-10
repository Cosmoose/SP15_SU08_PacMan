using UnityEngine;
using System.Collections;

public class PathChecker : MonoBehaviour {


	public leftCheck leftCheck;
	public rightCheck rightCheck;
	public frontCheck frontCheck;
	public backCheck backCheck;

	// Use this for initialization
	void Start () 
	{

		Invoke ("TagThisObject", 0.1f);
	
	}
	
	// Update is called once per frame
	void Update () 
	{


	}


	void TagThisObject ()
	{
		Debug.Log (frontCheck.front);
		Debug.Log (backCheck.back);
		Debug.Log (leftCheck.left);
		Debug.Log (rightCheck.right);
		
		if (leftCheck.left && backCheck.back)
		{
			gameObject.tag = "twoWayTurnRF";
		}
		else if (leftCheck.left && frontCheck.front)
		{
			gameObject.tag = "twoWayTurnRB";
		}
		else if (rightCheck.right && frontCheck.front)
		{
			gameObject.tag = "twoWayTurnLB";
		}
		else if (rightCheck.right && backCheck.back)
		{
			gameObject.tag = "twoWayTurnLF";
		}
		else if (backCheck.back)
		{
			gameObject.tag = "threeWayTurnLFR";
		}
		else if (frontCheck.front)
		{
			gameObject.tag = "threeWayTurnLBR";
		}
		else if (leftCheck.left)
		{
			gameObject.tag = "threeWayTurnRFB";
		}
		else if (rightCheck.right)
		{
			gameObject.tag = "threeWayTurnLFB";
		}
		else 
		{
			gameObject.tag = "fourWayTurn";
		}
	}
}
