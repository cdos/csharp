using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapClient_from_wsdl.PositioningControl;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace SoapClient_from_wsdl
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPositionRequest positionrequest = new PositioningControl.GetPositionRequest();
            //PositioningControl.GetPositionResponse positionresponse = new PositioningControl.GetPositionResponse();

            //positionrequest.GetHashCode();




            //Console.WriteLine("enter number");
            //string input = Console.ReadLine();
            //string end_point = "http://10.221.211.95/control/PositioningControl-1";

            //Console.WriteLine(input, end_point);



            /// <summary>
            /// The main entry point for the application.
            /// </summary>

            //=======================================================
            // Constants - change these to alter the values
            //=======================================================
            const String CAMERA_IP_ADDRESS = "10.221.224.51";
            const int PORT_NUMBER = 80;
            const int CAMERA_NUMBER = 1;
            const String STR_ENTER_TO_CONTINUE = "Press Enter to continue...";
            const int POSITION_X = 18000;
            const int POSITION_Y = -4500;
            const int SPEED_X = 2000;
            const int SPEED_Y = -1000;
            const String CAMERA_USERNAME = "admin";
            const String CAMERA_PASSWORD = "admin";
        }
    }
}
