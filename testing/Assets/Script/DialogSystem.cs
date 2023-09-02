using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class DialogSystem : MonoBehaviour
{
    // Lock player movement
    public static bool ON = false;
    private float textSpeed = 0.03f;

    public GameObject Canvas;
    private TextMeshProUGUI dialogText;
    private TextMeshProUGUI dialogTitle;

    private GameObject interactIteam;
    private bool finished = true;
    private bool isTyping = true;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogText = Canvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        dialogTitle = Canvas.transform.Find("Title").GetComponent<TextMeshProUGUI>();
    }

    public static List<List<string>> GetTextFromFile(TextAsset textFile)
    {
        // Store different text for different stage
        List<List<string>> textList = new List<List<string>>();
        Regex stage = new Regex("<stage[0-9]+>");
        var allText = stage.Split(textFile.text);
        foreach (string stageText in allText)
        {
            // Filter empty string
            if (stageText != "")
            {
                textList.Add(new List<string>(stageText.Trim().Split('\n')));
            }
        }
        return textList;
    }

    // Call this function to chat
    public void SendMesasge(List<string> text, GameObject item)
    {
        if (ON) {throw new KeyNotFoundException();}
        interactIteam = item;
        index = 0;
        ON = true;
        isTyping = false;
        dialogText.text = "";
        dialogTitle.text = "";
        StartCoroutine(printDialog(text));
    }

    IEnumerator printDialog(List<string> text)
    {
        Canvas.SetActive(true);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isTyping && index < text.Count)
                {
                    isTyping = true;
                    StartCoroutine(printline(text[index]));
                    index++;
                } 
                else if (isTyping)
                {
                    isTyping = false;
                }
                else
                {
                    break;
                }
            }
            yield return null;
        }
        ON = false;
        Canvas.SetActive(false);
        interactIteam.GetComponent<Interactable>().Pickup();
    }

    IEnumerator printline(string line)
    {
        string[] tmp = line.Trim().Split("<title>");
        dialogTitle.text = tmp[0];
        string text = tmp[1];
        dialogText.text = "";
        float second = 0;
        int i = 0;

        while (isTyping && i < text.Length)
        {
            second += Time.deltaTime;
            if (second > textSpeed)
            {
                dialogText.text += text[i];
                if (text[i] != ' ')
                {
                    second = 0;
                }
                i++;
            }
            yield return null;
        }

        dialogText.text = text;
        isTyping = false;
    }
}
