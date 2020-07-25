using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class Ws: MonoBehaviour {
    WebSocket ws;

    // スタート時ｎ呼ばれる
    void Start()
    {
        // WebSocketのクライアントの生成
        ws = new WebSocket("ws://nagoyahack2020.herokuapp.com/");

        // 接続時に呼ばれる
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("open");
        };

        // サーバからのデータ受信時に呼ばれる
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log(e.Data);
        };

        // クローズ時に呼ばれる
        ws.OnClose += (sender, e) =>
        {
            Debug.Log("close");
        };

        // エラー時に呼ばれる
        ws.OnError += (sender, e) =>
        {
            Debug.Log(e.Message);
        };

        // 接続
        ws.Connect();
    }

    // フレーム毎に呼ばれる
    void Update()
    {
        // スペースキー押上時に呼ばれる
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ws.Send("hello");
        }
    }

    // 破棄時に呼ばれる
    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}