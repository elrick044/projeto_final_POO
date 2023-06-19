namespace projeto_final_POO2.reflection;
using System;
using System.IO;
using System.Text.Json;

public class ReflectionProject
{
    public static void SaveObjectToJson<T>(T obj, string filePath)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }

        string jsonString = JsonSerializer.Serialize(obj);

        File.WriteAllText(filePath, jsonString);
    }
}