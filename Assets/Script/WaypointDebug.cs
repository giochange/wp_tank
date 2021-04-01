using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaypointDebug : MonoBehaviour {

    //metodo que possui repetição perante comparação de tag que resulta na procura do objeto
	void RenameWPs(GameObject overlook)
	{
		GameObject[] gos;
	    gos = GameObject.FindGameObjectsWithTag("wp"); 
	    int i = 1;
	    foreach (GameObject go in gos)  
	    { 
	     	if(go != overlook)
	     	{
	     		go.name = "WP" + string.Format("{0:000}",i); 
	     		i++; 
	     	} 
	    }	
	}
    //chamada do metodo dentro do on destroy
	void OnDestroy()
	{
		RenameWPs(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		if(this.transform.parent.gameObject.name != "WayPoint")
            return;
		RenameWPs(null);
	}
	
	// Update is called once per frame
	void Update ()
    {
		this.GetComponent<TextMesh>().text = this.transform.parent.gameObject.name;
	}
}
