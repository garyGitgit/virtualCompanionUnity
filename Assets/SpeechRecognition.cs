using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows.Speech;
//using System.Linq;

public class SpeechRecognition : MonoBehaviour {
	public TextMesh textmesh;


	void Awake() {
		PluginManager.Getinstance();
	}
	void Start () {
		PluginManager.Getinstance().setcallbackSTTresult(new delegateSTTresult(STTresult));
		PluginManager.Getinstance().setcallbackMSG(new delegateMSG(androidMSG));
		print ("speech recognizer : start");
	}
	void STTresult(string result) {
		makelog(result);
	}
	void androidMSG(string msg) {
		makelog("LOG : " + msg);
	}
	void makelog(string logmsg){
		print (logmsg);
		textmesh.text = logmsg;
	}

	public void Call_STTstart() {
		print ("speech recognizer : call_sttstart");
		PluginManager.Getinstance().call_androidSTT("en-US");
	}

}