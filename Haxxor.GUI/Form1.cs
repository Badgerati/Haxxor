using Haxxor.Framework;
using Haxxor.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haxxor.GUI
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Gets or sets the encryption module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        private IEncryptionModule Module
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is encrypting.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is encrypt; otherwise, <c>false</c>.
        /// </value>
        private bool IsEncrypt
        {
            get;
            set;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Initialise();

            Text = "Haxxor " + HaxxorFactory.Version;
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
            var types = Enum.GetNames(typeof(EncryptionType));
            EncryptionTypeLst.Items.AddRange(types);

            EncryptionTypeLst.SelectedIndexChanged += EncryptionTypeLst_SelectedIndexChanged;
            MethodLst.SelectedIndexChanged += MethodLst_SelectedIndexChanged;

            MethodLst.SelectedIndex = 0;
            EncryptionTypeLst.SelectedIndex = 1;

            TextEntryBox.TextChanged += TextEntryBox_TextChanged;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the MethodLst control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MethodLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsEncrypt = MethodLst.Text.ToLower() == "encrypt";
            UpdateResult();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the EncryptionTypeLst control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EncryptionTypeLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (EncryptionType)Enum.Parse(typeof(EncryptionType), EncryptionTypeLst.Text, true);
            Module = HaxxorFactory.GetByType(type);
            UpdateResult();
        }

        /// <summary>
        /// Handles the TextChanged event of the TextEntryBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextEntryBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        /// <summary>
        /// Updates the result.
        /// </summary>
        private void UpdateResult()
        {
            if (Module == default(IEncryptionModule))
            {
                return;
            }

            try
            {
                ResultBox.ForeColor = Color.Black;
                ResultBox.Text = IsEncrypt
                    ? Module.Encrypt(TextEntryBox.Text, false)
                    : Module.Decrypt(TextEntryBox.Text);
            }
            catch (Exception ex)
            {
                ResultBox.ForeColor = Color.Red;
                ResultBox.Text = ex.Message;
            }                
        }

    }
}
