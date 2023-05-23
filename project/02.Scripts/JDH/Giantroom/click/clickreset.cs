using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickreset : MonoBehaviour

{
	public string password;

	public void Clicky()
	{
		GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText = "";
		GameObject.Find("NPCText3").GetComponent<Text>().text = "";
	}


}
