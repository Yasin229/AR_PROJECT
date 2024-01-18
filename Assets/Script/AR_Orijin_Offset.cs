using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ARCursor : MonoBehaviour
{
    public GameObject cursorChildObject;
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public Button offsetButton; // Eklenen offset butonu

    private bool useCursor = true;

    void Start()
    {
        cursorChildObject.SetActive(useCursor);

        // Offset butonuna tıklama olayını dinle
        offsetButton.onClick.AddListener(OnOffsetButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

    void OnOffsetButtonClick()
    {
        // Cursor'ın mevcut pozisyonunu al
        Vector3 currentCursorPosition = cursorChildObject.transform.position;

        // Cursor'ı sabitleme işlemi
        cursorChildObject.transform.position = currentCursorPosition;

        // Imlecin güncellenmesine izin verme
        useCursor = false;
    }
}