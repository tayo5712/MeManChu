using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickok : MonoBehaviour

{
	public string password;

	public void Clicky()
	{
		password = GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText;

		if (password == "1225")
		{
			Destroy(GameObject.Find("quiz1box2"));
			Destroy(GameObject.Find("quiz1"));
			//Destroy(GameObject.Find("Keypad"));
			GameObject.Find("Keypad").SetActive(false);
			GameObject.Find("Bluekey").GetComponent<BoxCollider>().isTrigger = true;
			GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText = "";
			GameObject.Find("NPCText3").GetComponent<Text>().text = "";
		}
		else if (password == "1215")
		{
			Destroy(GameObject.Find("quiz2box"));
			Destroy(GameObject.Find("quiz2lock"));
			Destroy(GameObject.Find("Keypad"));
			GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText = "";
			GameObject.Find("NPCText3").GetComponent<Text>().text = "";
		}

		else if (password == "4086")
		{
			Destroy(GameObject.Find("quiz3box"));
			Destroy(GameObject.Find("dddoor"));
			GameObject.Find("Keypad").SetActive(false);
			GameObject.Find("quiz1box").GetComponent<Quiztrigger1>().ChatText = "";
			GameObject.Find("NPCText3").GetComponent<Text>().text = "";
		}

		else {
			GameObject.Find("NPCText3").GetComponent<Text>().text = "Æ²·È½À´Ï´Ù";
		}
	}


}
