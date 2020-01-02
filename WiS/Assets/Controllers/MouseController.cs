using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Material SelectionMaterial;
    public Canvas UserInterface;

    GameObject currentObject;
    Material currentMaterial;
    TextMeshProUGUI textMeshPro;
    float zoomSpeed = 1500.0f;

    public GameObject CurrentObject { get => currentObject; set => currentObject = value; }
    public Material CurrentMaterial { get => currentMaterial; set => currentMaterial = value; }
    public TextMeshProUGUI TMP { get => textMeshPro; set => textMeshPro = value; }

    // Start is called before the first frame update
    void Start()
    {
        TMP = UserInterface.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseClicks();
        MouseMovement();        
    }

    void MouseClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit)
            {
                // Dem zuletzt markierten Objekt sein ursprüngliches Material wiedergeben
                if (CurrentObject != null)
                {
                    if (currentMaterial != null) 
                    {
                        CurrentObject.GetComponent<Renderer>().material = currentMaterial;
                    }
                }

                // Aktuelles Objekt und Material neu zuweisen
                CurrentObject = hitInfo.transform.gameObject;
                CurrentMaterial = CurrentObject.GetComponent<Renderer>().material;

                // Treffermeldung
                TMP.text = hitInfo.transform.gameObject.name;

                // Material neu zuweisen
                CurrentObject.GetComponent<Renderer>().material = SelectionMaterial;
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }

    void MouseMovement()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 35, 100);
        }

    }
}
