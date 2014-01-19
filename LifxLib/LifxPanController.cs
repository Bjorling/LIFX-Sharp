using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using LifxLib.Messages;

namespace LifxLib
{
    public class LifxPanController
    {
        private string mMacAddress = "";        
        private IPEndPoint mIpAddress;
        List<LifxBulb> mBulbs = new List<LifxBulb>();

       
        public LifxPanController(string macAddress, IPEndPoint ipAddress)
        {
            mMacAddress = macAddress;
            mIpAddress = ipAddress;
        }

        ///// <summary>
        ///// Get current power state
        ///// </summary>
        ///// <returns></returns>
        //public LifxPowerState GetPowerState()
        //{
        //    LifxGetPowerStateCommand command = new LifxGetPowerStateCommand();

        //    LifxCommunicator.Instance.SendCommand(command, this);
        //    LifxPowerStateMessage returnMessage = (LifxPowerStateMessage)command.ReturnMessage;

        //    return returnMessage.PowerState;
        //}

        ///// <summary>
        ///// Set current power state
        ///// </summary>
        ///// <param name="stateToSet"></param>
        ///// <returns>Returns the set power state</returns>
        //public LifxPowerState SetPowerState(LifxPowerState stateToSet)
        //{
        //    LifxSetPowerStateCommand command = new LifxSetPowerStateCommand(stateToSet);

        //    LifxCommunicator.Instance.SendCommand(command, this);

        //    LifxPowerStateMessage returnMessage = (LifxPowerStateMessage)command.ReturnMessage;

        //    return returnMessage.PowerState;
        //}

        //public string GetLabel()
        //{

        //    LifxGetLabelCommand command = new LifxGetLabelCommand();
        //    LifxCommunicator.Instance.SendCommand(command, this);

        //    return ((LifxLabelMessage)command.ReturnMessage).BulbLabel;
        //}


        //public string SetLabel(string newLabel)
        //{
        //    LifxSetLabelCommand command = new LifxSetLabelCommand(newLabel);

        //    LifxCommunicator.Instance.SendCommand(command, this);

        //    return ((LifxLabelMessage)command.ReturnMessage).BulbLabel;
        //}

        //public LifxLightStatus GetLightStatus()
        //{

        //    LifxGetLightStatusCommand command = new LifxGetLightStatusCommand();

        //    LifxCommunicator.Instance.SendCommand(command, this);

        //    LifxLightStatusMessage lsMessage = (LifxLightStatusMessage)command.ReturnMessage;

        //    //HSLColor hslColor = new HSLColor((double)(lsMessage.Hue * 240 / 65535), (double)(lsMessage.Saturation * 240 / 65535), (double)(lsMessage.Lumnosity * 240 / 65535));

        //    LifxColor color = new LifxColor(lsMessage.Hue, lsMessage.Saturation, lsMessage.Lumnosity, lsMessage.Kelvin);

        //    LifxLightStatus lightsStatus = new LifxLightStatus(color, lsMessage.PowerState, lsMessage.Dim, lsMessage.Label, lsMessage.Tags);

        //    return lightsStatus;
                
        //}


        //public void SetColor(LifxColor color, UInt32 fadeTime)
        //{

        //    LifxSetLightStateCommand command = new LifxSetLightStateCommand(color.Hue, color.Saturation, color.Lumnosity, color.Kelvin, fadeTime);

        //    LifxCommunicator.Instance.SendCommand(command, this);
        
        //}


        //public void SetDimLevel(UInt16 dimLevel, UInt32 fadeTime)
        //{

        //    LifxSetDimAbsoluteCommand command = new LifxSetDimAbsoluteCommand(dimLevel, fadeTime);

        //    LifxCommunicator.Instance.SendCommand(command, this);

        //}


        /// <summary>
        /// Uninitialized bulb, for detection for instance
        /// </summary>
        public LifxPanController()
        { 
            
        }


        public static LifxPanController UninitializedPanController
        {
            get { return new LifxPanController(); }
        }

        
        /// <summary>
        /// Will return empty so that pan controller messages are sent to all bulbs
        /// </summary>
        public string MacAddress
        {
            get { return mMacAddress; }
            set { mMacAddress = value; }
        }

        public IPEndPoint IpEndpoint
        {
            get { return mIpAddress; }
            set { mIpAddress = value; }
        }
        
        public List<LifxBulb> Bulbs
        {
            get { return mBulbs; }
            set { mBulbs = value; }
        }
    }
}
