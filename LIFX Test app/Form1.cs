using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using LifxLib;

namespace Lifx_Test_app
{
    public partial class Form1 : Form
    {
        LifxBulb mBulb;

        public Form1()
        {
            InitializeComponent();

            LifxCommunicator.Instance.Initialize();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<LifxPanController> panController = LifxCommunicator.Instance.Discover();

            if (panController.Count == 0)
            {
                MessageBox.Show("Could not find any bulbs");
                mPowerGB.Enabled = false;
                mLabelsGB.Enabled = false;
                mLightStatusGB.Enabled = false;
                return;            
            }

            mBulb = panController[0].Bulbs[0];

            mBulbIPTB.Text = mBulb.IpEndpoint.Address.ToString(); 
            mTargetMACTB.Text = mBulb.MacAddress;
            mPANControllerTB.Text = mBulb.PanHandler;

            LifxPowerState powerState = mBulb.GetPowerState();

            if (powerState == LifxPowerState.On)
                mPowerStateOnCB.Checked = true;
            else
                mPowerStateOnCB.Checked = false;

            mPowerGB.Enabled = true;
            mLabelsGB.Enabled = true;
            mLightStatusGB.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mPowerStateOnCB.Checked)
                SetPowerState(LifxPowerState.On);
            else
                SetPowerState(LifxPowerState.Off);
        }

        private void SetPowerState(LifxPowerState state)
        {
            mBulb.SetPowerState(state);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LifxPowerState currState = LifxPowerState.On;

            for (int i = 0; i < 10; i++)
            {
                if (currState == LifxPowerState.On)
                    currState = LifxPowerState.Off;
                else
                    currState = LifxPowerState.On;

                SetPowerState(currState);
                Thread.Sleep(400);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mLabelTB.Text = mBulb.GetLabel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mLabelTB.Text = mBulb.SetLabel(mLabelTB.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Removed since not sure what the functions are doing

            //LifxGetTagsCommand command = new LifxGetTagsCommand();

            //LifxCommunicator.Instance.SendCommand(command, mBulb);

            //mTagsTB.Text = ((LifxTagsMessage)command.ReturnMessage).Tags.ToString();



            //LifxGetTagLabelCommand tagLabelcommand = new LifxGetTagLabelCommand(((LifxTagsMessage)command.ReturnMessage).Tags);

            //LifxCommunicator.Instance.SendCommand(tagLabelcommand, mBulb);

            //mTagLevelTB.Text = ((LifxTagLabelMessage)tagLabelcommand.ReturnMessage).TagLabel;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Removed since not sure what the functions are doing
            //LifxSetTagsCommand command = new LifxSetTagsCommand(UInt64.Parse(mTagsTB.Text));

            //LifxCommunicator.Instance.SendCommand(command, mBulb);

            //mLabelTB.Text = ((LifxTagsMessage)command.ReturnMessage).Tags.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorDialog1.Color = mBulbColorP.BackColor;
            mBulbColorP.BackColor = colorDialog1.Color;

             
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LifxLightStatus status = mBulb.GetLightStatus();

            mBulbColorP.BackColor = status.Color.DotNetColor;
            mKelvinTB.Text = status.Color.Kelvin.ToString();
            mDimLevelTB.Text = status.DimState.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UInt16 kelvinValue = 0;
            UInt32 fadeTime = 0;

            if (!UInt16.TryParse(mKelvinTB.Text, out kelvinValue))
            {
                MessageBox.Show("Kelvin needs to be a numeric value between 0 and 65535.");
                return;
            }

            if (!UInt32.TryParse(mFadeTimeTB.Text, out fadeTime))
            {
                MessageBox.Show("Fade time needs to be a numeric value.");
                return;
            }

            mBulb.SetColor(new LifxColor(mBulbColorP.BackColor, kelvinValue), fadeTime);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            UInt16 dimLevel = 0;
            UInt32 fadeTime = 0;

            if (!UInt16.TryParse(mDimLevelTB.Text, out dimLevel))
            {
                MessageBox.Show("Dim level needs to be a numeric value between 0 and 65535.");
                return;
            }

            if (!UInt32.TryParse(mFadeTimeTB.Text, out fadeTime))
            {
                MessageBox.Show("Fade time needs to be a numeric value.");
                return;
            }

            mBulb.SetDimLevel(dimLevel, fadeTime);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LifxCommunicator.Instance.Dispose();
        }
        
    }
}
