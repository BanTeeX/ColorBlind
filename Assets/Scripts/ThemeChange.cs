using System.Collections.Generic;
using UnityEngine;

public class ThemeChange : MonoBehaviour
{
	[SerializeField] private SpriteRenderer background = null;
	[SerializeField] private List<Sprite> backgroundSprites = null;
	[SerializeField] private Mode mode;

	public bool Blocked { get; set; }

	private GameObject[] Black { get; set; }
	private GameObject[] White { get; set; }

	public enum Mode
	{
		Dark,
		Light
	}

	private void Start()
	{
		Black = FindGameObjectsInLayer(LayerMask.NameToLayer("Black"));
		White = FindGameObjectsInLayer(LayerMask.NameToLayer("White"));
		ChangeTheme(mode);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !Blocked)
		{
			ChangeTheme(mode == Mode.Dark ? Mode.Light : Mode.Dark);
		}
	}

	private void FixedUpdate()
	{
		Blocked = false;
	}

	private void ChangeTheme(Mode mode)
	{
		this.mode = mode;
		background.sprite = backgroundSprites[(int)mode];
		foreach (GameObject gameObject in mode == Mode.Dark ? Black : White)
		{
			gameObject.GetComponent<Block>().ChangeActive(true);
		}
		foreach (GameObject gameObject in mode == Mode.Dark ? White : Black)
		{
			gameObject.GetComponent<Block>().ChangeActive(false);
		}
	}

	private GameObject[] FindGameObjectsInLayer(int layer)
	{
		GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
		List<GameObject> gameObjects = new List<GameObject>();
		foreach (GameObject gameObject in objects)
		{
			if (gameObject.layer == layer)
			{
				gameObjects.Add(gameObject);
			}
		}
		if (gameObjects.Count == 0)
		{
			return null;
		}
		return gameObjects.ToArray();
	}
}
