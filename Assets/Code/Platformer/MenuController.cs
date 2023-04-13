using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MenuController : MonoBehaviour
    {
        // Start is called before the first frame update
        public static MenuController instance;
        public GameObject mainMenu;
        public GameObject optionsMenu;
        public GameObject levelMenu;

        public void LoadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        void SwitchMenu(GameObject someMenu)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
            levelMenu.SetActive(false);
            
            someMenu.SetActive(true);
        }

        public void ShowMainMenu()
        {
            SwitchMenu(mainMenu);
        }
        public void ShowOptionsMenu()
        {
            SwitchMenu(optionsMenu);
        }
        public void ShowLevelMenu()
        {
            SwitchMenu(levelMenu);
        }
        void Awake()
        {
            instance = this;
            Hide();
        }
        public void Show()
        {
            ShowMainMenu();
            gameObject.SetActive(true);
            Time.timeScale = 0;
            PlayerController.instance.isPaused = true;
        }
        public void Hide()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            if (PlayerController.instance != null)
            {
                PlayerController.instance.isPaused = false;
            }
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

