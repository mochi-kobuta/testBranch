using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding
using UnityEngine.UI;

public class textLoadController : MonoBehaviour {

    private string guitxt = "";

    // 読み込み関数
    public string ReadFile(string url)
    {
        // FileReadTest.txtファイルを読み込む
        FileInfo fi = new FileInfo(Application.dataPath + "/" + url);

        try
        {
            // 一行毎読み込み
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {
                guitxt = sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            // 改行コード
            guitxt += SetDefaultText();
        }

        return guitxt;
    }

    // 改行コード処理
    string SetDefaultText()
    {
        return "\n";
    }
}
