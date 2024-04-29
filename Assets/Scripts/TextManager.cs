using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//used to control talk function
public class TextManager : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] Text text;
    [SerializeField] int letterPerSecond;// speed at which text is shown

    public event Action onShowText;
    public event Action onCloseText;

    private Dialogue dialogue;
    private int currentLine = 0;
    private bool currentlyTalking;
    private bool interruptTyping; // Flag to indicate if typing should be interrupted
    private Coroutine typingCoroutine; 

    public static TextManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        HandleUpdate();
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//if mouse click move to next line
        {
            if (!currentlyTalking)
            {
                currentLine--;// to prevent next line being skipped when previous finished
                MoveToNextLine();
            }
            else if (!interruptTyping)
            {
                interruptTyping = true; // Set flag to interrupt typing
            }
        }
    }

    private void MoveToNextLine()
    {
        ++currentLine;
        if (currentLine < dialogue.Lines.Count)
        {
            StartTypingText(dialogue.Lines[currentLine]);
        }
        else
        {
            EndDialogue();
        }
    }

    private void StartTypingText(string textToType)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Ensure ongoing coroutine is stopped before starting a new one
        }
        typingCoroutine = StartCoroutine(TypeText(textToType));
    }

    private IEnumerator TypeText(string dialogueLine)
    {
        currentlyTalking = true;
        interruptTyping = false;
        text.text = "";

        foreach (char letter in dialogueLine.ToCharArray())
        {
            if (interruptTyping)
            {
                MoveToNextLine();
                yield break; // Exit  coroutine if interrupted
            }
            text.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }

        currentlyTalking = false;
    }

    private void EndDialogue()
    {
        currentLine = 0;
        textBox.SetActive(false);
        onCloseText?.Invoke();
    }

    public IEnumerator ShowText(Dialogue dialogue)
    {
        currentLine = 0; 
        this.dialogue = dialogue;
        textBox.SetActive(true);
        onShowText?.Invoke();
        yield return new WaitForEndOfFrame();
        StartTypingText(dialogue.Lines[currentLine]); 
    }
}
