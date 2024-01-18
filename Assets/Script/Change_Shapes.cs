using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeController : MonoBehaviour
{
    public GameObject triangle;
    public GameObject cube;
    public GameObject cylinder;
    public Button forwardButton;
    public Button backwardButton;
    public Button voiceButton;

    public AudioClip triangleSound;
    public AudioClip cubeSound;
    public AudioClip cylinderSound;

    private int currentShapeIndex = 0;
    private List<GameObject> shapes;
    private AudioSource shapeAudioSource;

    void Start()
    {
        shapes = new List<GameObject> { triangle, cube, cylinder }; // Sıralamayı güncelledik
        shapeAudioSource = gameObject.AddComponent<AudioSource>();

        forwardButton.onClick.AddListener(OnForwardButtonClicked);
        backwardButton.onClick.AddListener(OnBackwardButtonClicked);
        voiceButton.onClick.AddListener(OnVoiceButtonClicked);

        ActivateCurrentShape();
    }

    void OnForwardButtonClicked()
    {
        if (currentShapeIndex < shapes.Count - 1)
        {
            currentShapeIndex++;
            ActivateCurrentShape();
            UpdateButtonInteractivity();
        }
    }

    void OnBackwardButtonClicked()
    {
        if (currentShapeIndex > 0)
        {
            currentShapeIndex--;
            ActivateCurrentShape();
            UpdateButtonInteractivity();
        }
    }

    void OnVoiceButtonClicked()
    {
        PlayShapeSound();
    }

    void ActivateCurrentShape()
    {
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }

        shapes[currentShapeIndex].SetActive(true);
        SetShapeSound();
    }

    void UpdateButtonInteractivity()
    {
        forwardButton.interactable = currentShapeIndex < shapes.Count - 1;
        backwardButton.interactable = currentShapeIndex > 0;
    }

    void SetShapeSound()
    {
        switch (currentShapeIndex)
        {
            case 0:
                shapeAudioSource.clip = triangleSound;
                break;
            case 1:
                shapeAudioSource.clip = cubeSound;
                break;
            case 2:
                shapeAudioSource.clip = cylinderSound;
                break;
        }
    }

    void PlayShapeSound()
    {
        if (shapeAudioSource.clip != null)
        {
            shapeAudioSource.Play();
        }
    }
}