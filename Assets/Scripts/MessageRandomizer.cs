using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageRandomizer : MonoBehaviour
{
    public string[] messages;
    public TextMeshProUGUI messageText;
    void Start()
    {
        messageText.text = messages[Random.Range(0, messages.Length)];
    }
}
