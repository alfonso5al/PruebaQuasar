using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{

    public GameObject textName;
    private NetworkManager networkmanager = null;

    private void Awake() 
    {
        networkmanager = GameObject.FindObjectOfType<NetworkManager>();
        networkmanager.GetUser(PlayerPrefs.GetString("email"), delegate(Response response)
        {
            textName.GetComponent<TextMesh>().text = response.message;
        }); 
    }


    // Update is called once per frame
    void Update()
    {
        if(textName != null)
        {
            textName.transform.LookAt(Camera.main.transform.position);
            textName.transform.Rotate(0,180,0);

        }
    }
}
