using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Text))]
    public class SubtitlesPlace : MonoBehaviour, IPointerClickHandler
    {
        public Text text;
        
        private void Awake()
        {
            text = GetComponent<Text>();
            Clear();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clear();
            }
        }

        public void Clear()
        {
            text.text = "";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Clear();
        }
    }
}