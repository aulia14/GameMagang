﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelector : MonoBehaviour {

	private GameObject[] characterList;
	private int index;

	private void Start() {
		PlayerPrefs.GetInt("CharacterSelected");
		characterList = new GameObject[transform.childCount];
		for(int i=0;i<transform.childCount;i++)
			characterList[i] = transform.GetChild(i).gameObject;
		foreach (GameObject t in characterList) t.SetActive(false);
		if(characterList[0]) characterList[0].SetActive(true);
	}

	public void ToggleLeft()
	{
		characterList[index].SetActive(false);
		index--;
		if(index<0) index = characterList.Length-1;
		characterList[index].SetActive(true);
	}
	public void ToggleRight()
	{
		characterList[index].SetActive(false);
		index++;
		if(index==characterList.Length) index = 0;
		characterList[index].SetActive(true);
	}
	public void Pilih()
	{
		PlayerPrefs.SetInt("CharacterSelected",index);
	}
	
}
