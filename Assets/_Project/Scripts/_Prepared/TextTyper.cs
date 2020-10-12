using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

namespace _Project.Scripts
{
    public class TextTyper : MonoBehaviour
    {
        public UnityEvent ActionOnFinish;
        
        public float letterPause = 0.1f;
 
        private string _message;
        private Text _textComp;
        
        private Coroutine _coroutine;
 
        private void Start () 
        {
            _textComp = GetComponent<Text>();
            _message = _textComp.text;
            _textComp.text = "";
            _coroutine = StartCoroutine(TypeText ());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
            {
                Skip();
            }
        }

        public void Skip()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
                _textComp.text = _message;
                ActionOnFinish?.Invoke();
            }
        }

        private IEnumerator TypeText () 
        {
            foreach (char letter in _message.ToCharArray()) 
            {
                _textComp.text += letter;
                yield return 0;
                yield return new WaitForSeconds (letterPause);
            }
            ActionOnFinish?.Invoke();
        }
    }
}