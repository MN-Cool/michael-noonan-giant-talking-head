using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriter_Static(Text textUI, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(textUI);
        }
        return instance.AddWriter(textUI, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    private TextWriterSingle AddWriter(Text textUI, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(textUI, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(Text textUI)
    {
        instance.RemoveWriter(textUI);
    }

    private void RemoveWriter(Text textUI)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if(textWriterSingleList[i].GetUIText() == textUI)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        for(int i=0; i<textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {
        private Text textUI;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextWriterSingle(Text textUI, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.textUI = textUI;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        } 

        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                textUI.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    if (onComplete != null) onComplete();
                    return true;
                }
            }

            return false;
        }

        public Text GetUIText()
        {
            return textUI;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            textUI.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriter.RemoveWriter_Static(textUI);
        }
    }
}
