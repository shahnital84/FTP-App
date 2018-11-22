using System;
using System.IO;
using System.Net;


namespace FTPApp
{
    class Program
    {
        static string url = "Enter your server details";
        static string username = @"Enter your details";
        static string password = "Enter your details";
        static void Main(string[] args)
        {
            Console.WriteLine(GetDirectory(url));

            Console.ReadKey();
        }

        static string GetDirectory(string url)
        {
            string output = "";

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            output = reader.ReadToEnd();


            Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");

            reader.Close();
            response.Close();

            return (output);
        }
    }
}

