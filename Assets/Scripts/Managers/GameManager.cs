using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Menu")]
    public Animator fadeAnim;
    public float fadeTime;

    [Header("Cameras")]
    public Camera MainCamera;
    public GameObject shipCamera;
    public GameObject firstPersonCamera;
    public LayerMask everythingLayerMask;
    private int oldCullingMask;

    [Header("Sails")]
    public Vector3 sailAWind;
    public Vector3 sailBWind;
    public Cloth topFront;
    public Cloth bottomFront;
    public Cloth topBack;
    public Cloth bottomBack;
    public Cloth topFrontB;
    public Cloth bottomFrontB;
    public Cloth topBackB;
    public Cloth bottomBackB;

    // Start is called before the first frame update
    void Start()
    {
        oldCullingMask = MainCamera.cullingMask;
        #region Cursor
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        CursorVisiblity();
        CameraDepndentStuff();
    }

    private void CursorVisiblity()
    {      
        Cursor.visible = shipCamera.activeInHierarchy;       
    }

    private void CameraDepndentStuff()
    {
        if (firstPersonCamera.activeInHierarchy)
        {
            MainCamera.cullingMask = -1;

            #region Sails
            topFront.externalAcceleration = Vector3.zero;
            bottomFront.externalAcceleration = Vector3.zero;
            topBack.externalAcceleration = Vector3.zero;
            bottomBack.externalAcceleration = Vector3.zero;

            topFrontB.externalAcceleration = Vector3.zero;
            bottomFrontB.externalAcceleration = Vector3.zero;
            topBackB.externalAcceleration = Vector3.zero;
            bottomBackB.externalAcceleration = Vector3.zero;
            #endregion
        }
        else
        {
            MainCamera.cullingMask = oldCullingMask;

            #region Sails
            topFront.externalAcceleration = sailAWind;
            bottomFront.externalAcceleration = sailAWind;
            topBack.externalAcceleration = sailAWind;
            bottomBack.externalAcceleration = sailAWind;

            topFrontB.externalAcceleration = sailBWind;
            bottomFrontB.externalAcceleration = sailBWind;
            topBackB.externalAcceleration = sailBWind;
            bottomBackB.externalAcceleration = sailBWind;
            #endregion
        }
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadScene(name));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(string name)
    {
        fadeAnim.SetTrigger("fade");
        yield return new WaitForSecondsRealtime(fadeTime);
        SceneManager.LoadScene(name);
    }
}
