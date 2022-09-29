using System;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(userName, email, pass, response));
    }

    private IEnumerator CO_CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("email", email);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost/QuasarPrueba/createUser.php", form);

        yield return w;

        response(JsonUtility.FromJson<Response>(w.text));
    }

    public void CheckUser(string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CheckUser(email, pass, response));
    }

    private IEnumerator CO_CheckUser(string email, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost/QuasarPrueba/checkUser.php", form);

        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));
    }  

    public void GetUser(string email, Action<Response> response)
    {
        StartCoroutine(CO_GetUser(email, response));
    }  

    private IEnumerator CO_GetUser(string email, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);

        WWW w = new WWW("http://localhost/QuasarPrueba/getUser.php", form);

        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));
    }    
 
}

[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}
