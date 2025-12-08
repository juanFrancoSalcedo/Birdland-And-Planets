using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timon:MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Image steeringWheel;
    public float rotationSpeed = 50f;
    public float inertiaDecay = 0.95f;
    [Range(-180, 180)] public float minRotation = -45f;
    [Range(-180, 180)] public float maxRotation = 45f;
    public UnityEvent<float,bool> OnRotationNormalized;
    private float currentRotation = 0f;
    private Vector2 lastPosition;
    private float currentVelocity = 0f;
    private bool isDragging = false;

    int clickCount = 0;

    void Start()
    {
        if (steeringWheel == null)
            steeringWheel = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        lastPosition = eventData.position;
        currentVelocity = 0f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - lastPosition;
        lastPosition = eventData.position;

        float rotationDelta = delta.x * rotationSpeed * Time.unscaledDeltaTime;

        currentRotation -= rotationDelta;
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);
        currentVelocity = rotationDelta / Time.unscaledDeltaTime;
        steeringWheel.transform.rotation = Quaternion.Euler(0, 0, currentRotation);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    void Update()
    {
        if (!isDragging && currentVelocity != 0f)
        {
            currentRotation -= currentVelocity * Time.unscaledDeltaTime;
            currentVelocity *= inertiaDecay;

            if (Mathf.Abs(currentVelocity) < 0.2f)
            {
                currentVelocity = 0f;
            }
            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);
            steeringWheel.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
        InvokeRotationEvent();
    }

    void InvokeRotationEvent()
    {
        float normalizedValue = (float)currentRotation/115f;
        print(normalizedValue);
        OnRotationNormalized?.Invoke(-normalizedValue,isDragging);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;

        if (clickCount == 2)
        { 
            currentVelocity = 0f;
            clickCount = 0;
        }
    }
}