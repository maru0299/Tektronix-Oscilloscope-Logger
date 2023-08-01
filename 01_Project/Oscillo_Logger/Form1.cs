using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using System.IO;
using NationalInstruments.Visa;


namespace Oscillo_Logger
{
    public partial class Form1 : Form
    {
        //クラス変数
        //フラグ
        static bool addwrite_flag = false; //csv出力時、true=追記モード、false=上書きモード
        static bool Oscillo_Open = false;
        static bool Oscillo_ch1, Oscillo_ch2, Oscillo_ch3, Oscillo_ch4;
        //データ
        static double value1 = 0, value2 = 0, value3 = 0, value4 = 0; //オシロの測定値
        static string unit1, unit2, unit3, unit4; //オシロの単位
        static string type1, type2, type3, type4; //オシロのMeasureタイプ
        static int count; //カウンター
        //オシロ読み込み時の変数等
        private string lastResourceString = null;
        private MessageBasedSession mbSession;

        public Form1()
        {
            InitializeComponent();
        }

        //フォーム読み込み時
        private void Form1_Load(object sender, EventArgs e)
        {
            //ReadOnly,Enableの初期設定
            stop_button.Enabled = false;
            writeButton.Enabled = false;
            queryButton.Enabled = false;
            start_button.Enabled = false;
            writeTextBox.Visible = false;
            writeButton.Visible = false;
            QueryTextBox.Visible = false;
            queryButton.Visible = false;
            textBox_T.ReadOnly = true;
            textBox_M1.ReadOnly = true;
            textBox_M2.ReadOnly = true;
            textBox_M3.ReadOnly = true;
            textBox_M4.ReadOnly = true;
            readTextBox.ReadOnly = true;
            writeTextBox.ReadOnly = true;
            QueryTextBox.ReadOnly = true;
            textBox_endtime.ReadOnly = true;

            //チャートのリセット
            reset_chart();

            //デフォルト保存先フォルダをデスクトップに設定
            PATH_box.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //デフォルトファイル名を日付日時に設定
            DateTime dt = DateTime.Now;
            String name = dt.ToString($"{dt:yyMMddHHmm}");
            textBox_filename.Text = "OscilloLog_" + name;
        }

        //テキストボックスの数字とバックスペース以外の入力を無視する。
        //textBox_interval_KeyPressのKeyPressイベントハンドラ
        private void textBox_interval_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        //テキストボックスの数字とバックスペース以外の入力を無視する。
        //textBox_interval_KeyPressのKeyPressイベントハンドラ
        private void textBox_cycle_KeyPress(object sender,System.Windows.Forms.KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        //START LOG
        private void start_button_Click(object sender, EventArgs e)
        {
            lock_keys(true);
            set_default();

            //タイマー
            timer1.Interval = int.Parse(textBox_interval.Text) * 1000; //タイマー設定 [s]
            timer1.Enabled = true; //タイマースタート
            step_log(); //一回目のログ
        }

        //タイマーが一回進むごとに実行
        private void timer1_Tick(object sender, EventArgs e)
        {
            step_log();
        }

        //ログの取得 （テキストボックスに表示、グラフに描画、CSVに保存）
        private void step_log()
        {
            //カウント更新
            count += 1;

            //経過時間を保存、テキストボックスに表示。
            int time = int.Parse(textBox_interval.Text) * count;
            textBox_T.AppendText(time.ToString() +"s\r\n");

            //オシロの値を取得→テキストボックスとグラフに表示
            if (Oscillo_ch1 == true)
            {
                value1 = double.Parse(query_VISA("MEASUrement:MEAS1:VALue?"), System.Globalization.NumberStyles.Float); //値の取得とdouble型変換
                textBox_M1.AppendText(value1.ToString("F2") + unit1 + "\r\n"); //テキストボックスに表示
                chart1.Series["Measure1"].Points.AddXY(time, value1); //グラフに表示
                //横軸のスケール設定
                if (time >= 60)
                {
                    chart1.ChartAreas["Measure1"].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas["Measure1"].AxisX.Interval = 0;
                }
            }
            if (Oscillo_ch2 == true)
            {
                value2 = double.Parse(query_VISA("MEASUrement:MEAS2:VALue?"), System.Globalization.NumberStyles.Float);
                textBox_M2.AppendText(value2.ToString("F2") + unit2 + "\r\n");
                chart1.Series["Measure2"].Points.AddXY(time, value2);
                //横軸のスケール設定
                if (time >= 60)
                {
                    chart1.ChartAreas["Measure2"].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas["Measure2"].AxisX.Interval = 0;
                }
            }
            if (Oscillo_ch3 == true)
            {
                value3 = double.Parse(query_VISA("MEASUrement:MEAS3:VALue?"), System.Globalization.NumberStyles.Float);
                textBox_M3.AppendText(value3.ToString("F2") + unit3 + "\r\n");
                chart1.Series["Measure3"].Points.AddXY(time, value3);
                //横軸のスケール設定
                if (time >= 60)
                {
                    chart1.ChartAreas["Measure3"].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas["Measure3"].AxisX.Interval = 0;
                }
            }
            if (Oscillo_ch4 == true)
            {
                value4 = double.Parse(query_VISA("MEASUrement:MEAS4:VALue?"), System.Globalization.NumberStyles.Float);
                textBox_M4.AppendText(value4.ToString("F2") + unit4 + "\r\n");
                chart1.Series["Measure4"].Points.AddXY(time, value4);
                //横軸のスケール設定
                if (time >= 60)
                {
                    chart1.ChartAreas["Measure4"].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas["Measure4"].AxisX.Interval = 0;

                }
            }

            //CSVにデータを書き込み
            write_csv(time, value1, value2, value3, value4);

            //カウントがサイクル上限に達した時点で停止（サイクルが空欄の場合は停止するまで）
            if (textBox_cycle.Text != "" && count >= int.Parse(textBox_cycle.Text))
            {
                stop_log();
            }
        }

        //データ受信時 テキストボックスに値を表示
        //delegate void SetTextCallback(string text1, double num2, double num3, double num4, double num5);
        //private void Response(string text1, double num2, double num3, double num4, double num5) //(str, Vbat1, Vbat2, ntc1, ntc2)
        //{
        //    if (Box_RAW_log.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(Response);
        //        BeginInvoke(d, new object[] { text1, num2, num3, num4, num5 });
        //    }
        //    else
        //    {
        //        if (num2 == 999999) //エラーを受けたら改行だけ
        //        {
        //            Box_RAW_log.AppendText(text1 + "\n");
        //            Box_Vbat1.AppendText("\r\n");
        //            Box_Vbat2.AppendText("\r\n");
        //            Box_NTC1.AppendText("\r\n");
        //            Box_Temp1.AppendText("\r\n");
        //            Box_NTC2.AppendText("\r\n");
        //            Box_Temp2.AppendText("\r\n");
        //            Box_Current1.AppendText("\r\n");
        //        }
        //        else //UARTデータから値を計算して表示
        //        {
        //            Box_RAW_log.AppendText(text1 + "\n");
        //            Box_Vbat1.AppendText(num2.ToString("F2") + "V\r\n");
        //            Box_Vbat2.AppendText(num3.ToString("F2") + "V\r\n");

        //            int index4 = SearchIndex(num4); //NTC_V_arrayの中でnumに最も近い値をサーチしてインデックスをreturnさせる
        //            NTC_ohm1 = NTC_ohm_array[index4]; //返ってきたインデックスに対応した抵抗値
        //            NTC_temp1 = NTC_temp_array[index4]; //返ってきたインデックスに対応した温度
        //            Box_NTC1.AppendText(NTC_ohm1.ToString("F2") + "kΩ\r\n");
        //            Box_Temp1.AppendText(NTC_temp1.ToString("F2") + "℃\r\n");

        //            int index5 = SearchIndex(num5);
        //            NTC_ohm2 = NTC_ohm_array[index5];
        //            NTC_temp2 = NTC_temp_array[index5];
        //            Box_NTC2.AppendText(NTC_ohm2.ToString("F2") + "kΩ\r\n");
        //            Box_Temp2.AppendText(NTC_temp2.ToString("F2") + "℃\r\n");

        //            オシロの読み値を表示
        //            if (Oscillo_Open == true)
        //            {
        //                if (Oscillo_ch1 == true)
        //                {
        //                    double value1 = double.Parse(query_VISA("MEASUrement:MEAS1:VALue?"), System.Globalization.NumberStyles.Float); //値の取得とdouble型変換
        //                    string unit1 = query_VISA("MEASUrement:MEAS1:UNIts?").Replace("\"", ""); //単位を取得しダブルクオーテーションを削除
        //                    string text_c1 = value1.ToString("F2") + unit1;
        //                    Box_Current1.AppendText(text_c1); //テキストボックスに表示
        //                    chart1.Series["Current1"].Points.AddXY(count, value1); //グラフに表示
        //                }
        //                if (Oscillo_ch2 == true)
        //                {
        //                    double value2 = double.Parse(query_VISA("MEASUrement:MEAS2:VALue?"), System.Globalization.NumberStyles.Float); //値の取得とdouble型変換
        //                    string unit2 = query_VISA("MEASUrement:MEAS2:UNIts?").Replace("\"", ""); //単位を取得しダブルクオーテーションを削除
        //                    string text_c2 = value2.ToString("F2") + unit2;
        //                    Box_Current2.AppendText(text_c2); //テキストボックスに表示
        //                    chart1.Series["Current2"].Points.AddXY(count, value2); //グラフに表示
        //                }
        //            }

        //            グラフ描画
        //            chart1.Series["Vbat1"].Points.AddXY(count, num2);
        //            chart1.Series["Vbat2"].Points.AddXY(count, num3);
        //            chart1.Series["Temp1"].Points.AddXY(count, NTC_temp1);
        //            chart1.Series["Temp2"].Points.AddXY(count, NTC_temp2);

        //            横軸のスケール設定
        //            if (count >= 60 && count % 10 == 0)
        //            {
        //                chart1.ChartAreas["Area_Vbat"].AxisX.Maximum += 10;
        //                chart1.ChartAreas["Area_Temp"].AxisX.Maximum += 10;
        //                chart1.ChartAreas["Area_Current"].AxisX.Maximum += 10;
        //                if (chart1.ChartAreas["Area_Vbat"].AxisX.Maximum / chart1.ChartAreas["Area_Vbat"].AxisX.Interval >= 12)
        //                {
        //                    chart1.ChartAreas["Area_Vbat"].AxisX.Interval *= 2;
        //                    chart1.ChartAreas["Area_Temp"].AxisX.Interval *= 2;
        //                    chart1.ChartAreas["Area_Current"].AxisX.Interval *= 2;

        //                }
        //            }

        //        }
        //    }
        //}

        //データ受信時
        //private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    string str = serialPort1.ReadLine(); //読み込み
        //    string[] array = str.Split(new[] { ',', '\r' }); //分割
        //    double current1, current2;
        //    count += 1;

        //    if (str == "[NTC1],[BAT1],[NTC2],[BAT2]\r") //←が入力されたら0表示
        //    {
        //        Response(str, 999999, 0, 0, 0); //エラー渡し
        //        write_csv(true, array, 0, 0); //CSVに空欄改行を書き込み

        //    }
        //    else //ADポート読み値を電圧に変換する。（Vbatは抵抗分圧で1/2されているので戻しておく） エクセルで求めた近似直線で計算。y=0.003226x+0.006803
        //    {
        //        ntc1 = double.Parse(array[0]) * 0.003226 + 0.006803;
        //        Vbat1 = Math.Round((double.Parse(array[1]) * 0.003226 + 0.006803) * 2, 2, MidpointRounding.AwayFromZero);
        //        ntc2 = double.Parse(array[2]) * 0.003226 + 0.006803;
        //        Vbat2 = Math.Round((double.Parse(array[3]) * 0.003226 + 0.006803) * 2, 2, MidpointRounding.AwayFromZero);

        //        オシロの値を読み取り 電流プローブが接続されていない場合はゼロにする
        //        if (Oscillo_Open == true)
        //        {
        //            current1 = double.Parse(query_VISA("MEASUrement:MEAS1:VALue?"), System.Globalization.NumberStyles.Float); //値の取得とdouble型変換
        //            current2 = double.Parse(query_VISA("MEASUrement:MEAS2:VALue?"), System.Globalization.NumberStyles.Float); //値の取得とdouble型変換
        //            if (Oscillo_ch1 == false)
        //            {
        //                current1 = 0;
        //            }
        //            if (Oscillo_ch2 == false)
        //            {
        //                current2 = 0;
        //            }
        //        }
        //        else
        //        {
        //            current1 = 0;
        //            current2 = 0;
        //        }

        //        Response(str, Vbat1, Vbat2, ntc1, ntc2); //テキストボックスにそれぞれ表示
        //        write_csv(false, array, current1, current2); //CSVにデータを書き込み
        //    }
        //}

        //終了
        private void stop_button_Click(object sender, EventArgs e)
        {
            stop_log();
        }

        // PATHボタンクリックでファイルの参照（csv書き出し用）
        private void PATH_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // ダイアログのタイトル
                openFileDialog.Title = "フォルダを選択してください。";
                // デフォルトのフォルダ
                openFileDialog.InitialDirectory = PATH_box.Text;
                // ダイアログボックスに表示する文字列
                openFileDialog.FileName = "SelectFolder";
                // フォルダのみを表示
                openFileDialog.Filter = "Folder|.";
                // 存在しないファイル指定時の警告
                openFileDialog.CheckFileExists = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PATH_box.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //終了時間のアップデート（テキストボックスに値が入力されたとき）
        private void update_endtime(object sender, EventArgs e)
        {
            if (textBox_cycle.Text == "")
            {
                textBox_endtime.Text = "Until it stops";
            }
            else
            {
                double hour = double.Parse(textBox_interval.Text) * (double.Parse(textBox_cycle.Text)) / 3600;
                textBox_endtime.Text = hour.ToString();
            }
        }

        //グラフをダブルクリックで画像をクリップボードに保存
        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Png);
                Bitmap pn = new Bitmap(ms);
                Clipboard.SetImage(pn);
            }
        }

        //［関数］初期化
        private void set_default()
        {
            //STOPボタンを有効化
            start_button.Enabled = false;
            stop_button.Enabled = true;

            //カウントの初期化
            count = -1;

            //テキストボックスをリセット
            Reset_textBox();

            //チェックボックスの状態を確認し、ログするmeasureチャンネルを決定。
            Oscillo_ch1 = Convert.ToBoolean(int.Parse(query_VISA("MEASUrement:MEAS1:STATE?")));
            Oscillo_ch2 = Convert.ToBoolean(int.Parse(query_VISA("MEASUrement:MEAS2:STATE?")));
            Oscillo_ch3 = Convert.ToBoolean(int.Parse(query_VISA("MEASUrement:MEAS3:STATE?")));
            Oscillo_ch4 = Convert.ToBoolean(int.Parse(query_VISA("MEASUrement:MEAS4:STATE?")));

            //単位の取得
            unit1 = query_VISA("MEASUrement:MEAS1:UNIts?").Replace("\"", "").Replace("\n", ""); //ダブルクオーテーションと改行を削除
            unit2 = query_VISA("MEASUrement:MEAS2:UNIts?").Replace("\"", "").Replace("\n", "");
            unit3 = query_VISA("MEASUrement:MEAS3:UNIts?").Replace("\"", "").Replace("\n", "");
            unit4 = query_VISA("MEASUrement:MEAS4:UNIts?").Replace("\"", "").Replace("\n", "");

            //タイプの取得
            type1 = query_VISA("MEASUrement:MEAS1:TYPe?").Replace("\n", ""); //改行を削除
            type2 = query_VISA("MEASUrement:MEAS2:TYPe?").Replace("\n", "");
            type3 = query_VISA("MEASUrement:MEAS3:TYPe?").Replace("\n", "");
            type4 = query_VISA("MEASUrement:MEAS4:TYPe?").Replace("\n", "");

            //チャートのリセット
            reset_chart();

            //チャートのセット,テキストボックスの表示設定
            if (Oscillo_ch1 == true)
            {
                set_chart("Measure1", type1 + "[" + unit1 + "]");
                label_M1.Visible = true;
                textBox_M1.Visible = true;
            }
            else
            {
                label_M1.Visible = false;
                textBox_M1.Visible = false;
            }
            if (Oscillo_ch2 == true)
            {
                set_chart("Measure2", type2 + "[" + unit2 + "]");
                label_M2.Visible = true;
                textBox_M2.Visible = true;
            }
            else 
            {
                label_M2.Visible = false;
                textBox_M2.Visible = false;
            }
            if (Oscillo_ch3 == true)
            {
                set_chart("Measure3", type3 + "[" + unit3 + "]");
                label_M3.Visible = true;
                textBox_M3.Visible = true;
            }
            else 
            {
                label_M3.Visible = false;
                textBox_M3.Visible = false;
            }
            if (Oscillo_ch4 == true)
            {
                set_chart("Measure4", type4 + "[" + unit4 + "]");
                label_M3.Visible = true;
                textBox_M3.Visible = true;
            }
            else 
            {
                label_M4.Visible = false;
                textBox_M4.Visible = false;
            }
        }

        //［関数］チャートのセット
        private void set_chart(string name, string Ytitle)
        {
            //エリアを作成
            chart1.ChartAreas.Add(new ChartArea(name));
            chart1.ChartAreas[name].AxisX.Title = "Elapsed Time[s]";
            chart1.ChartAreas[name].AxisY.Title = Ytitle;
            chart1.ChartAreas[name].AxisX.Maximum = 60;
            chart1.ChartAreas[name].AxisX.Minimum = 0;
            chart1.ChartAreas[name].AxisX.Interval = 10;
            chart1.ChartAreas[name].AxisX.MajorGrid.LineColor = Color.FromName("lightgray");
            chart1.ChartAreas[name].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[name].AxisX.MinorGrid.Interval = 1;
            chart1.ChartAreas[name].AxisX.MinorGrid.LineColor = Color.FromName("gainsboro");
            chart1.ChartAreas[name].AxisY.Maximum = double.NaN;
            chart1.ChartAreas[name].AxisY.Minimum = double.NaN;
            chart1.ChartAreas[name].AxisY.Interval = double.NaN;
            chart1.ChartAreas[name].AxisY.MajorGrid.LineColor = Color.FromName("lightgray");
            chart1.ChartAreas[name].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[name].AxisY.MinorGrid.Interval = double.NaN;
            chart1.ChartAreas[name].AxisY.MinorGrid.LineColor = Color.FromName("gainsboro");

            //系列を追加
            chart1.Series.Add(name);
            chart1.Series[name].ChartType = SeriesChartType.Line;
            chart1.Series[name].Color = Color.FromName("darkblue");
            chart1.Series[name].ChartArea = name;
        }

        //［関数］チャートのリセット
        private void reset_chart()
        {
            //クリア
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
        }

        //［関数］ログの停止
        private void stop_log()
        {
            timer1.Enabled = false; //タイマーストップ
            lock_keys(false);
            addwrite_flag = false;
        }

        //［関数］テキストボックスをすべてリセット
        private void Reset_textBox()
        {
            textBox_T.ResetText();
            textBox_M1.ResetText();
            textBox_M2.ResetText();
            textBox_M3.ResetText();
            textBox_M4.ResetText();
        }

        //［関数］スタート・ストップボタンのロック
        private void lock_keys(bool sw)
        {
            start_button.Enabled = !sw;
            stop_button.Enabled = sw;
        }

        //［関数］CSVに書き込み
        private void write_csv(int counter, double num1, double num2, double num3, double num4)
        {
            if (PATH_box.Text != "" && textBox_filename.Text != "") //csv出力 （PATHが空でないとき）
            {
                //値をセット
                string value1 = "", value2 = "", value3 = "", value4 = "";
                if (Oscillo_ch1 == true)
                {
                    value1 = num1.ToString("F2");
                }
                if (Oscillo_ch2 == true)
                {
                    value2 = num2.ToString("F2");
                }
                if (Oscillo_ch3 == true)
                {
                    value3 = num3.ToString("F2");
                }
                if (Oscillo_ch4 == true)
                {
                    value4 = num4.ToString("F2");
                }
                string write_str = string.Join(",", counter.ToString("F0"), value1, value2, value3, value4);

                //書き込み先のフルパスをセット
                string full_path;
                if (textBox_filename.Text.Contains(".csv") == true)
                {
                    full_path = PATH_box.Text + "\\" + textBox_filename.Text;
                }
                else
                {
                    full_path = PATH_box.Text + "\\" + textBox_filename.Text + ".csv";
                }

                //書き込みストリームをnew
                StreamWriter file = new StreamWriter(full_path, addwrite_flag, Encoding.UTF8);

                //1回目の書き込み時⇒上書きモードでヘッダを入力
                if (addwrite_flag == false)
                {
                    addwrite_flag = true;
                    string header1 = "", header2 = "", header3 = "", header4 = "";

                    //ヘッダの作成
                    if(Oscillo_ch1 == true)
                    {
                        header1 = type1 + "[" + unit1 + "]";
                    }
                    if (Oscillo_ch2 == true)
                    {
                        header2 = type2 + "[" + unit2 + "]";
                    }
                    if(Oscillo_ch3 == true)
                    {
                        header3 = type3 + "[" + unit3 + "]";
                    }
                    if (Oscillo_ch4 == true)
                    {
                        header4 = type4 + "[" + unit4 + "]";
                    }
                    //ヘッダの書き込み
                    file.Write(string.Join(",", "", "Measure1", "Measure2", "Measure3", "Measure4") + "\r\n");
                    file.Write(string.Join(",", "Elapsed Time[s]", header1, header2, header3, header4) + "\r\n");
                    //値の書き込み
                    file.Write(write_str + "\r\n");
                }
                else
                {
                    //値の書き込み
                    file.Write(write_str + "\r\n");
                }
                file.Close();
            }
        }



        // tektronix NI-VISA control 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void button_OpenSession_Click(object sender, EventArgs e)
        {
            Reset_textBox();
            using (SelectResource sr = new SelectResource())
            {
                DialogResult result = sr.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;
                    //Cursor.Current = Cursors.WaitCursor;
                    using (var rmSession = new ResourceManager())
                    {
                        try
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(sr.ResourceName);
                            //SetupControlState(true);
                            Oscillo_Open = true;
                            start_button.Enabled = true;
                            Lock_Oscillo_Control(false);
                            readTextBox.Text = query_VISA("*IDN?");
                        }
                        catch (InvalidCastException)
                        {
                            MessageBox.Show("Resource selected must be a message-based session");
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            //Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            readTextBox.Text = String.Empty;
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                string textToWrite = QueryTextBox.Text;
                readTextBox.Text = query_VISA(textToWrite);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                //Cursor.Current = Cursors.Default;
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string textToWrite = writeTextBox.Text;
                mbSession.RawIO.Write(textToWrite);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        // 待機
        private async void Wait()
        {
            await Task.Delay(10);
        }

        //［関数］クエリ
        private string query_VISA(string command)
        {
            if(Oscillo_Open == true)
            {
                string textToWrite = command;
                mbSession.RawIO.Write(textToWrite + "\n");
                Wait();
                return mbSession.RawIO.ReadString();
            }
            else
            {
                return null;
            }
        }

        //オシロコマンド詳細表示
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            writeTextBox.Visible = checkBox1.Checked;
            writeButton.Visible = checkBox1.Checked;
            QueryTextBox.Visible = checkBox1.Checked;
            queryButton.Visible = checkBox1.Checked;
        }

        //［関数］オシロ関係ボタン等のロック
        //true→ロック、false→アンロック
        private void Lock_Oscillo_Control(bool sw)
        {
            writeButton.Enabled = !sw;
            queryButton.Enabled = !sw;
            writeTextBox.ReadOnly = sw;
            QueryTextBox.ReadOnly = sw;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
