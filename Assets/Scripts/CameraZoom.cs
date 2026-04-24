using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera camera;

    [Header("Zoom Settings")] 
    [SerializeField] private float ZoomSpeed = 0.2f;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 80f;

    private float lastDistance;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // --- TOUCH ---
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            float distance = Vector2.Distance(t0.position, t1.position);

            // Один из пальцев только что появился
            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                lastDistance = distance;
                return;
            }

            float delta = distance - lastDistance;
            ApplyZoom(delta);

            lastDistance = distance;
            return;
        }

        // --- MOUSE ---
        float scroll = Input.mouseScrollDelta.y;
        if (Mathf.Abs(scroll) > 0.01f)
        {
            ApplyZoom(scroll * 100f);
        }
    }

    private void ApplyZoom(float delta)
    {
        float newFOV = camera.fieldOfView - delta * ZoomSpeed * Time.deltaTime;
        camera.fieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
    }
}