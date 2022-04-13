using System;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
//using UnityEngine.Networking;
using Mirror;

[Serializable]
public class Report
{
    public string version = "0.0.6";
    public string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public double epoch = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    public string eventKey;
    public string eventValue;
    public string userId;
    public Vector3Int cardPlayed = Vector3Int.zero;
    public Vector3Int cardAttacked = Vector3Int.zero;
    public string combination = null;
    public Vector3Int cardGenerated = Vector3Int.zero;
    public Report(string userId, string eventKey, string eventValue)
    {
        this.userId = userId;
        this.eventKey = eventKey;
        this.eventValue = eventValue;
    }
}

public static class NetrisAnalytics
{
    private const string path = "Assets/Logs/userLog.json";
    private static readonly StreamWriter Writer = new(path, true);

    public static void ReportEvent(string userId, string eventKey, string eventValue)
    {
        Writer.WriteLine(JsonUtility.ToJson(new Report(userId, eventKey, eventValue)));
        Writer.Flush();
    }
    
    public static void ReportCard(string userId, Vector3Int pcardPlayed, Vector3Int pcardGenrated)
    {
        var report = new Report(userId, "MOVE", "PlayerEvent")
        {
            //CardPlayed = pDelta,
            cardPlayed = pcardPlayed,
            cardGenerated = pcardGenrated,
        };
        Writer.WriteLine(JsonUtility.ToJson(report));
        Writer.Flush();
    }
    
    public static void ReportAttack(string userId, string pCombination, Vector3Int pCard)
    {
        var report = new Report(userId, "ROTATE", "PlayerEvent")
        {
            combination = pCombination,
            cardAttacked = pCard,
        };
        Writer.WriteLine(JsonUtility.ToJson(report));
        Writer.Flush();
    }
    
   /* public static void ReportState(string userId, Vector3Int[] pBoard, Vector3Int[] pPiece)
    {
        var report = new Report(userId, "STATE", "KeyFrame")
        {
            board = pBoard,
            piece = pPiece
        };
        Writer.WriteLine(JsonUtility.ToJson(report));
        Writer.Flush();
    }*/
    
    public static void Close() => Writer.Close();
}
    

