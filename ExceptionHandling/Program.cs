using System;
using System.IO;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string logPath = "log.txt";
            string fileName = "test.txt";
            string path = @"folder\folder2\test.txt";// backslasher und @ zeichen für pfad angabe bei windows

            // im try block wird versucht den code auszuführen!
            try 
            {
                string finalPath = Path.Combine(logPath, fileName);
                File.Create(finalPath);

                File.AppendAllText(finalPath, "Hallo Welt");

                File.AppendAllText(logPath, "Log: Successfully Created file.\n "); // backslash steht für Zeilenumbruch
            }

            // hier wird versucht den fehler der im try entstanden ist abzufangen!
            catch(IOException e) // Input Output Exception
            {
                File.AppendAllText(logPath, "Log: File already in use: Exception:  "+ "\n");
            }

            catch (Exception e) // Grundsätzliche Exception, pfad nicht gefunden! 
            {
                Directory.CreateDirectory(path);// erstellt verzeichniss
                File.AppendAllText(logPath, "Log: something went wrong during file Creation: Exception:  " + e + "\n");
            }
            

            File.AppendAllText(logPath, "Log: Tried to Created file.\n ");


        }
    }
}