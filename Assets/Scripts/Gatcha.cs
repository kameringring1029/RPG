using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using MembersJson;
using System;

enum Member : int { Honoka, Eli, Kotori, Umi, Rin, Maki, Nozomi, Hanayo, Nico};
enum Rarity : int { N, R, SR, SSR, UR};


public class Gatcha : MonoBehaviour {
    

    public membersinfo[] membersInfo;
    public Sprite[] memberIcon;
    public Sprite[] envelopeIcon;



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
                    

                    /* ガチャ結果をGUI反映 */
                    GameObject.Find("gatcha_member ("+i+")").GetComponent<SpriteRenderer>().sprite = memberIcon[member_id];
                    GameObject.Find("Text (" + i + ")").GetComponent<Text>().text = membersInfo[i].series;
                    GameObject.Find("envelope (" + i + ")").GetComponent<SpriteRenderer>().sprite = envelopeIcon[Int32.Parse( membersInfo[i].rarity)];


                    /* 各ガチャ結果をインスタンスに代入 */
                    GatchaMember memberObj = GameObject.Find("gatcha_member (" + i + ")").GetComponent<GatchaMember>();
                    memberObj.id = membersInfo[i].id;
                    memberObj.rarity = membersInfo[i].rarity;
                    memberObj.name = membersInfo[i].name;
                    memberObj.series = membersInfo[i].series;
                    memberObj.fullimgurl_0 = membersInfo[i].fullimgurl_0;
                    memberObj.fullimgurl_1 = membersInfo[i].fullimgurl_1;
                    memberObj.info = membersInfo[i].info;
                    memberObj.status_s = membersInfo[i].status_s;
                    memberObj.status_p = membersInfo[i].status_p;
                    memberObj.status_c = membersInfo[i].status_c;
                    memberObj.type = membersInfo[i].type;


                    Debug.Log(i + " " + membersInfo[i].name + "(" + membersInfo[i].series + "):" + membersInfo[i].type + "," + membersInfo[i].status_s + "," + membersInfo[i].status_p + "," + membersInfo[i].status_c);

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
