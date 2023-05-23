using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class click9 : MonoBehaviour

{
	public string password;

	public void Clicky()
	{
		GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText += "9";
		GameObject.Find("NPCText3").GetComponent<Text>().text += "9";
	}


}
