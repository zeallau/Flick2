using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera camera;
    private float cameraOriginalOrthoSize;
    private float cameraZoomOutOrthoSize;
    private float cameraAnimeTime;
    private Vector3 cameraZoomOutPosition;
    private float screenAspect;
    private int phase = -1;
    private GameObject Disc;
    private Vector3 CamPos;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        cameraOriginalOrthoSize = camera.orthographicSize;
        screenAspect = (float)Screen.height / Screen.width;
        Disc = GameObject.Find("Disc");
        CamPos = new Vector3(Disc.transform.position.x, Disc.transform.position.y, -10.0f);
        StartCoroutine(LateStart());
    }

    //ターゲットの位置がStart()で更新されてから処理するため、１フレーム待つ
    IEnumerator LateStart()
    {
        yield return new WaitForFixedUpdate();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Reset();
        }
        //this.gameObject.transform.position = CamPos;
        CamPos = new Vector3(Disc.transform.position.x, Disc.transform.position.y, -10.0f);
        cameraAnimeTime += Time.deltaTime;
        switch (phase)
        {
            case 0:
                if (cameraAnimeTime >= 0.5f)
                {
                    cameraAnimeTime = 0.0f;
                    phase = 1;
                }
                break;
            case 1:
                {
                    float animeDurartion = 1.0f;
                    if (cameraAnimeTime >= animeDurartion)
                    {
                        cameraAnimeTime = animeDurartion;
                    }
                    float animeRate = cameraAnimeTime / animeDurartion;
                    transform.position = cameraZoomOutPosition * (1.0f - animeRate) + CamPos * animeRate;
                    camera.orthographicSize = cameraZoomOutOrthoSize * (1.0f - animeRate) + cameraOriginalOrthoSize * animeRate;
                }
                break;
        }
    }

    public void Reset()
    {
        //ターゲットの配列を取得
        var targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject[] objects = new GameObject[targets.Length + 1];
        targets.CopyTo(objects, 0);
        objects[targets.Length] = GameObject.Find("Disc"); //はじきも計算対象に加える
        //ターゲットの最小X,Y,最大X,Yを計算
        float minY = float.MaxValue;
        float maxY = float.MinValue;
        float minX = float.MaxValue;
        float maxX = float.MinValue;
        foreach (var obj in objects)
        {
            float targetMaxY = obj.transform.position.y + obj.GetComponent<CircleCollider2D>().radius;
            if (targetMaxY > maxY)
            {
                maxY = targetMaxY;
            }
            float targetMinY = obj.transform.position.y - obj.GetComponent<CircleCollider2D>().radius;
            if (targetMinY < minY)
            {
                minY = targetMinY;
            }
            float targetMaxX = obj.transform.position.x + obj.GetComponent<CircleCollider2D>().radius;
            if (targetMaxX > maxX)
            {
                maxX = targetMaxX;
            }
            float targetMinX = obj.transform.position.x - obj.GetComponent<CircleCollider2D>().radius;
            if (targetMinX < minX)
            {
                minX = targetMinX;
            }
        }
        cameraZoomOutOrthoSize = Mathf.Max(maxY - minY, (maxX - minX) * screenAspect) * 0.5f; //最大値-最小値 の0.5倍( camera.orthographicSize が 1の場合、カメラの枠の高さは2になるため、0.5倍する )
        cameraZoomOutPosition = new Vector3((maxX + minX) * 0.5f, (maxY + minY) * 0.5f, -10.0f); //平均位置をとる
        camera.transform.position = cameraZoomOutPosition;
        camera.orthographicSize = cameraZoomOutOrthoSize;
        cameraAnimeTime = 0.0f;
        phase = 0;
    }
}