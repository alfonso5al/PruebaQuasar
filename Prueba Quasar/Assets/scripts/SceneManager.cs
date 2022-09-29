using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField email_login = null;
    [SerializeField] private InputField password_login = null;

    [Header("Login")]    
    [SerializeField] private InputField userNameInput = null;
    [SerializeField] private InputField emailInput = null;
    [SerializeField] private Text m_text = null;
    [SerializeField] private InputField password = null;
    [SerializeField] private InputField reEnterPassword = null;

    [SerializeField] private GameObject registerUI = null;
    [SerializeField] private GameObject loginUI = null;

    private NetworkManager networkmanager = null;
    private GameObject registerButton;

    private void Awake() 
    {
        networkmanager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitLogin()
    {
        if ((email_login.text == "") || (password_login.text == ""))
        {
            m_text.text = "Por favor llena todos los campos";
            return;
        }

        m_text.text = "Procesando...";

        networkmanager.CheckUser(email_login.text, password_login.text, delegate(Response response)
        {
            m_text.text = response.message;
            PlayerPrefs.SetString("email", email_login.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene("game");
        }); 

    }

    public void SubmitRegister()
    {
        if((userNameInput.text == "") || (emailInput.text == "") || (password.text == "") || (reEnterPassword.text == ""))
        {
            m_text.text = "Por favor completa todos los campos";
            return;
        }

        if(password.text == reEnterPassword.text)
        {
            m_text.text = "Procesando...";

            networkmanager.CreateUser(userNameInput.text, emailInput.text, password.text, delegate(Response response)
            {
                m_text.text = response.message;
                ShowLogin();
            });
        }
        else
        {
            m_text.text = "Contraseñas no coinciden";
        }
    }

    public void ShowLogin()
    {
        registerUI.SetActive(false);
        loginUI.SetActive(true);
        registerButton = loginUI.transform.GetChild(5).gameObject;
        registerButton.SetActive(false);
    }

    public void ShowRegister()
    {
        registerUI.SetActive(true);
        loginUI.SetActive(false);
    }
}
