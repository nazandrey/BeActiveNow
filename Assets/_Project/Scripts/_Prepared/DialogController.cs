using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField]
        private GameObject DialogRoot;
        
        [SerializeField]
        private Text DialogYesLabel;

        [SerializeField] 
        private Text DialogNoLabel;
            
        [SerializeField]
        private Button DialogYesButton;
        [SerializeField]    
        private Button DialogNoButton;

        private void Awake()
        {
            DialogRoot.SetActive(false);
            DialogYesButton.onClick.AddListener(YesAction);
            DialogNoButton.onClick.AddListener(NoAction);
        }
        
        private void YesAction()
        {
        }
        
        private void NoAction()
        {
        }

        public void ShowDialog(string yesText, string noText)
        {
            DialogYesLabel.text = yesText;
            DialogNoLabel.text = noText;
            DialogRoot.SetActive(true);
        }
    }
}