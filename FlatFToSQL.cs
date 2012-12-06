using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objects used throughout program
            string name;
            string date;
            string address;
            string senam;
            string subject;
            string both;
            byte[] content;

            // Connecting to Database
            SqlConnection con = new SqlConnection();
            SqlCommand myCom;
            SqlCommand myComm;
            
            con.ConnectionString = "integrated security=SSPI;data source=[SERVERNAME];" + "persist security info=False;initial catalog=DNC";

            // Connecting to email
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010);
            service.Credentials = new NetworkCredential("[USERNAME]", "[PASSWORD]", "[DOMAIN]");
            service.AutodiscoverUrl("[EMAIL]");

            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.JunkEmail, new ItemView(10));

            foreach (Item item in findResults.Items)
            {
                // Establish some variables for email inside the email item loop

                if (item.HasAttachments)
                {
                    item.Load();
                    // If the item has two attachments, then we want to load each valid attachment (a txt or csv)
                    if (item.Attachments.Count > 1)
                    {
                        foreach (FileAttachment fileA in item.Attachments)
                        {
                            item.Load();
                            EmailMessage msg = (EmailMessage)item;
                            address = Convert.ToString(msg.Sender.Address);
                            senam = Convert.ToString(msg.Sender.Name);
                            date = Convert.ToString(item.DateTimeCreated);
                            FileAttachment fileAttachment = fileA;
                            if (fileAttachment.Name.EndsWith("txt"))
                            {
                                name = Convert.ToString(fileAttachment.Name);
                                fileAttachment.Load();
                                content = fileAttachment.Content;
                                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                                string strContent = enc.GetString(content);
                                string Phone;
                                int Ctn;
                                int EOL = 0;

                                EOL = strContent.IndexOf("\r\n", EOL);
                                Ctn = 0;

                                while (EOL > 0)
                                {
                                    Ctn++;
                                    Phone = strContent.Substring(0, EOL);

                                    try
                                    {
                                        con.Open();
                                        myCom = new SqlCommand();
                                        myCom.Connection = con;
                                        myCom.CommandType = CommandType.Text;

                                        myCom.CommandText = @"Insert INTO[TABLENAME] ([V1],[V2],[V2],[V4],[V5])" + "VALUES (@p,@p1,@p2,@p3,@p4)";
                                        myCom.Parameters.AddWithValue("@p", Phone);
                                        myCom.Parameters.AddWithValue("@p1", senam);
                                        myCom.Parameters.AddWithValue("@p2", date);
                                        myCom.Parameters.AddWithValue("@p3", name);
                                        myCom.Parameters.AddWithValue("@p4", address);
                                        myCom.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("SQL Connection Failed");
                                        con.Close();
                                    }

                                    strContent = strContent.Substring(EOL + 2);
                                    EOL = strContent.IndexOf("\r\n", 0);

                                }
                                Console.WriteLine(name);
                            }
                            else if (fileAttachment.Name.EndsWith("csv"))
                            {
                                name = Convert.ToString(fileAttachment.Name);
                                fileAttachment.Load();
                                content = fileAttachment.Content;
                                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                                string strContent = enc.GetString(content);
                                string Phone;
                                int Ctn;
                                int EOL = 0;

                                EOL = strContent.IndexOf("\r\n", EOL);
                                Ctn = 0;

                                while (EOL > 0)
                                {
                                    Ctn++;
                                    Phone = strContent.Substring(0, EOL);

                                    try
                                    {
                                        con.Open();
                                        myCom = new SqlCommand();
                                        myCom.Connection = con;
                                        myCom.CommandType = CommandType.Text;

                                        myCom.CommandText = @"Insert INTO [TABLENAME] ([V1],[V2],[V2],[V4],[V5])" + "VALUES (@p,@p1,@p2,@p3,@p4)";
                                        myCom.Parameters.AddWithValue("@p", Phone);
                                        myCom.Parameters.AddWithValue("@p1", senam);
                                        myCom.Parameters.AddWithValue("@p2", date);
                                        myCom.Parameters.AddWithValue("@p3", name);
                                        myCom.Parameters.AddWithValue("@p4", address);
                                        myCom.ExecuteNonQuery();
                                        con.Close();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("SQL Connection Failed");
                                        con.Close();
                                    }

                                    strContent = strContent.Substring(EOL + 2);
                                    EOL = strContent.IndexOf("\r\n", 0);

                                }
                                Console.WriteLine(name);
                            }
                            else // if the attachment is not a csv or txt, dump it into a folder
                            {
                                fileAttachment.Load("C:\\test\\" + fileAttachment.Name);
                            }
                            }
                    }
                    if (item.Attachments.Count == 1)
                    {
                        item.Load();
                        EmailMessage msg = (EmailMessage)item;
                        address = Convert.ToString(msg.Sender.Address);
                        senam = Convert.ToString(msg.Sender.Name);
                        date = Convert.ToString(item.DateTimeCreated);
                        subject = Convert.ToString(item.Subject);
                        FileAttachment fileAttachment = item.Attachments[0] as FileAttachment;
                        name = Convert.ToString(fileAttachment.Name);
                        both = name + " " + subject;
                        fileAttachment.Load();
                        content = fileAttachment.Content;
                        System.Text.Encoding enc = System.Text.Encoding.ASCII;
                        string strContent = enc.GetString(content);
                        string Phone;
                        int Ctn;
                        int EOL = 0;

                        EOL = strContent.IndexOf("\r\n", EOL);
                        Ctn = 0;

                        while (EOL > 0)
                        {
                            Ctn++;
                            Phone = strContent.Substring(0, EOL);

                            try
                            {
                                con.Open();
                                myCom = new SqlCommand();
                                myCom.Connection = con;
                                myCom.CommandType = CommandType.Text;

                                myCom.CommandText = @"Insert INTO dbo.[TABLENAME] ([V1],[V2],[V2],[V4],[V5])" + "VALUES (@p,@p1,@p2,@p3,@p4)";
                                myCom.Parameters.AddWithValue("@p", Phone);
                                myCom.Parameters.AddWithValue("@p1", senam);
                                myCom.Parameters.AddWithValue("@p2", date);
                                myCom.Parameters.AddWithValue("@p3", both);
                                myCom.Parameters.AddWithValue("@p4", address);
                                myCom.ExecuteNonQuery();
                                con.Close();
                            }
                            catch
                            {
                                Console.WriteLine("SQL Connection Failed");
                                con.Close();
                            }

                            strContent = strContent.Substring(EOL + 2);
                            EOL = strContent.IndexOf("\r\n", 0);

                        }
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    Console.WriteLine("That email has no attachments.");
                    con.Close();
                }
            }
            con.Open();
            myComm = new SqlCommand();
            myComm.Connection = con;
            myComm.CommandType = CommandType.Text;
            myComm.CommandText = "EXEC [STOREDPROCEDURE]";
            myComm.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("All Done! Hit ENTER to exit the program.");
            Console.ReadLine();
        }
    }
}