using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoSense.Angry.Application.Services;
using TwoSense.Angry.Core;

namespace TwoSense.Angry.UI
{
    public partial class FrmSendEmail : Form
    {
        private readonly List<int> _periods;
        private readonly IAngryDetectionService _angryService;
        private readonly IEmailService _emailService;
        private int _keystrokes;

        public FrmSendEmail(IAngryDetectionService angrySerice
            , IEmailService emailService)
        {
            InitializeComponent();
            _keystrokes = 0;
            _periods = new List<int>();
            _angryService = angrySerice;
            _emailService = emailService;
        }

        private void FrmSendEmail_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// Get the new keystrokes in each period
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">Tick Event</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //TODO: Change to configure the tick from a config file
            var currnetLength = tbBody.Text.Length;
            _periods.Add( currnetLength - _keystrokes);
            _keystrokes += currnetLength;
        }

        private async void btSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btSend.Enabled = false;
            //Add the final period
            _periods.Add(tbBody.Text.Length - _keystrokes);
            var isAngry = await _angryService.IsAngryAsync(_periods);
            if(isAngry)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to send this email?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.Equals(DialogResult.No))
                {
                    //Keep watching, just in case
                    _keystrokes = tbBody.Text.Length;
                    timer1.Start();
                    return;
                }
            }

            var email = new EmailModel
            {
                Body = tbBody.Text,
                EmailAddres = tbTo.Text,
                Subject = tbSubject.Text
            };

            await _emailService.SendEmailAsync(email);
            DialogResult success = MessageBox.Show("Your email was sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
