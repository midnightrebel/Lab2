using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class GameSave : MonoBehaviour
{
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            SavePosition();
        if (Input.GetKeyDown(KeyCode.F2))
            LoadPosition();

    }
    void SavePosition()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        SavePlayer save = new SavePlayer { X = x, Y = y };
        XmlSerializer formatter = new XmlSerializer(typeof(SavePlayer));
        using (FileStream fs = new FileStream("Assets/Saves/save.xml", FileMode.Open))
        {
            formatter.Serialize(fs, save);
            fs.Close();
        }
    }

    void LoadPosition()
    {
        var serializer = new XmlSerializer(typeof(SavePlayer));
        var stream = new FileStream(Path.Combine(Application.dataPath, "Saves/save.xml"), FileMode.Open);
        var save = serializer.Deserialize(stream) as SavePlayer;
        stream.Close();
        float x = save.X;
        float y = save.Y;
        transform.position = new Vector3(x, y, 1);
    }
}

public class SavePlayer
{
    public float X { get; set; }
    public float Y { get; set; }
}