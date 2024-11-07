using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveDataManager
{
    //The object with the information we're saving
    public static SaveClass saveFile = new SaveClass();
    //The path, including the name, of the file we're saving
    public static string filePath;
    //The extension of the file we're saving
    private static string extension = ".saveFile";


    //Updates the score with the "to" variable
    public static void SetScore(int to)
    {
        saveFile.score = to;
    }

    //When this function is called, it builds the filePath based on the given fileName and extension
    public static void BuildPath(string fileName)
    {
        //Using the + operand to append string
        //filePath = Application.persistentDataPath + "/" + fileName + extension;

        //Using the string.format function
        filePath = string.Format("{0}/{1}{2}", Application.persistentDataPath, fileName, extension);
    }

    //Takes the saveFile variable and serializes it into a file
    public static void Save()
    {
        //Create a new variable to hold a reference to the file in the filepath after opening it
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        //Make a binary formatter to handle the serialization of the savefile
        BinaryFormatter bf = new BinaryFormatter();

        //Serializes the savefile into the open dataStream at the filePath
        bf.Serialize(dataStream, saveFile);

        //MAKE SURE TO CLOSE A FILE AFTER WORKING WITH IT
        dataStream.Close();
    }

    //Takes the file in the filePath, converts it to an object of SaveClass, and stores it into the saveFile variable
    public static void Load()
    {
        FileStream dataStream;

        if (!File.Exists(filePath))
        {
            //Will create the file and override any other file at filePath
            Save();
        }
        //Basically the same as in Save(), but with one line of difference
        else
        {
            //Create a new variable to hold a reference to the file in the filepath after opening it
            //Is not able to create the file
            dataStream = new FileStream(filePath, FileMode.Open);

            //Make a binary formatter to handle the serialization of the savefile
            BinaryFormatter bf = new BinaryFormatter();

            //Take the open file at the filePath and deserialize it back into a Saveclass
            //saveFile = (SaveClass)bf.Deserialize(dataStream);
            saveFile = bf.Deserialize(dataStream) as SaveClass;

            //MAKE SURE TO CLOSE A FILE AFTER WORKING WITH IT
            dataStream.Close();
        }
    }
}
