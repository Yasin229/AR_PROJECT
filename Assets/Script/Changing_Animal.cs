using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    public GameObject rabbit;
    public GameObject cat;
    public GameObject dog;
    public GameObject chicken;
    public Button forwardButton;
    public Button backwardButton;
    public Button voiceButton;

    public AudioClip rabbitSound;
    public AudioClip catSound;
    public AudioClip dogSound;
    public AudioClip chickenSound;

    private int currentAnimalIndex = 0;
    private List<GameObject> animals;
    private AudioSource animalAudioSource;

    void Start()
    {
        animals = new List<GameObject> { rabbit, cat, dog, chicken };
        animalAudioSource = gameObject.AddComponent<AudioSource>();

        forwardButton.onClick.AddListener(OnForwardButtonClicked);
        backwardButton.onClick.AddListener(OnBackwardButtonClicked);
        voiceButton.onClick.AddListener(OnVoiceButtonClicked);

        ActivateCurrentAnimal();
    }

    void OnForwardButtonClicked()
    {
        if (currentAnimalIndex < animals.Count - 1)
        {
            currentAnimalIndex++;
            ActivateCurrentAnimal();
            UpdateButtonInteractivity();
        }
    }

    void OnBackwardButtonClicked()
    {
        if (currentAnimalIndex > 0)
        {
            currentAnimalIndex--;
            ActivateCurrentAnimal();
            UpdateButtonInteractivity();
        }
    }

    void OnVoiceButtonClicked()
    {
        PlayAnimalSound();
    }

    void ActivateCurrentAnimal()
    {
        foreach (GameObject animal in animals)
        {
            animal.SetActive(false);
        }

        animals[currentAnimalIndex].SetActive(true);
        SetAnimalSound();
    }

    void UpdateButtonInteractivity()
    {
        forwardButton.interactable = currentAnimalIndex < animals.Count - 1;
        backwardButton.interactable = currentAnimalIndex > 0;
    }

    void SetAnimalSound()
    {
        switch (currentAnimalIndex)
        {
            case 0:
                animalAudioSource.clip = rabbitSound;
                break;
            case 1:
                animalAudioSource.clip = catSound;
                break;
            case 2:
                animalAudioSource.clip = dogSound;
                break;
            case 3:
                animalAudioSource.clip = chickenSound;
                break;
        }
    }

    void PlayAnimalSound()
    {
        if (animalAudioSource.clip != null)
        {
            animalAudioSource.Play();
        }
    }
}