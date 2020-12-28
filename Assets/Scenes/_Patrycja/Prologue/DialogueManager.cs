using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    // public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public Dialogue dialogue;

    public Player player;

    // Start is called before the first frame update
    void Start() {
        // Dodaje scene do Stosu
        player.addSceneToStack(SceneManager.GetActiveScene().buildIndex);

        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("IsOpen", true);
        
        // nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Menu
        }
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        // Dodaje następną scene (dzień 1) do Stosu (dlatego +1)
        player.addSceneToStack(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(player.level);
    }
}
