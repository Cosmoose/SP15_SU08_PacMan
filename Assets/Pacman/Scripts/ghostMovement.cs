using UnityEngine;
using System.Collections;

public class ghostMovement : MonoBehaviour {
	
	public GameObject ghost;
	public GameObject pacman;
	public bool spotted;
	public bool hunted;
	public Vector3 direction;
	public int moveSpeed;
	private float pacposx;
	private float pacposz;
	private float ghostposx;
	private float ghostposz;
	
	
	// Use this for initialization
	void Start () {
		
		direction = Vector3.forward;
		moveSpeed = 5;
		spotted = false;
		hunted = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(direction * moveSpeed * Time.deltaTime);

		// håller reda på positionen i alla lägen
		pacposx = pacman.transform.position.x;
		pacposz = pacman.transform.position.z;
		ghostposx = ghost.transform.position.x;
		ghostposz = ghost.transform.position.z;

		
	}
	
	
	
	void OnTriggerEnter (Collider coll)
	{
		float x;
		
		x = Random.value;
		
		//ser spöket inte pacman
		if (!spotted)
		{
			
			// när spöket möter en korsning
			if (coll.gameObject.tag == "fourWayTurn")
				
				if (x > 0.75)
			{
				direction = Vector3.forward;
			}
			
			else if (x > 0.5)
			{
				direction = Vector3.left;
			}
			else if (x > 0.25)
			{
				direction = Vector3.right;
			}
			else
			{
				direction = Vector3.back;
			}
			
			// när det finns ett val mellan två vägar
			if (coll.gameObject.tag == "twoWayTurnLB") // LD = Left Back
				if (x > 0.5)
			{
				direction = Vector3.left;
			}
			else
			{
				direction = Vector3.back;
			}
			if (coll.gameObject.tag == "twoWayTurnRB")
			{

				if (x > 0.5)
				{
					direction = Vector3.back;
				}
				else
				{
					direction = Vector3.right;
				}
			}
			if (coll.gameObject.tag == "twoWayTurnLF")
			{
				if (x > 0.5)
				{
					direction = Vector3.forward;
				}
				else
				{
					direction = Vector3.left;
				}
			}
			if (coll.gameObject.tag == "twoWayTurnRF")
			{
				if (x > 0.5)
				{
					direction = Vector3.right;
				}
				else
				{
					direction = Vector3.forward;
				}
			}
			
			// val mellan tre vägar
			if(coll.gameObject.tag == "threeWayTurnRFB") // RFB = Right Back Forward
			{
				if (x > 0.67)
				{
					direction = Vector3.back;
				}
				else if (x > 0.33)
				{
					direction = Vector3.forward;
				}
				else
				{
					direction = Vector3.right;
				}
			}
			if (coll.gameObject.tag == "threeWayTurnLFR")
			{
				if (x > 0.67)
				{
					direction = Vector3.right;
				}
				else if (x > 0.33)
				{
					direction = Vector3.forward;
				}
				else
				{
					direction = Vector3.left;
				}
			}
			if (coll.gameObject.tag == "threeWayTurnLFB")
			{
				if (x > 0.67)
				{
					direction = Vector3.left;
				}
				else if (x > 0.33)
				{
					direction = Vector3.forward;
				}
				else
				{
					direction = Vector3.back;
				}
			}
			if (coll.gameObject.tag == "threeWayTurnLBR")
			{
				if (x > 0.67)
				{
					direction = Vector3.back;
				}
				else if (x > 0.33)
				{
					direction = Vector3.right;
				}
				else
				{
					direction = Vector3.left;
				}
			}
		}
		
		
		
		
		
		
		// Ser spöket pacman
		if (spotted)
		{
			
			if (coll.gameObject.tag == "fourWayTurn")
			{
				if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
				{
					if (hunted)
					{
						direction = Vector3.left;
					}
					else
					direction = Vector3.right;

				}
				else if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
				{
					if (hunted)
					{
						direction = Vector3.right;
					}
					else
					direction = Vector3.left;
				}
				else if (pacposz > ghostposz)
				{

					if (hunted)
					{
						direction = Vector3.back;
					}
					else
					direction = Vector3.forward;
				}
				else 
				{
					if (hunted)
					{
						direction = Vector3.forward;
					}
					else
					direction = Vector3.back;
				}
			}
			
			
			
			
			
			//twoWayTurns
			if (coll.gameObject.tag == "twoWayTurnLB") // LB = Left Back
			{
				if (!hunted)
				{
					if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						
						direction = Vector3.left;
					}
					else
					{
						direction = Vector3.back;
					}
				}
				else // gör tvärt om för att röra sig närmare packman
				{
					if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						
						direction = Vector3.back;
					}
					else
					{
						direction = Vector3.left;
					}
				}
			}

			if (coll.gameObject.tag == "twoWayTurnRB")
			{
				if (!hunted)
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						
						direction = Vector3.right;
						
					}
					else
					{
						direction = Vector3.back;
					}
				}
				else
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						
						direction = Vector3.back;
						
					}
					else
					{
						direction = Vector3.right;
					}
				}
			}

			if (coll.gameObject.tag == "twoWayTurnLF")
			{
				if (!hunted)
				{
					if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.left;
					}
					else
					{
						direction = Vector3.forward;
						
					}
				}
				else
				{
					if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.forward;
					}
					else
					{
						direction = Vector3.left;
						
					}
				}
			}

			if (coll.gameObject.tag == "twoWayTurnRF")
			{
				if (!hunted)
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.right;
					}
					else
					{
						direction = Vector3.forward;
					}
				}
				else
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.forward;
					}
					else
					{
						direction = Vector3.right;
					}
				}
			}



			// threeWayTurns
			if (coll.gameObject.tag == "threeWayTurnLFB")
			{
				if (!hunted)
				{
					if (pacposz < ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.back;
					}
					else if (pacposz > ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.forward;
					}
					else 
					{
						direction = Vector3.left;
					}
				}
				else
				{
					if (pacposz < ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.left;
					}
					else if (pacposz > ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.back;
					}
					else 
					{
						direction = Vector3.forward;
					}
				}
			}

			if (coll.gameObject.tag == "threeWayTurnLRB")
			{
				if (!hunted)
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.right;
					}
					else if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.left;
					}
					else
					{
						direction = Vector3.back;
					}
				}
				else
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.back;
					}
					else if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.right;
					}
					else
					{
						direction = Vector3.left;
					}
				}
			}

			if (coll.gameObject.tag == "threeWayTurnRFB")
			{
				if (!hunted)
				{
					if (pacposz < ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.back;
					}
					else if (pacposz > ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.forward;
					}
					else
					{
						direction = Vector3.right;
					}
				}
				else
				{
					if (pacposz < ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.forward;
					}
					else if (pacposz > ghostposz && Mathf.Abs(pacposx - ghostposx) < Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.right;
					}
					else
					{
						direction = Vector3.back;
					}
				}
			}

			if (coll.gameObject.tag == "threeWayTurnRLF")
			{
				if (!hunted)
				{
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.right;
					}
					else if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
					{
						direction = Vector3.left;
					}
					else 
					{
						direction = Vector3.forward;
					}
				}
				else
					if (pacposx > ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
				{
					direction = Vector3.forward;
				}
				else if (pacposx < ghostposx && Mathf.Abs(pacposx - ghostposx) > Mathf.Abs(pacposz - ghostposz))
				{
					direction = Vector3.left;
				}
				else 
				{
					direction = Vector3.right;
				}
			}
		}
	}
}