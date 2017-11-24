using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExhibesController : MonoBehaviour
{
    enum Page { Main, AR, VR, AddImage, Null };

    private static ExhibesController _instance; // !!!!! \\
    private Page page;
[SerializeField] private bool IsAssigned;
    private Color colorVisibleBackground = new Color(0.726f, 0.726f, 0.726f, 1f);
    private Color colorInvisibleBackground = new Color(0.726f, 0.726f, 0.726f, 0f);

    public GameObject ExitBtn;
    public GameObject AddImageBtn;
    public GameObject VrBtn;
    public GameObject ArBtn;
    public GameObject MainMenuBtn;
    public GameObject ExhibesFlag;
    public GameObject PhotoTakerBtn;
    public GameObject KirpiBurnuLogo;
    public Image backgroundImage;

    public bool IsTaked;

    private void Awake()
    {
        if (!_instance)
            _instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        page = Page.Null;
        IsAssigned = false;
    }

    private void Update()
    {
        if (!IsAssigned)
            VisibilitySettings();
    }

    #region VisibilitySettings(); // for all UI operations.
    private void VisibilitySettings()
    {
        SetBackgroundColor();
        IsAssigned = true;

        if (page == Page.Main)
        {
            ExitBtn.SetActive(true);
            AddImageBtn.SetActive(false);
            VrBtn.SetActive(true);
            ArBtn.SetActive(true);
            MainMenuBtn.SetActive(false);
            ExhibesFlag.SetActive(true);
            PhotoTakerBtn.SetActive(false);
            KirpiBurnuLogo.SetActive(true);

            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
        else if (page == Page.VR)
        {
            ExitBtn.SetActive(false);
            AddImageBtn.SetActive(false);
            VrBtn.SetActive(false);
            ArBtn.SetActive(true);
            MainMenuBtn.SetActive(true);
            ExhibesFlag.SetActive(false);
            PhotoTakerBtn.SetActive(false);
            KirpiBurnuLogo.SetActive(true);

            SceneManager.LoadScene("vr", LoadSceneMode.Single);
        }
        else if (page == Page.AR)
        {
            ExitBtn.SetActive(false);
            AddImageBtn.SetActive(false);
            VrBtn.SetActive(true);
            ArBtn.SetActive(false);
            MainMenuBtn.SetActive(true);
            ExhibesFlag.SetActive(false);
            PhotoTakerBtn.SetActive(false);
            KirpiBurnuLogo.SetActive(true);

            SceneManager.LoadScene("ar", LoadSceneMode.Single);
        }
        else if (page == Page.AddImage)
        {
            ExitBtn.SetActive(false);
            AddImageBtn.SetActive(false);
            VrBtn.SetActive(false);
            ArBtn.SetActive(false);
            MainMenuBtn.SetActive(false);
            ExhibesFlag.SetActive(false);
            PhotoTakerBtn.SetActive(true);
            KirpiBurnuLogo.SetActive(false);

            SceneManager.LoadScene("photo", LoadSceneMode.Single);
        }
        else if (page == Page.Null)
        {
            ExitBtn.SetActive(true);
            AddImageBtn.SetActive(false);
            VrBtn.SetActive(true);
            ArBtn.SetActive(true);
            MainMenuBtn.SetActive(false);
            ExhibesFlag.SetActive(true);
            PhotoTakerBtn.SetActive(false);
            KirpiBurnuLogo.SetActive(true);

            page = Page.Main;
        }
        else
        {
            Debug.LogError("Sayfa bulunamadı.");
        }
    }
    #endregion

    // Make an enum assigment with button click
    #region Buttons // ExitButton(), AddImageButton(), VrButton(), ArButton;
    public void ExitButton()
    {
        Application.Quit();
    }
    public void AddImageButton()
    {
        page = Page.AddImage;
        IsAssigned = false;
    }
    public void VrButton()
    {
        page = Page.VR;
        IsAssigned = false;
    }
    public void ArButton()
    {
        page = Page.AR;
        IsAssigned = false;
    }
    public void MainMenuButton()
    {
        page = Page.Main;
        IsAssigned = false;
    }
    public void PhotoTakerButton()
    {
        IsTaked = true;
        // TAKE PHOTO 
        // AND
        page = Page.Main;
        IsAssigned = false;
    }
    #endregion

    #region SetBackgroundColor(); // according to page name.
    private void SetBackgroundColor()
    {
        if(page==Page.Main || page == Page.Null)
        {
            backgroundImage.color = colorVisibleBackground;
        }
        else
        {
            backgroundImage.color = colorInvisibleBackground;
        }    
    }
    #endregion 
}
