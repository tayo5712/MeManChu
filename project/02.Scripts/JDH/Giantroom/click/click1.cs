using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class click1 : MonoBehaviour

{
	public string password;

	public void Clicky()
	{
		GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText += "1";
		GameObject.Find("NPCText3").GetComponent<Text>().text += "1";
	}


}
