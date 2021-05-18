
namespace Jumbo_Juice_Screen_Layout
{
    partial class Form2
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
            this.ingredientsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nutritionButton = new System.Windows.Forms.Button();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.OrderPanel = new System.Windows.Forms.Panel();
            this.juiceListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkoutPanel = new System.Windows.Forms.Panel();
            this.quantityComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enterLoyaltyButton = new System.Windows.Forms.Button();
            this.perksPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.submitPaymentutton = new System.Windows.Forms.Button();
            this.cardInfoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.totalCostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nutritionPanel = new System.Windows.Forms.Panel();
            this.proteinTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.carbsTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.fatsTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.caloriesTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.OrderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.checkoutPanel.SuspendLayout();
            this.perksPanel.SuspendLayout();
            this.nutritionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ingredientsCheckedListBox
            // 
            this.ingredientsCheckedListBox.FormattingEnabled = true;
            this.ingredientsCheckedListBox.Location = new System.Drawing.Point(10, 55);
            this.ingredientsCheckedListBox.Name = "ingredientsCheckedListBox";
            this.ingredientsCheckedListBox.Size = new System.Drawing.Size(297, 574);
            this.ingredientsCheckedListBox.TabIndex = 0;
            this.ingredientsCheckedListBox.Click += new System.EventHandler(this.ingredientsCheckedListBox_Click);
            this.ingredientsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ingredientsCheckedListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick 3 Ingredients!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pick Your Juice!";
            // 
            // nutritionButton
            // 
            this.nutritionButton.Location = new System.Drawing.Point(616, 304);
            this.nutritionButton.Name = "nutritionButton";
            this.nutritionButton.Size = new System.Drawing.Size(77, 157);
            this.nutritionButton.TabIndex = 5;
            this.nutritionButton.Text = "Check Nutrition Facts";
            this.nutritionButton.UseVisualStyleBackColor = true;
            this.nutritionButton.Click += new System.EventHandler(this.nutritionButton_Click);
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(617, 472);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(76, 157);
            this.checkoutButton.TabIndex = 6;
            this.checkoutButton.Text = "Finish and checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // OrderPanel
            // 
            this.OrderPanel.Controls.Add(this.exitButton);
            this.OrderPanel.Controls.Add(this.juiceListBox);
            this.OrderPanel.Controls.Add(this.ingredientsCheckedListBox);
            this.OrderPanel.Controls.Add(this.checkoutButton);
            this.OrderPanel.Controls.Add(this.label1);
            this.OrderPanel.Controls.Add(this.nutritionButton);
            this.OrderPanel.Controls.Add(this.label2);
            this.OrderPanel.Controls.Add(this.pictureBox1);
            this.OrderPanel.Location = new System.Drawing.Point(2, 2);
            this.OrderPanel.Name = "OrderPanel";
            this.OrderPanel.Size = new System.Drawing.Size(738, 701);
            this.OrderPanel.TabIndex = 7;
            // 
            // juiceListBox
            // 
            this.juiceListBox.FormattingEnabled = true;
            this.juiceListBox.Location = new System.Drawing.Point(312, 55);
            this.juiceListBox.Name = "juiceListBox";
            this.juiceListBox.Size = new System.Drawing.Size(297, 576);
            this.juiceListBox.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jumbo_Juice_Screen_Layout.Properties.Resources.smoothie;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 680);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // checkoutPanel
            // 
            this.checkoutPanel.Controls.Add(this.quantityComboBox);
            this.checkoutPanel.Controls.Add(this.label4);
            this.checkoutPanel.Controls.Add(this.enterLoyaltyButton);
            this.checkoutPanel.Controls.Add(this.perksPanel);
            this.checkoutPanel.Controls.Add(this.cancelButton);
            this.checkoutPanel.Controls.Add(this.label6);
            this.checkoutPanel.Controls.Add(this.submitPaymentutton);
            this.checkoutPanel.Controls.Add(this.cardInfoTextBox);
            this.checkoutPanel.Controls.Add(this.label5);
            this.checkoutPanel.Controls.Add(this.totalCostTextBox);
            this.checkoutPanel.Controls.Add(this.label3);
            this.checkoutPanel.Location = new System.Drawing.Point(2, 2);
            this.checkoutPanel.Name = "checkoutPanel";
            this.checkoutPanel.Size = new System.Drawing.Size(738, 701);
            this.checkoutPanel.TabIndex = 8;
            this.checkoutPanel.Visible = false;
            // 
            // quantityComboBox
            // 
            this.quantityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quantityComboBox.FormattingEnabled = true;
            this.quantityComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.quantityComboBox.Location = new System.Drawing.Point(166, 42);
            this.quantityComboBox.Name = "quantityComboBox";
            this.quantityComboBox.Size = new System.Drawing.Size(121, 21);
            this.quantityComboBox.TabIndex = 14;
            this.quantityComboBox.SelectedIndexChanged += new System.EventHandler(this.quantityComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "How many do you want?";
            // 
            // enterLoyaltyButton
            // 
            this.enterLoyaltyButton.Location = new System.Drawing.Point(8, 601);
            this.enterLoyaltyButton.Name = "enterLoyaltyButton";
            this.enterLoyaltyButton.Size = new System.Drawing.Size(155, 81);
            this.enterLoyaltyButton.TabIndex = 12;
            this.enterLoyaltyButton.Text = "Sign up for customer loyalty program";
            this.enterLoyaltyButton.UseVisualStyleBackColor = true;
            this.enterLoyaltyButton.Click += new System.EventHandler(this.enterLoyaltyButton_Click);
            // 
            // perksPanel
            // 
            this.perksPanel.BackColor = System.Drawing.Color.Yellow;
            this.perksPanel.Controls.Add(this.label14);
            this.perksPanel.Controls.Add(this.label13);
            this.perksPanel.Location = new System.Drawing.Point(372, 27);
            this.perksPanel.Name = "perksPanel";
            this.perksPanel.Size = new System.Drawing.Size(225, 138);
            this.perksPanel.TabIndex = 11;
            this.perksPanel.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(219, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "You save 15% for being a frequent customer!\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(62, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "JUICY PERKS";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(13, 354);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 585);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(455, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sign up for our customer loyalty program and save 15% on future orders through ou" +
    "r juicy perks!";
            // 
            // submitPaymentutton
            // 
            this.submitPaymentutton.Location = new System.Drawing.Point(13, 224);
            this.submitPaymentutton.Name = "submitPaymentutton";
            this.submitPaymentutton.Size = new System.Drawing.Size(135, 91);
            this.submitPaymentutton.TabIndex = 6;
            this.submitPaymentutton.Text = "Submit Payment";
            this.submitPaymentutton.UseVisualStyleBackColor = true;
            this.submitPaymentutton.Click += new System.EventHandler(this.submitPaymentutton_Click);
            // 
            // cardInfoTextBox
            // 
            this.cardInfoTextBox.Location = new System.Drawing.Point(27, 140);
            this.cardInfoTextBox.Name = "cardInfoTextBox";
            this.cardInfoTextBox.Size = new System.Drawing.Size(111, 20);
            this.cardInfoTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Credit Card Information";
            // 
            // totalCostTextBox
            // 
            this.totalCostTextBox.Location = new System.Drawing.Point(27, 43);
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.ReadOnly = true;
            this.totalCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalCostTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Cost";
            // 
            // nutritionPanel
            // 
            this.nutritionPanel.Controls.Add(this.proteinTextBox);
            this.nutritionPanel.Controls.Add(this.label12);
            this.nutritionPanel.Controls.Add(this.carbsTextBox);
            this.nutritionPanel.Controls.Add(this.label11);
            this.nutritionPanel.Controls.Add(this.fatsTextBox);
            this.nutritionPanel.Controls.Add(this.label10);
            this.nutritionPanel.Controls.Add(this.caloriesTextBox);
            this.nutritionPanel.Controls.Add(this.label9);
            this.nutritionPanel.Controls.Add(this.backButton);
            this.nutritionPanel.Controls.Add(this.label7);
            this.nutritionPanel.Controls.Add(this.pictureBox2);
            this.nutritionPanel.Location = new System.Drawing.Point(2, 2);
            this.nutritionPanel.Name = "nutritionPanel";
            this.nutritionPanel.Size = new System.Drawing.Size(738, 698);
            this.nutritionPanel.TabIndex = 9;
            // 
            // proteinTextBox
            // 
            this.proteinTextBox.Location = new System.Drawing.Point(541, 304);
            this.proteinTextBox.Name = "proteinTextBox";
            this.proteinTextBox.ReadOnly = true;
            this.proteinTextBox.Size = new System.Drawing.Size(100, 20);
            this.proteinTextBox.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(537, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Protein:";
            // 
            // carbsTextBox
            // 
            this.carbsTextBox.Location = new System.Drawing.Point(541, 145);
            this.carbsTextBox.Name = "carbsTextBox";
            this.carbsTextBox.ReadOnly = true;
            this.carbsTextBox.Size = new System.Drawing.Size(100, 20);
            this.carbsTextBox.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(537, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Carbs:";
            // 
            // fatsTextBox
            // 
            this.fatsTextBox.Location = new System.Drawing.Point(42, 304);
            this.fatsTextBox.Name = "fatsTextBox";
            this.fatsTextBox.ReadOnly = true;
            this.fatsTextBox.Size = new System.Drawing.Size(100, 20);
            this.fatsTextBox.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fats:";
            // 
            // caloriesTextBox
            // 
            this.caloriesTextBox.Location = new System.Drawing.Point(42, 145);
            this.caloriesTextBox.Name = "caloriesTextBox";
            this.caloriesTextBox.ReadOnly = true;
            this.caloriesTextBox.Size = new System.Drawing.Size(100, 20);
            this.caloriesTextBox.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Calories:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(8, 621);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 31);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nutrition Facts";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Jumbo_Juice_Screen_Layout.Properties.Resources.heart_shaped_fruits;
            this.pictureBox2.Location = new System.Drawing.Point(10, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 692);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(644, 17);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 704);
            this.Controls.Add(this.OrderPanel);
            this.Controls.Add(this.nutritionPanel);
            this.Controls.Add(this.checkoutPanel);
            this.Name = "Form2";
            this.Text = "Customer Order Form";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.OrderPanel.ResumeLayout(false);
            this.OrderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.checkoutPanel.ResumeLayout(false);
            this.checkoutPanel.PerformLayout();
            this.perksPanel.ResumeLayout(false);
            this.perksPanel.PerformLayout();
            this.nutritionPanel.ResumeLayout(false);
            this.nutritionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ingredientsCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nutritionButton;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Panel OrderPanel;
        private System.Windows.Forms.Panel checkoutPanel;
        private System.Windows.Forms.TextBox totalCostTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cardInfoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button submitPaymentutton;
        private System.Windows.Forms.Panel nutritionPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox proteinTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox carbsTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox fatsTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox caloriesTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox juiceListBox;
        private System.Windows.Forms.Panel perksPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button enterLoyaltyButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox quantityComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitButton;
    }
}