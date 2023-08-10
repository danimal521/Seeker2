namespace Broadcaster;

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Broadcaster Start!");        

        do
        {
            PullImages();
            //Thread.Sleep(60000); //This is a min
            Thread.Sleep(1000);
        }while(true);
    }

    static void PullImages()
    {
        Console.WriteLine("Pull Images: " + DateTime.Now.ToString());

        string strConnectionString                                      = "";
        
        BlobContainerClient blobContainerClient                         = new BlobContainerClient(strConnectionString, "out");
        blobContainerClient.CreateIfNotExists();
        
        var blobs                                                       = blobContainerClient.GetBlobs();
        foreach (BlobItem blobItem in blobs)
        {
            Console.WriteLine("\t" + blobItem.Name + " " + GenerateSAS(blobItem)); //Alert system this is a "bad"
            var blob = blobContainerClient.GetBlobClient(blobItem.Name);
            blob.DeleteIfExists();
        }
    }

    //TODO: gotta get this code later tonight, so return derpy cat
    static string GenerateSAS(BlobItem blobItem)
    {
        return "https://cdn.wallpapersafari.com/97/19/LZTD7u.jpg";
    }
}
