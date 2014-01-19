using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;
using LifxLib.Messages;

namespace LifxLib
{
    public class LifxBulb
    {
        private string mMacAddress = "";
        private LifxPanController mPanController;

        public LifxBulb(LifxPanController panController, string macAddress)
        {
            mPanController = panController;
            mMacAddress = macAddress;
            
        }

        /// <summary>
        /// Get current power state
        /// </summary>
        /// <returns></returns>
        public LifxPowerState GetPowerState()
        {
            LifxGetPowerStateCommand command = new LifxGetPowerStateCommand();

            LifxCommunicator.Instance.SendCommand(command, this);
            LifxPowerStateMessage returnMessage = (LifxPowerStateMessage)command.ReturnMessage;

            return returnMessage.PowerState;
        }

        /// <summary>
        /// Set current power state
        /// </summary>
        /// <param name="stateToSet"></param>
        /// <returns>Returns the set power state</returns>
        public LifxPowerState SetPowerState(LifxPowerState stateToSet)
        {
            LifxSetPowerStateCommand command = new LifxSetPowerStateCommand(stateToSet);

            LifxCommunicator.Instance.SendCommand(command, this);

            LifxPowerStateMessage returnMessage = (LifxPowerStateMessage)command.ReturnMessage;

            return returnMessage.PowerState;
        }

        public string GetLabel()
        {

            LifxGetLabelCommand command = new LifxGetLabelCommand();
            LifxCommunicator.Instance.SendCommand(command, this);

            return ((LifxLabelMessage)command.ReturnMessage).BulbLabel;
        }


        public string SetLabel(string newLabel)
        {
            LifxSetLabelCommand command = new LifxSetLabelCommand(newLabel);

            LifxCommunicator.Instance.SendCommand(command, this);

            return ((LifxLabelMessage)command.ReturnMessage).BulbLabel;
        }

        public LifxLightStatus GetLightStatus()
        {

            LifxGetLightStatusCommand command = new LifxGetLightStatusCommand();

            LifxCommunicator.Instance.SendCommand(command, this);

            LifxLightStatusMessage lsMessage = (LifxLightStatusMessage)command.ReturnMessage;

            //HSLColor hslColor = new HSLColor((double)(lsMessage.Hue * 240 / 65535), (double)(lsMessage.Saturation * 240 / 65535), (double)(lsMessage.Lumnosity * 240 / 65535));

            LifxColor color = new LifxColor(lsMessage.Hue, lsMessage.Saturation, lsMessage.Lumnosity, lsMessage.Kelvin);

            LifxLightStatus lightsStatus = new LifxLightStatus(color, lsMessage.PowerState, lsMessage.Dim, lsMessage.Label, lsMessage.Tags);

            return lightsStatus;
                
        }


        public void SetColor(LifxColor color, UInt32 fadeTime)
        {

            LifxSetLightStateCommand command = new LifxSetLightStateCommand(color.Hue, color.Saturation, color.Lumnosity, color.Kelvin, fadeTime);

            LifxCommunicator.Instance.SendCommand(command, this);
        
        }


        public void SetDimLevel(UInt16 dimLevel, UInt32 fadeTime)
        {

            LifxSetDimAbsoluteCommand command = new LifxSetDimAbsoluteCommand(dimLevel, fadeTime);

            LifxCommunicator.Instance.SendCommand(command, this);

        }


        #region ILifxNode Members

        public string PanHandler
        {
            get { return mPanController.MacAddress; }
        }

        public string MacAddress
        {
            get { return mMacAddress; }
            set { mMacAddress = value; }
        }

        public IPEndPoint IpEndpoint
        {
            get
            {
                return mPanController.IpEndpoint;
            }
            set
            {
                mPanController.IpEndpoint = value;
            }
        }

        #endregion
    }
}
