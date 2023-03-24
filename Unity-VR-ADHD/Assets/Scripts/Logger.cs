using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Logger{
    private string fileName;
    private string name;
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

    private string NewFileName(){
        string fileName = dir + "/User1-" + name + ".csv";
        int count = 2;
        while(File.Exists(fileName)){
            fileName = dir + "/User" + count + "-" + name + ".csv";
            count += 1;
        }
        return fileName;
    }
}