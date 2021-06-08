using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _authorsPanel;
    [SerializeField]
    private GameObject _authorsPanelText;
    [SerializeField]
    private GameObject _parentPanel;


    private void Start()
    {
        _parentPanel.SetActive(true);
        _authorsPanel.SetActive(false);
    }
    public void OnStartButtonClick()
    {
        OpenGameScene();
    }

    private void OpenGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnAuthorsButtonClick()
    {
        OpenPanel();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnCloseButtonClick()
    {
        _authorsPanel.SetActive(false);
        _parentPanel.SetActive(true);
    }

    private void OpenPanel()
    {
        if (_authorsPanel != null)
        {
            _authorsPanel.SetActive(true);
            _parentPanel.SetActive(false);
            Animator animator = _authorsPanelText.GetComponent<Animator>();
            if(animator!= null)
            {
                bool isOpen = animator.GetBool("Open");
                animator.SetBool("Open", !isOpen);
            }
                
        }
            
    }
}
