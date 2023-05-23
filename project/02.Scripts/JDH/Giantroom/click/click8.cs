using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class click8 : MonoBehaviour

{
	public string password;

	public void Clicky()
	{
		GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText += "8";
		GameObject.Find("NPCText3").GetComponent<Text>().text += "8";
	}


}
