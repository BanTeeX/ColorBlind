using System.Collections.Generic;
using UnityEngine;

public class ThemeChange : MonoBehaviour
{
    public SpriteRenderer background;
    public List<Sprite> backgroundSprites;
    public Mode mode;

    public GameObject[] Black { get; set; }
    public GameObject[] White { get; set; }

    public enum Mode
	{
        Dark,
        Light,
        Neutral
	}

	private void Start()
    {
        Black = FindGameObjectsInLayer(LayerMask.NameToLayer("Black"));
        White = FindGameObjectsInLayer(LayerMask.NameToLayer("White"));
		ChangeTheme(Mode.Dark);
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ChangeTheme(mode == Mode.Dark ? Mode.Light : Mode.Dark);
		}
	}

	private void ChangeTheme(Mode mode)
	{
		this.mode = mode;
		background.sprite = backgroundSprites[(int)mode];
		foreach (GameObject gameObject in mode == Mode.Dark ? White : Black)
		{
			gameObject.SetActive(true);
		}
		foreach (GameObject gameObject in mode == Mode.Dark ? Black : White)
		{
			gameObject.SetActive(false);
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
