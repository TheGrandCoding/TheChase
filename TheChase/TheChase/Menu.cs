﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheChase
{
    public partial class Menu : Form
    {
        public static Menu INSTANCE;
        public static Client.MainClient CLIENT;
        public static Server.Server SERVER;

        void checkButtons()
        {
            btnClient.Enabled = CLIENT == null;
            btnServer.Enabled = SERVER == null && CLIENT == null;
            btnClient.BackColor = SERVER == null ? Color.FromKnownColor(KnownColor.Control) : Color.OrangeRed;
            btnClient.Text = SERVER == null ? "Join a Game" : "Client CoI";
            // Since the Server will need to verify moneybuilder questions, they cannot be part of the game
            // hence: If Client, no Server
            //        If Server, no Client
        }

        public Menu()
        {
            InitializeComponent();
            INSTANCE = this;
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            SERVER = new Server.Server();
            SERVER.Show();
        }

        private void Menu_Activated(object sender, EventArgs e)
        {
            checkButtons();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            CLIENT = new Client.MainClient();
            CLIENT.Show();
            this.Hide();
        }
    }
}
