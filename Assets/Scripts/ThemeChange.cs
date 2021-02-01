using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ThemeChange : MonoBehaviour
{
	public Mode mode;

	[SerializeField] private SpriteRenderer background = null;
	[SerializeField] private List<Sprite> backgroundSprites = null;
	[SerializeField] private List<AudioClip> audioClips = null;

	public bool Blocked { get; set; }

	private GameObject[] Black { get; set; }
	private GameObject[] White { get; set; }
	private AudioSource Audio { get; set; }

	public enum Mode
	{
		Dark,
		Light
	}

	private void Awake()
	{
		Audio = GetComponent<AudioSource>();
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
		Audio.clip = audioClips[(int)mode];
		Audio.Play();
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

	private GameObject[] FindGameObjectsInLayer(int layer) =>
		FindObjectsOfType<GameObject>().ToList().
		Where(gameObject => gameObject.layer == layer).ToArray();
}
