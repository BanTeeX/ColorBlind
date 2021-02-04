using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	private GameMaster gm;

	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			gm.lastCheckPointPos = transform.position;
		}
	}
}
