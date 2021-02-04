using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	[SerializeField] private List<GameObject> Objects = new List<GameObject>();

	private void Start()
	{
		foreach (GameObject item in Objects)
		{
			item.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			foreach (GameObject point in Objects)
			{
				point.SetActive(true);
				Destroy(gameObject);
			}
		}
	}
}
