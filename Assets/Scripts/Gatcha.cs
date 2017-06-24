using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using MembersJson;


public class Gatcha : MonoBehaviour {
    

    public membersinfo[] membersInfo;
    public Sprite[] memberIcon;


    // Use this for initialization
    void Start () {

        StartCoroutine(GetText());

    }

    // Update is called once per frame
    void Update () {
		
	}


    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://koke.link:3000/unity/muse");
        // 下記でも可
        // UnityWebRequest request = new UnityWebRequest("http://example.com");
        // methodプロパティにメソッドを渡すことで任意のメソッドを利用できるようになった
        // request.method = UnityWebRequest.kHttpVerbGET;

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                string httptext = request.downloadHandler.text;
                Debug.Log(httptext);

                membersInfo = JsonHelper.FromJson<membersinfo>(httptext);
                Debug.Log(membersInfo [10].info);


                // バイナリデータとして取得する
                //byte[] results = request.downloadHandler.data;
                //Texture2D texture = readByBinary(results);

                // Texture -> Spriteに変換する
                //Sprite texture_sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero);

                //gameObject.GetComponent<SpriteRenderer>().sprite = texture_sprite;

                int member_id = 10;
                for(int i=0; i<11; ++i)
                {
                    if(membersInfo[i].name == "穂乃果") { member_id = 0; }
                    else if(membersInfo[i].name == "絵里") { member_id = 1; }
                    else if (membersInfo[i].name == "ことり") { member_id = 2; }
                    else if (membersInfo[i].name == "海未") { member_id = 3; }
                    else if (membersInfo[i].name == "凛") { member_id = 4; }
                    else if (membersInfo[i].name == "真姫") { member_id = 5; }
                    else if (membersInfo[i].name == "希") { member_id = 6; }
                    else if (membersInfo[i].name == "花陽") { member_id = 7; }
                    else if (membersInfo[i].name == "にこ") { member_id = 8; }

                    GameObject.Find("gatcha_member ("+i+")").GetComponent<SpriteRenderer>().sprite = memberIcon[member_id];
                    GameObject.Find("Text (" + i + ")").GetComponent<Text>().text = membersInfo[i].series;
                }


            }
        }
    }

    public Texture2D readByBinary(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }
}
