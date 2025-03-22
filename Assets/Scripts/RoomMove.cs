using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public float displayTime;
    public bool needText;
    public string placeName;
    public GameObject text;
    public TextMeshProUGUI placeText;

    private CameraMovement cam;
    private static IEnumerator coroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            var tamp = cam.smoothing;
            cam.smoothing = (float)0.5;
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            cam.smoothing = tamp;
            if (needText)
            {
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = ShowTextCoroutine();
                StartCoroutine(coroutine);
            }
            else
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }

                text.SetActive(false);
                placeText.text = null;
            }
        }
    }

    private IEnumerator ShowTextCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
        placeText.text = null;
    }
}