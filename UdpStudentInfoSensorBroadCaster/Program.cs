using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpStudentInfoSensorBroadCaster
{
    /*
 * Fake student Info UDP Sensor
 *
 * Author Zuhair haroon Khan, ZIBAT Computer Science
 * Version 1.0. 2018.11.05
 * Copyright 2018 by Zuhair haroon Khan * 
 * All rights reserved
   
 */
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpSender = new UdpClient(0) {EnableBroadcast = true};
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7000);
            Console.WriteLine("Broadcast ready. Get started Press Enter");
            Console.ReadLine();
            while (true)
            {
                int i = 0;
                RandomNumberNameClass _rand = new RandomNumberNameClass();
                string fullName = RandomNumberNameClass.GetName(i);
                int age = _rand.GetAge();
                int Id = _rand.GetId();
                DateTime currentTime = DateTime.Now;
                string timeTxt = "Time: " + currentTime + " \r\n";
                //string sensorData = sensorLocation + timeTxt + data;
                string sensorData = $" Name:{fullName}-\r\n Age:{age}-\r\n Id:{Id}-\r\n CurrentTime:{currentTime} -\r\n\r\n";

                Byte[] sendBytes = Encoding.ASCII.GetBytes(sensorData);

                try
                {
                    udpSender.Send(sendBytes, sendBytes.Length, endPoint); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                i++;
                Console.WriteLine("Name:" + fullName);
                Console.WriteLine("Age:" + age);
                Console.WriteLine("Id:" + Id);
                Console.WriteLine("DateTime:" + currentTime);
                Console.WriteLine("Broadcasting data on Port no: 7000" );
                //Console.WriteLine(sensorData);
                Console.WriteLine("-----------------------------------------");
                Thread.Sleep(1000);
            }


        }
    }
}
