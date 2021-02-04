using UnityEngine;

public class PlayerPos : MonoBehaviour
{
	private GameMaster gm;

	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
	}
   
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform"))
		{
			transform.parent = collision.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform"))
		{
			transform.parent = null;
		}
	}
}
