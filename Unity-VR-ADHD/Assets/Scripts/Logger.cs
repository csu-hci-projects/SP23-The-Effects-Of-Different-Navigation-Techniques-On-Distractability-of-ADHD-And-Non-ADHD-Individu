using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Logger{
    private string fileName;
    private string name;
    static int user = 1;
    private const string dir = "./UserData";

    public Logger(string objName){
        name = objName;
        fileName = NewFileName();
        if(!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
        }
        using(StreamWriter sw = File.CreateText(fileName)){}
    }

    public void Log(string time, string data){
        string toLog = string.Format("{0},{1},{2}", name, time, data);
        using(StreamWriter sw = File.AppendText(fileName)){
            sw.WriteLine(toLog);
        }
    }

    public void Log(string start, string end, string time){
        string toLog = string.Format("Start: {0}\nEnd: {1}\nTotal Time: {2}", start, end, time);
        using(StreamWriter sw = File.AppendText(fileName)){
            sw.WriteLine(toLog);
        }        
    }

    private string NewFileName(){
        int scene =  SceneManager.GetActiveScene().buildIndex;
        string fileName = dir + "/User" + user + "-" + name + "-" + scene + ".csv";
        while(File.Exists(fileName)){
            user += 1;
            fileName = dir + "/User" + user + "-" + name + "-" + scene + ".csv";
        }
        return fileName;
    }
}