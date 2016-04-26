namespace Gasp
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.serialPortSensor = new System.IO.Ports.SerialPort(this.components);
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.gauTemperature = new System.Windows.Forms.AGauge();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxNow = new System.Windows.Forms.GroupBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.gbxSymptom = new System.Windows.Forms.GroupBox();
            this.pnlSeverity = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.imlSymptoms = new System.Windows.Forms.ImageList(this.components);
            this.radSymptomMedium = new System.Windows.Forms.RadioButton();
            this.radSymptomMild = new System.Windows.Forms.RadioButton();
            this.btnReportSymptom = new System.Windows.Forms.Button();
            this.radWheezing = new System.Windows.Forms.RadioButton();
            this.radSneezing = new System.Windows.Forms.RadioButton();
            this.radShortnessOfBreath = new System.Windows.Forms.RadioButton();
            this.radNasalObstruction = new System.Windows.Forms.RadioButton();
            this.radItchyEyes = new System.Windows.Forms.RadioButton();
            this.radCoughing = new System.Windows.Forms.RadioButton();
            this.gbxNow.SuspendLayout();
            this.gbxHistory.SuspendLayout();
            this.gbxSymptom.SuspendLayout();
            this.pnlSeverity.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortSensor
            // 
            this.serialPortSensor.PortName = "COM4";
            this.serialPortSensor.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortSensor_DataReceived);
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(163, 256);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(97, 25);
            this.lblTemperature.TabIndex = 2;
            this.lblTemperature.Text = "                 ";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumidity.Location = new System.Drawing.Point(163, 297);
            this.lblHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(72, 25);
            this.lblHumidity.TabIndex = 3;
            this.lblHumidity.Text = "            ";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(163, 338);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(94, 25);
            this.lblLatitude.TabIndex = 4;
            this.lblLatitude.Text = "Unknown";
            // 
            // gauTemperature
            // 
            this.gauTemperature.BackColor = System.Drawing.SystemColors.Control;
            this.gauTemperature.BaseArcColor = System.Drawing.Color.Gray;
            this.gauTemperature.BaseArcRadius = 80;
            this.gauTemperature.BaseArcStart = 135;
            this.gauTemperature.BaseArcSweep = 270;
            this.gauTemperature.BaseArcWidth = 2;
            this.gauTemperature.Center = new System.Drawing.Point(100, 100);
            this.gauTemperature.Location = new System.Drawing.Point(34, 36);
            this.gauTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.gauTemperature.MaxValue = 100F;
            this.gauTemperature.MinValue = -20F;
            this.gauTemperature.Name = "gauTemperature";
            this.gauTemperature.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.gauTemperature.NeedleColor2 = System.Drawing.Color.DimGray;
            this.gauTemperature.NeedleRadius = 80;
            this.gauTemperature.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.gauTemperature.NeedleWidth = 2;
            this.gauTemperature.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.gauTemperature.ScaleLinesInterInnerRadius = 73;
            this.gauTemperature.ScaleLinesInterOuterRadius = 80;
            this.gauTemperature.ScaleLinesInterWidth = 1;
            this.gauTemperature.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.gauTemperature.ScaleLinesMajorInnerRadius = 70;
            this.gauTemperature.ScaleLinesMajorOuterRadius = 80;
            this.gauTemperature.ScaleLinesMajorStepValue = 10F;
            this.gauTemperature.ScaleLinesMajorWidth = 2;
            this.gauTemperature.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.gauTemperature.ScaleLinesMinorInnerRadius = 75;
            this.gauTemperature.ScaleLinesMinorOuterRadius = 80;
            this.gauTemperature.ScaleLinesMinorTicks = 9;
            this.gauTemperature.ScaleLinesMinorWidth = 1;
            this.gauTemperature.ScaleNumbersColor = System.Drawing.Color.Black;
            this.gauTemperature.ScaleNumbersFormat = null;
            this.gauTemperature.ScaleNumbersRadius = 95;
            this.gauTemperature.ScaleNumbersRotation = 0;
            this.gauTemperature.ScaleNumbersStartScaleLine = 0;
            this.gauTemperature.ScaleNumbersStepScaleLines = 1;
            this.gauTemperature.Size = new System.Drawing.Size(226, 198);
            this.gauTemperature.TabIndex = 5;
            this.gauTemperature.Text = "Temperature";
            this.gauTemperature.Value = 20F;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "°C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 338);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Latitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Humidity";
            // 
            // gbxNow
            // 
            this.gbxNow.Controls.Add(this.lblLongitude);
            this.gbxNow.Controls.Add(this.label7);
            this.gbxNow.Controls.Add(this.label4);
            this.gbxNow.Controls.Add(this.lblHumidity);
            this.gbxNow.Controls.Add(this.label2);
            this.gbxNow.Controls.Add(this.lblTemperature);
            this.gbxNow.Controls.Add(this.label1);
            this.gbxNow.Controls.Add(this.lblLatitude);
            this.gbxNow.Controls.Add(this.label5);
            this.gbxNow.Controls.Add(this.gauTemperature);
            this.gbxNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxNow.Location = new System.Drawing.Point(12, 12);
            this.gbxNow.Name = "gbxNow";
            this.gbxNow.Size = new System.Drawing.Size(300, 425);
            this.gbxNow.TabIndex = 10;
            this.gbxNow.TabStop = false;
            this.gbxNow.Text = "Now";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(163, 377);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(94, 25);
            this.lblLongitude.TabIndex = 10;
            this.lblLongitude.Text = "Unknown";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 377);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Longitude";
            // 
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.txtHistory);
            this.gbxHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxHistory.Location = new System.Drawing.Point(727, 12);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(467, 425);
            this.gbxHistory.TabIndex = 11;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History";
            // 
            // txtHistory
            // 
            this.txtHistory.Location = new System.Drawing.Point(6, 21);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(455, 398);
            this.txtHistory.TabIndex = 0;
            // 
            // gbxSymptom
            // 
            this.gbxSymptom.Controls.Add(this.pnlSeverity);
            this.gbxSymptom.Controls.Add(this.btnReportSymptom);
            this.gbxSymptom.Controls.Add(this.radWheezing);
            this.gbxSymptom.Controls.Add(this.radSneezing);
            this.gbxSymptom.Controls.Add(this.radShortnessOfBreath);
            this.gbxSymptom.Controls.Add(this.radNasalObstruction);
            this.gbxSymptom.Controls.Add(this.radItchyEyes);
            this.gbxSymptom.Controls.Add(this.radCoughing);
            this.gbxSymptom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSymptom.Location = new System.Drawing.Point(318, 12);
            this.gbxSymptom.Name = "gbxSymptom";
            this.gbxSymptom.Size = new System.Drawing.Size(401, 425);
            this.gbxSymptom.TabIndex = 12;
            this.gbxSymptom.TabStop = false;
            this.gbxSymptom.Text = "Symptom";
            // 
            // pnlSeverity
            // 
            this.pnlSeverity.Controls.Add(this.radioButton1);
            this.pnlSeverity.Controls.Add(this.radSymptomMedium);
            this.pnlSeverity.Controls.Add(this.radSymptomMild);
            this.pnlSeverity.Location = new System.Drawing.Point(224, 25);
            this.pnlSeverity.Name = "pnlSeverity";
            this.pnlSeverity.Size = new System.Drawing.Size(171, 241);
            this.pnlSeverity.TabIndex = 17;
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton1.ImageIndex = 2;
            this.radioButton1.ImageList = this.imlSymptoms;
            this.radioButton1.Location = new System.Drawing.Point(9, 173);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(153, 56);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "2";
            this.radioButton1.Text = "Severe";
            this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // imlSymptoms
            // 
            this.imlSymptoms.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSymptoms.ImageStream")));
            this.imlSymptoms.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSymptoms.Images.SetKeyName(0, "symptom-mild.png");
            this.imlSymptoms.Images.SetKeyName(1, "symptom-medium.png");
            this.imlSymptoms.Images.SetKeyName(2, "symptom-severe.png");
            // 
            // radSymptomMedium
            // 
            this.radSymptomMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSymptomMedium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radSymptomMedium.ImageIndex = 1;
            this.radSymptomMedium.ImageList = this.imlSymptoms;
            this.radSymptomMedium.Location = new System.Drawing.Point(9, 92);
            this.radSymptomMedium.Name = "radSymptomMedium";
            this.radSymptomMedium.Size = new System.Drawing.Size(153, 56);
            this.radSymptomMedium.TabIndex = 14;
            this.radSymptomMedium.TabStop = true;
            this.radSymptomMedium.Tag = "2";
            this.radSymptomMedium.Text = "Medium";
            this.radSymptomMedium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radSymptomMedium.UseVisualStyleBackColor = true;
            // 
            // radSymptomMild
            // 
            this.radSymptomMild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSymptomMild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radSymptomMild.ImageIndex = 0;
            this.radSymptomMild.ImageList = this.imlSymptoms;
            this.radSymptomMild.Location = new System.Drawing.Point(9, 11);
            this.radSymptomMild.Name = "radSymptomMild";
            this.radSymptomMild.Size = new System.Drawing.Size(153, 56);
            this.radSymptomMild.TabIndex = 13;
            this.radSymptomMild.TabStop = true;
            this.radSymptomMild.Tag = "1";
            this.radSymptomMild.Text = "Mild";
            this.radSymptomMild.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radSymptomMild.UseVisualStyleBackColor = true;
            // 
            // btnReportSymptom
            // 
            this.btnReportSymptom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportSymptom.Location = new System.Drawing.Point(105, 307);
            this.btnReportSymptom.Name = "btnReportSymptom";
            this.btnReportSymptom.Size = new System.Drawing.Size(180, 66);
            this.btnReportSymptom.TabIndex = 16;
            this.btnReportSymptom.Text = "Report Symptom";
            this.btnReportSymptom.UseVisualStyleBackColor = true;
            this.btnReportSymptom.Click += new System.EventHandler(this.btnReportSymptom_Click);
            // 
            // radWheezing
            // 
            this.radWheezing.AutoSize = true;
            this.radWheezing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWheezing.Location = new System.Drawing.Point(14, 226);
            this.radWheezing.Name = "radWheezing";
            this.radWheezing.Size = new System.Drawing.Size(122, 29);
            this.radWheezing.TabIndex = 5;
            this.radWheezing.TabStop = true;
            this.radWheezing.Tag = "wheezing";
            this.radWheezing.Text = "Wheezing";
            this.radWheezing.UseVisualStyleBackColor = true;
            // 
            // radSneezing
            // 
            this.radSneezing.AutoSize = true;
            this.radSneezing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSneezing.Location = new System.Drawing.Point(13, 188);
            this.radSneezing.Name = "radSneezing";
            this.radSneezing.Size = new System.Drawing.Size(116, 29);
            this.radSneezing.TabIndex = 4;
            this.radSneezing.TabStop = true;
            this.radSneezing.Tag = "sneezing";
            this.radSneezing.Text = "Sneezing";
            this.radSneezing.UseVisualStyleBackColor = true;
            // 
            // radShortnessOfBreath
            // 
            this.radShortnessOfBreath.AutoSize = true;
            this.radShortnessOfBreath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShortnessOfBreath.Location = new System.Drawing.Point(13, 150);
            this.radShortnessOfBreath.Name = "radShortnessOfBreath";
            this.radShortnessOfBreath.Size = new System.Drawing.Size(205, 29);
            this.radShortnessOfBreath.TabIndex = 3;
            this.radShortnessOfBreath.TabStop = true;
            this.radShortnessOfBreath.Tag = "shortness-of-breath";
            this.radShortnessOfBreath.Text = "Shortness of Breath";
            this.radShortnessOfBreath.UseVisualStyleBackColor = true;
            // 
            // radNasalObstruction
            // 
            this.radNasalObstruction.AutoSize = true;
            this.radNasalObstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNasalObstruction.Location = new System.Drawing.Point(13, 112);
            this.radNasalObstruction.Name = "radNasalObstruction";
            this.radNasalObstruction.Size = new System.Drawing.Size(188, 29);
            this.radNasalObstruction.TabIndex = 2;
            this.radNasalObstruction.TabStop = true;
            this.radNasalObstruction.Tag = "nasal-obstruction";
            this.radNasalObstruction.Text = "Nasal Obstruction";
            this.radNasalObstruction.UseVisualStyleBackColor = true;
            // 
            // radItchyEyes
            // 
            this.radItchyEyes.AutoSize = true;
            this.radItchyEyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItchyEyes.Location = new System.Drawing.Point(13, 74);
            this.radItchyEyes.Name = "radItchyEyes";
            this.radItchyEyes.Size = new System.Drawing.Size(123, 29);
            this.radItchyEyes.TabIndex = 1;
            this.radItchyEyes.TabStop = true;
            this.radItchyEyes.Tag = "itchy-eyes";
            this.radItchyEyes.Text = "Itchy Eyes";
            this.radItchyEyes.UseVisualStyleBackColor = true;
            // 
            // radCoughing
            // 
            this.radCoughing.AutoSize = true;
            this.radCoughing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCoughing.Location = new System.Drawing.Point(13, 36);
            this.radCoughing.Name = "radCoughing";
            this.radCoughing.Size = new System.Drawing.Size(118, 29);
            this.radCoughing.TabIndex = 0;
            this.radCoughing.TabStop = true;
            this.radCoughing.Tag = "coughing";
            this.radCoughing.Text = "Coughing";
            this.radCoughing.UseVisualStyleBackColor = true;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 450);
            this.Controls.Add(this.gbxSymptom);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.gbxNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gasp! Monitoring Station";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.gbxNow.ResumeLayout(false);
            this.gbxNow.PerformLayout();
            this.gbxHistory.ResumeLayout(false);
            this.gbxHistory.PerformLayout();
            this.gbxSymptom.ResumeLayout(false);
            this.gbxSymptom.PerformLayout();
            this.pnlSeverity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPortSensor;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.AGauge gauTemperature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxNow;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbxSymptom;
        private System.Windows.Forms.Button btnReportSymptom;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ImageList imlSymptoms;
        private System.Windows.Forms.RadioButton radSymptomMedium;
        private System.Windows.Forms.RadioButton radSymptomMild;
        private System.Windows.Forms.RadioButton radWheezing;
        private System.Windows.Forms.RadioButton radSneezing;
        private System.Windows.Forms.RadioButton radShortnessOfBreath;
        private System.Windows.Forms.RadioButton radNasalObstruction;
        private System.Windows.Forms.RadioButton radItchyEyes;
        private System.Windows.Forms.RadioButton radCoughing;
        private System.Windows.Forms.Panel pnlSeverity;
    }
}

