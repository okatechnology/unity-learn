using UnityEngine;
using TMPro;

public class TileController : MonoBehaviour
{
    private TextMeshProUGUI numberText;
    private int number = 0;
    private static int nextNumber = 1;

    void Start()
    {
        GameObject textObject = new GameObject("NumberText");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = Vector3.zero;

        RectTransform rectTransform = textObject.AddComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.localPosition = Vector3.zero;

        numberText = textObject.AddComponent<TextMeshProUGUI>();
        numberText.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
        numberText.fontSize = 1;
        numberText.alignment = TextAlignmentOptions.Center;
        numberText.color = Color.black;
        UpdateNumberText();
    }

    void UpdateNumberText()
    {
        numberText.text = number > 0 ? number.ToString() : "A";
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                CheckInput(touch.position);
            }
        }
        Debug.Log("aaaa");
    }

    void OnMouseDown()
    {
        HandleClickOrTap();
    }

    private void CheckInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit && hit.transform == transform)
        {
            HandleClickOrTap();
        }
    }

    private void HandleClickOrTap()
    {
        
        if (number == 0)
        {
            number = nextNumber++;
            UpdateNumberText();
        }
    }
}
