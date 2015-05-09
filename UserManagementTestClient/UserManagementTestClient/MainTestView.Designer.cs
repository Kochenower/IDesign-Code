namespace UserManagementTestClient
{
    partial class MainTestView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label threadsLabel;
            System.Windows.Forms.Label iterationsLabel;
            this._UsersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_ThreadsTextBox = new System.Windows.Forms.TextBox();
            this.m_IterationsTextBox = new System.Windows.Forms.TextBox();
            this.btnStressTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnAccountUnlock = new System.Windows.Forms.Button();
            this.btnAccountLock = new System.Windows.Forms.Button();
            this.btnInvalidCredentials = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this._ActivityListView = new System.Windows.Forms.ListView();
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            threadsLabel = new System.Windows.Forms.Label();
            iterationsLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // threadsLabel
            // 
            threadsLabel.AutoSize = true;
            threadsLabel.Location = new System.Drawing.Point(26, 48);
            threadsLabel.Name = "threadsLabel";
            threadsLabel.Size = new System.Drawing.Size(49, 13);
            threadsLabel.TabIndex = 18;
            threadsLabel.Text = "Threads:";
            // 
            // iterationsLabel
            // 
            iterationsLabel.AutoSize = true;
            iterationsLabel.Location = new System.Drawing.Point(26, 22);
            iterationsLabel.Name = "iterationsLabel";
            iterationsLabel.Size = new System.Drawing.Size(53, 13);
            iterationsLabel.TabIndex = 17;
            iterationsLabel.Text = "Iterations:";
            // 
            // _UsersListView
            // 
            this._UsersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._UsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this._UsersListView.FullRowSelect = true;
            this._UsersListView.GridLines = true;
            this._UsersListView.HideSelection = false;
            this._UsersListView.Location = new System.Drawing.Point(249, 36);
            this._UsersListView.MultiSelect = false;
            this._UsersListView.Name = "_UsersListView";
            this._UsersListView.Size = new System.Drawing.Size(524, 182);
            this._UsersListView.TabIndex = 2;
            this._UsersListView.UseCompatibleStateImageBehavior = false;
            this._UsersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First Name";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Name";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Locked";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Failed Attempts";
            this.columnHeader5.Width = 87;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date Password Changed";
            this.columnHeader6.Width = 141;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.editToolStripMenuItem.Text = "&Users";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.loginToolStripMenuItem.Text = "&Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItemClick);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(110, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(threadsLabel);
            this.groupBox1.Controls.Add(iterationsLabel);
            this.groupBox1.Controls.Add(this.m_ThreadsTextBox);
            this.groupBox1.Controls.Add(this.m_IterationsTextBox);
            this.groupBox1.Controls.Add(this.btnStressTest);
            this.groupBox1.Location = new System.Drawing.Point(12, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stress Test";
            // 
            // m_ThreadsTextBox
            // 
            this.m_ThreadsTextBox.Location = new System.Drawing.Point(104, 45);
            this.m_ThreadsTextBox.MaxLength = 5;
            this.m_ThreadsTextBox.Name = "m_ThreadsTextBox";
            this.m_ThreadsTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_ThreadsTextBox.TabIndex = 16;
            this.m_ThreadsTextBox.Text = "CPU count";
            // 
            // m_IterationsTextBox
            // 
            this.m_IterationsTextBox.Location = new System.Drawing.Point(104, 19);
            this.m_IterationsTextBox.MaxLength = 5;
            this.m_IterationsTextBox.Name = "m_IterationsTextBox";
            this.m_IterationsTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_IterationsTextBox.TabIndex = 15;
            this.m_IterationsTextBox.Text = "100";
            // 
            // btnStressTest
            // 
            this.btnStressTest.Location = new System.Drawing.Point(6, 71);
            this.btnStressTest.Name = "btnStressTest";
            this.btnStressTest.Size = new System.Drawing.Size(219, 23);
            this.btnStressTest.TabIndex = 14;
            this.btnStressTest.Text = "Go!";
            this.btnStressTest.UseVisualStyleBackColor = true;
            this.btnStressTest.Click += new System.EventHandler(this.StressTestClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteAccount);
            this.groupBox2.Controls.Add(this.btnCreateAccount);
            this.groupBox2.Controls.Add(this.btnGetUsers);
            this.groupBox2.Controls.Add(this.btnPassword);
            this.groupBox2.Controls.Add(this.btnAccountUnlock);
            this.groupBox2.Controls.Add(this.btnAccountLock);
            this.groupBox2.Controls.Add(this.btnInvalidCredentials);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 259);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tests";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(6, 227);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(219, 23);
            this.btnDeleteAccount.TabIndex = 15;
            this.btnDeleteAccount.Text = "Delete Account";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.DeleteAccountClick);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(6, 53);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(219, 23);
            this.btnCreateAccount.TabIndex = 14;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.CreateAccountClick);
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Location = new System.Drawing.Point(6, 24);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(219, 23);
            this.btnGetUsers.TabIndex = 13;
            this.btnGetUsers.Text = "Get Accounts";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.GetUsersClick);
            // 
            // btnPassword
            // 
            this.btnPassword.Location = new System.Drawing.Point(6, 198);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(219, 23);
            this.btnPassword.TabIndex = 12;
            this.btnPassword.Text = "Password Strength";
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnPassword.Click += new System.EventHandler(this.PasswordClick);
            // 
            // btnAccountUnlock
            // 
            this.btnAccountUnlock.Location = new System.Drawing.Point(6, 169);
            this.btnAccountUnlock.Name = "btnAccountUnlock";
            this.btnAccountUnlock.Size = new System.Drawing.Size(219, 23);
            this.btnAccountUnlock.TabIndex = 11;
            this.btnAccountUnlock.Text = "Account Unlock";
            this.btnAccountUnlock.UseVisualStyleBackColor = true;
            this.btnAccountUnlock.Click += new System.EventHandler(this.AccountUnlockClick);
            // 
            // btnAccountLock
            // 
            this.btnAccountLock.Location = new System.Drawing.Point(6, 140);
            this.btnAccountLock.Name = "btnAccountLock";
            this.btnAccountLock.Size = new System.Drawing.Size(219, 23);
            this.btnAccountLock.TabIndex = 10;
            this.btnAccountLock.Text = "Account Lock";
            this.btnAccountLock.UseVisualStyleBackColor = true;
            this.btnAccountLock.Click += new System.EventHandler(this.AccountLockClick);
            // 
            // btnInvalidCredentials
            // 
            this.btnInvalidCredentials.Location = new System.Drawing.Point(6, 111);
            this.btnInvalidCredentials.Name = "btnInvalidCredentials";
            this.btnInvalidCredentials.Size = new System.Drawing.Size(219, 23);
            this.btnInvalidCredentials.TabIndex = 9;
            this.btnInvalidCredentials.Text = "Invalid Credentials";
            this.btnInvalidCredentials.UseVisualStyleBackColor = true;
            this.btnInvalidCredentials.Click += new System.EventHandler(this.InvalidCredentialsClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(6, 82);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(219, 23);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.LoginClick);
            // 
            // _ActivityListView
            // 
            this._ActivityListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ActivityListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Result,
            this.columnHeader7,
            this.columnHeader8});
            this._ActivityListView.FullRowSelect = true;
            this._ActivityListView.GridLines = true;
            this._ActivityListView.HideSelection = false;
            this._ActivityListView.Location = new System.Drawing.Point(249, 239);
            this._ActivityListView.MultiSelect = false;
            this._ActivityListView.Name = "_ActivityListView";
            this._ActivityListView.Size = new System.Drawing.Size(524, 322);
            this._ActivityListView.TabIndex = 9;
            this._ActivityListView.UseCompatibleStateImageBehavior = false;
            this._ActivityListView.View = System.Windows.Forms.View.Details;
            // 
            // Result
            // 
            this.Result.Text = "Result";
            this.Result.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Activity";
            this.columnHeader7.Width = 220;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Reason";
            this.columnHeader8.Width = 300;
            // 
            // MainTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 573);
            this.Controls.Add(this._ActivityListView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._UsersListView);
            this.Name = "MainTestView";
            this.Text = "User Management Test Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _UsersListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStressTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnAccountUnlock;
        private System.Windows.Forms.Button btnAccountLock;
        private System.Windows.Forms.Button btnInvalidCredentials;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox m_ThreadsTextBox;
        private System.Windows.Forms.TextBox m_IterationsTextBox;
        private System.Windows.Forms.ListView _ActivityListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnDeleteAccount;

    }
}

