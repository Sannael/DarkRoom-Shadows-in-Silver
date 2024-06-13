using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusRotate : MonoBehaviour
{
    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;
    public RectTransform focusRect;
    public GameObject uiBlur;

    [Header("SFX")]
    public AudioClip rotateFocusSound;
    [SerializeField]
    private float lastRotateZ;

    private void Start()
    {
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        FocusStartRotation();
    }

    private void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if(col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                PlaySound(transform.eulerAngles.z);
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

            }
        }
        ChangeBlurValue();  
    }

    public void PlaySound(float rotZ) 
    {
        if(rotZ >= lastRotateZ +10 || rotZ <= lastRotateZ - 10) 
        {
            lastRotateZ = rotZ;
            Sounds.instance.PlaySingle(rotateFocusSound);
        }
        
    }

    public void FocusStartRotation()
    {
        int rot = Random.Range(90, 145);
        float posNeg = Random.Range(0, 2);
        if(posNeg > 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -rot);
        }
    }

    public void ChangeBlurValue()
    {
        float rotZ = this.transform.rotation.z * 180;
        if(rotZ < 0)
        {
            rotZ = rotZ * -1;
        }
        uiBlur.GetComponent<NovaSamples.Effects.BlurEffect>().BlurRadius = (rotZ / 18);
    }
    [ContextMenu("Pos")]
    public void SetFocusLocation()
    {
        this.transform.position = focusRect.anchoredPosition / 108; //calculo sem mt explicação mas funcional
    }


}
