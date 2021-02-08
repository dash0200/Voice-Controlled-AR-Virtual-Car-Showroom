using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

//Custom 8
public partial class Wit3D : MonoBehaviour
{

	public Text myHandleTextBox;
	private bool actionFound = false;



	void Handle(string jsonString)
	{

		if (jsonString != null)
		{

			RootObject theAction = new RootObject();
			Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, theAction);

			if (theAction.entities.Open != null)
			{
				foreach (Open aPart in theAction.entities.Open)
				{

					Debug.Log(aPart.value);
					if (theAction._text.Contains("open door") || theAction._text.Contains("open drivers door"))
					{
						carController.instance.triggerAnimation("openDriversDoor");
					}
					if (theAction._text.Contains("open engine") || theAction._text.Contains("open trunk"))
					{
						carController.instance.triggerAnimation("openEngine");
					}

					if (theAction._text.Contains("open bonnet") || theAction._text.Contains("open hood") || theAction._text.Contains("open bonet") || theAction._text.Contains("open barnet") || theAction._text.Contains("open good") || theAction._text.Contains("open hot") || theAction._text.Contains("open hulu") || theAction._text.Contains("open heart"))
					{
						carController.instance.triggerAnimation("openHood");
					}

					if (theAction._text.Contains("open windows"))
					{
						carController.instance.triggerAnimation("openWindows");
					}

					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}


			if (theAction.entities.Close != null)
			{
				foreach (Close aPart in theAction.entities.Close)
				{
					Debug.Log(aPart.value);
					if (theAction._text.Contains("close door") || theAction._text.Contains("close drivers door"))
					{
						carController.instance.triggerAnimation("closeDriversDoor");
					}
					if (theAction._text.Contains("close engine"))
					{
						carController.instance.triggerAnimation("closeEngine");
					}

					if (theAction._text.Contains("close bonnet") || theAction._text.Contains("close hood") || theAction._text.Contains("close bonet") || theAction._text.Contains("close barnet") || theAction._text.Contains("close good") || theAction._text.Contains("close hot") || theAction._text.Contains("close hulu") || theAction._text.Contains("close heart"))
					{
						carController.instance.triggerAnimation("closeHood");
					}
					if (theAction._text.Contains("close windows"))
					{
						carController.instance.triggerAnimation("closeWindows");
					}
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}



			if (theAction.entities.Start != null)
			{
				foreach (Start aPart in theAction.entities.Start)
				{
					Debug.Log(aPart.Value);
					if (theAction._text.Contains("start engine"))
					{
						carController.instance.playSound();
					}
					if (theAction._text.Contains("start video"))
					{
						carController.instance.playVideo();
					}

					myHandleTextBox.text = aPart.Value;
					actionFound = true;
				}
			}

			if (theAction.entities.Stop != null)
			{
				foreach (Stop aPart in theAction.entities.Stop)
				{
					Debug.Log(aPart.Value);
					if (theAction._text.Contains("stop engine"))
					{
						carController.instance.stopSound();
					}
					if (theAction._text.Contains("stop video"))
					{
						carController.instance.stopVideo();
					}
					myHandleTextBox.text = aPart.Value;
					actionFound = true;
				}
			}

			if (!actionFound)
			{
				myHandleTextBox.text = "Request unknown, please ask a different way.";
			}
			else
			{
				actionFound = false;
			}

		}//END OF IF

	}//END OF HANDLE VOID

}//END OF CLASS


//Custom 9
public class Open
{
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}


public class Close
{
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}




public class Start
{
	public bool Suggested { get; set; }
	public double Confidence { get; set; }
	public string Value { get; set; }
	public string Type { get; set; }
}

public class Stop
{
	public bool Suggested { get; set; }
	public double Confidence { get; set; }
	public string Value { get; set; }
	public string Type { get; set; }
}

public class Play
{
	public bool Suggested { get; set; }
	public double Confidence { get; set; }
	public string Value { get; set; }
	public string Type { get; set; }
}


public class Entities
{
	public List<Open> Open { get; set; }
	public List<Close> Close { get; set; }

	public List<Start> Start { get; set; }
	public List<Stop> Stop { get; set; }

	public List<Play> Play { get; set; }

}

public class RootObject
{
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}