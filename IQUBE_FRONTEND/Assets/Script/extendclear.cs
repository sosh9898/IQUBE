using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class extendclear : MonoBehaviour
{
	public GameObject clearUI;

	void Start()
	{

		}
	void Update()
	{

	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		clearUI.SetActive(true);
}
}

