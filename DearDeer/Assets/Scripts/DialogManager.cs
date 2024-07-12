using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialog
{
    public List<string> lines;
}

public class DialogManager : MonoBehaviour {

    public GameObject dialogBox;
    public TMP_Text dialogtext;
    public int charPerSeconds = 15;

    public static DialogManager instance;


    void Start()
    {
        dialogBox.SetActive(true);
    }
    void Awake()
    {
        instance = this;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogtext.text = "";
        foreach (var character in dialog.ToCharArray())
            {
            dialogtext.text += character;
            yield return new WaitForSeconds(1f / charPerSeconds);
        }
    }

    public IEnumerator ShowDialog(int lanNum, Dialog korDialog, Dialog EngDialog)
    {
        dialogBox.SetActive(true);

        switch(lanNum)
        {
            case 0:
                foreach(var line in korDialog.lines)
                {
                    yield return TypeDialog(line);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
                break;

            case 1:
                foreach(var line in EngDialog.lines)
                {
                    yield return TypeDialog(line);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
                break;
        }
        dialogBox.SetActive(false);
    }
}
