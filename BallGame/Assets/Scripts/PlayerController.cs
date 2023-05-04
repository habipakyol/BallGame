using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CameraShake camerashake;
    public UI uimanager;


    public GameObject cam;
    public GameObject vectorback;
    public GameObject vectorforward;


    private Rigidbody rb;

    private Touch touch;
    [Range(20, 30)]
    public int speedModifier;
    public int forwardSpeed;

    private bool speedballforward = false;

    private bool firstTouchControl = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Veriable.firstTouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }







        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firstTouchControl == false)
                    {
                        Veriable.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }
                    
                }

            }

            else if (touch.phase == TouchPhase.Moved)
            {
               
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * speedModifier * Time.deltaTime);
                    if (firstTouchControl == false)
                    {
                        Veriable.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }

                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }

    }
    public GameObject[] FractureItems;


    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            camerashake.CameraShakesCall();
            uimanager.StartCoroutine("BeyazEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine("TimeScaleControl");

        }
    }

    public IEnumerator TimeScaleControl()
    {
        speedballforward = true;

        yield return new WaitForSecondsRealtime(0.6f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.7f);
        uimanager.RestartButtonActive();
        rb.velocity = Vector3.zero;

    }



}
