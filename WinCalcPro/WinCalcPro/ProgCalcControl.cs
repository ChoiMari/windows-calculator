﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinCalcPro
{
    public partial class ProgCalcControl : UserControl
    {
        public ProgCalcControl()
        {
            InitializeComponent();
            // 10진수로
            btn_DEC_Click(this, EventArgs.Empty);

            // textBox_input의 TextChanged 이벤트에 핸들러 추가
            textBox_input.TextChanged += InputNumber_TextChanged;

            // textBox_input.KeyPress 이벤트에 핸들러 추가
            textBox_input.KeyPress += new KeyPressEventHandler(KeyPressFun);
        }
        /// <summary>
        /// 키보드 숫자만 입력 받도록 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPressFun(object sender, KeyPressEventArgs e)
        {
            // 키보드 입력 버튼으로 처리
            switch (e.KeyChar)
            {
                case '0':
                    btn_0_Click(sender, e);
                    break;
                case '1':
                    btn_1_Click(sender, e);
                    break;
                case '2':
                    btn_2_Click(sender, e);
                    break;
                case '3':
                    btn_3_Click(sender, e);
                    break;
                case '4':
                    btn_4_Click(sender, e);
                    break;
                case '5':
                    btn_5_Click(sender, e);
                    break;
                case '6':
                    btn_6_Click(sender, e);
                    break;
                case '7':
                    btn_7_Click(sender, e);
                    break;
                case '8':
                    btn_8_Click(sender, e);
                    break;
                case '9':
                    btn_9_Click(sender, e);
                    break;
                case '.':
                    btn_decimalPoint_Click(sender, e);
                    break;
                case '+':
                    btn_plus_Click(sender, e);
                    break;
                case '-':
                    btn_minus_Click(sender, e);
                    break;
                case '*':
                    btn_multiplication_Click(sender, e);
                    break;
                case '/':
                    btn_sharing_Click(sender, e);
                    break;
                case '(':
                    btn_openParentheses_Click(sender, e);
                    break;
                case ')':
                    btn_parenthesesEnd_Click(sender, e);
                    break;
                case '=':
                    btn_equal_Click(sender, e);
                    break;
                case (char)Keys.Back:
                    btn_back_Click(sender, e);
                    break;

                case (char)Keys.Enter:
                    btn_equal_Click(sender, e);
                    break;
                default:
                    break;
            }
        }
        

        private void InputNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 입력값이 유효한 정수인지 확인
                if (long.TryParse(textBox_input.Text, out long number))
                {
                    // 각 진수로 변환하여 텍스트 박스에 표시
                    textBox_HEX.Text = Convert.ToString(number, 16).ToUpper(); // 16진수
                    textBox_DEC.Text = Convert.ToString(number, 10);          // 10진수
                    textBox_OCT.Text = Convert.ToString(number, 8);           // 8진수
                    textBox_BIN.Text = Convert.ToString(number, 2);           // 2진수
                    // C를 CE로 변경
                    btn_clearAll.Text = "CE";
                }
                else
                {
                    // 유효하지 않은 입력일 경우 초기화
                    textBox_HEX.Text = string.Empty;
                    textBox_DEC.Text = string.Empty;
                    textBox_OCT.Text = string.Empty;
                    textBox_BIN.Text = string.Empty;
                }
                //앞에 0이 있으면 지우기
                if (textBox_input.Text.Length > 1 && textBox_input.Text.StartsWith("0"))
                {
                    textBox_input.Text = textBox_input.Text.Substring(1);
                }
            }
            catch (Exception ex)
            {
                // 예외 처리 (필요시 로그 추가)
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ProgrammerCalc pc = new ProgrammerCalc();
        decimal UserInput(string input)
        {
            decimal number;
            if (decimal.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                textBox_input.Text = "";
                return 0;
            }
        }


        private void btn_BEX_Click(object sender, EventArgs e)
        {
            // Abtn 활성화
            btn_A.Enabled = true;
            btn_B.Enabled = true;
            btn_C.Enabled = true;
            btn_D.Enabled = true;
            btn_E.Enabled = true;
            btn_F.Enabled = true;
            // 10진수 버튼 활성화
            btn_0.Enabled = true;
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            btn_7.Enabled = true;
            btn_8.Enabled = true;
            btn_9.Enabled = true;
        }

        private void btn_DEC_Click(object sender, EventArgs e)
        {
            // 10진수 버튼 활성화 및 16진수 버튼 비활성화
            btn_A.Enabled = false;
            btn_B.Enabled = false;
            btn_C.Enabled = false;
            btn_D.Enabled = false;
            btn_E.Enabled = false;
            btn_F.Enabled = false;
            btn_0.Enabled = true;
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            btn_7.Enabled = true;
            btn_8.Enabled = true;
            btn_9.Enabled = true;

        }

        private void btn_OCT_Click(object sender, EventArgs e)
        {
            // 8진수 버튼 활성화 및 16진수 버튼 비활성화
            btn_A.Enabled = false;
            btn_B.Enabled = false;
            btn_C.Enabled = false;
            btn_D.Enabled = false;
            btn_E.Enabled = false;
            btn_F.Enabled = false;
            btn_0.Enabled = true;
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            btn_7.Enabled = true;
            btn_8.Enabled = false;
            btn_9.Enabled = false;



        }

        private void btn_BIN_Click(object sender, EventArgs e)
        {
            btn_A.Enabled = false;
            btn_B.Enabled = false;
            btn_C.Enabled = false;
            btn_D.Enabled = false;
            btn_E.Enabled = false;
            btn_F.Enabled = false;
            btn_0.Enabled = true;
            btn_1.Enabled = true;
            btn_2.Enabled = false;
            btn_3.Enabled = false;
            btn_4.Enabled = false;
            btn_5.Enabled = false;
            btn_6.Enabled = false;
            btn_7.Enabled = false;
            btn_8.Enabled = false;
            btn_9.Enabled = false;

        }

        private void btn_A_Click(object sender, EventArgs e)
        {
            // 16진수 A 10
            textBox_input.Text += 0xA;

        }

        private void btn_leftShift_Click(object sender, EventArgs e)
        {
            //<< 가 있으면 연산
            if(textBox_preview.Text.Contains("<<"))
            {
                var parts = textBox_preview.Text.Split(new[] { "<<" }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    long result = pc.Left(long.Parse(parts[0]), int.Parse(textBox_input.Text));
                    textBox_input.Text = result.ToString();
                    textBox_preview.Text = "";
                }
            }
            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text = textBox_input.Text + " << " + textBox_preview.Text;
                textBox_input.Text = "";
            }

        }

        private void btn_rightShift_Click(object sender, EventArgs e)
        {
            //>> 가 있으면 연산
            if (textBox_preview.Text.Contains(">>"))
            {
                var parts = textBox_preview.Text.Split(new[] { ">>" }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    long result = pc.Right(long.Parse(parts[0]), int.Parse(textBox_input.Text));
                    textBox_input.Text = result.ToString();
                    textBox_preview.Text = "";
                }
            }

            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text = textBox_input.Text + " >> " + textBox_preview.Text;
                textBox_input.Text = "";
            }

        }

        private void btn_clearAll_Click(object sender, EventArgs e)
        {
            if (textBox_input.Text.Length > 0 && textBox_preview.Text.Length > 0)
            {
                textBox_input.Text = "";
                btn_clearAll.Text = "C";
            }
            else if (btn_clearAll.Text == "C")
            {
                textBox_input.Text = "";
                textBox_preview.Text = "";
            }
            else
            {
                textBox_input.Text = "";
                textBox_preview.Text = "";
                btn_clearAll.Text = "C";
            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // 뒤로 한 글자 지우기
            if (textBox_input.Text.Length > 0)
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 1);
            }

        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            textBox_input.Text += 0xB;

        }

        private void btn_openParentheses_Click(object sender, EventArgs e)
        {
            textBox_input.Text = "";
            textBox_preview.Text += "(";

        }

        private void btn_parenthesesEnd_Click(object sender, EventArgs e)
        {
            textBox_preview.Text += textBox_input.Text + ")";
            textBox_input.Text = "";

        }

        private void btn_percent_Click(object sender, EventArgs e)
        {
            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text = textBox_input.Text + " % " + textBox_preview.Text;
                textBox_input.Text = "";
            }

        }

        private void btn_sharing_Click(object sender, EventArgs e)
        {
            // /가 있으면 연산
            if (textBox_preview.Text.Contains("/") && !textBox_preview.Text.Contains("("))
            {
                btn_equal_Click(sender, e);
            }

            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text = textBox_input.Text + " / ";
                textBox_input.Text = "";
            }
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            textBox_input.Text += 0xC;

        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "7";

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "8";

        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "9";

        }

        private void btn_multiplication_Click(object sender, EventArgs e)
        {
            // *가 있으면 연산
            if (textBox_preview.Text.Contains("*") && !textBox_preview.Text.Contains("("))
            {
                btn_equal_Click(sender, e);
            }
            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text += textBox_input.Text + " * ";
                textBox_input.Text = "";
            }
        }

        private void btn_D_Click(object sender, EventArgs e)
        {

            textBox_input.Text += 0xD;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {

            textBox_input.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {

            textBox_input.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {

            textBox_input.Text += "6";
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            // -가 있으면 연산
            if (textBox_preview.Text.Contains("-") && !textBox_preview.Text.Contains("("))
            {
                btn_equal_Click(sender, e);
            }

            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text += textBox_input.Text + " - ";
                textBox_input.Text = "";
            }
        }

        private void btn_E_Click(object sender, EventArgs e)
        {

            textBox_input.Text += 0xE;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {

            textBox_input.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {

            textBox_input.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "3";

        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            // +가 있으면 연산
            if (textBox_preview.Text.Contains("+") && !textBox_preview.Text.Contains("("))
            {
                btn_equal_Click(sender, e);
            }
            if (textBox_input.Text.Length > 0)
            {
                textBox_preview.Text += textBox_input.Text + " + ";
                textBox_input.Text = "";
            }
        }

        private void btn_F_Click(object sender, EventArgs e)
        {

            textBox_input.Text += 0xF;

        }

        private void btn_conversion_Click(object sender, EventArgs e)
        {

            textBox_input.Text = textBox_input.Text.StartsWith("-") ? textBox_input.Text.Substring(1) : "-" + textBox_input.Text;
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox_input.Text += "0";

        }

        private void btn_decimalPoint_Click(object sender, EventArgs e)
        {
            if (!textBox_input.Text.Contains("."))
            {
                textBox_input.Text += ".";
            }

        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            string code = textBox_preview.Text;
            decimal result = 0;

            try
            {
                if (code.Contains("("))
                {
                    result = pc.Calculate(code + textBox_input.Text);

                    // 결과 표시
                    textBox_input.Text = result.ToString();
                    pc.AddToHistory(code + " = " + result.ToString());
                    textBox_preview.Text = ""; // 연산 완료 후 preview 초기화
                    return;
                }



                // 연산자와 숫자 분리
                if (code.Contains("+"))
                {
                    var parts = code.Split('+');
                    if (parts.Length == 2)
                    {
                        result = pc.Add(UserInput(parts[0]), UserInput(textBox_input.Text));
                        
                    }
                }
                else if (code.Contains("-"))
                {
                    var parts = code.Split('-');
                    if (parts.Length == 2)
                    {
                        result = pc.Sub(UserInput(parts[0]), UserInput(textBox_input.Text));
                    }
                }
                else if (code.Contains("*"))
                {
                    var parts = code.Split('*');
                    if (parts.Length == 2)
                    {
                        result = pc.Mul(UserInput(parts[0]), UserInput(textBox_input.Text));
                    }
                }
                else if (code.Contains("/"))
                {
                    var parts = code.Split('/');
                    if (parts.Length == 2)
                    {
                        result = pc.Div(UserInput(parts[0]), UserInput(textBox_input.Text));
                    }
                }
                else if (code.Contains("^"))
                {
                    var parts = code.Split('^');
                    if (parts.Length == 2)
                    {
                        result = pc.Pow(UserInput(parts[0]), UserInput(textBox_input.Text));
                    }
                }
                else if (code.Contains("<<"))
                {
                    var parts = code.Split(new[] { "<<" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        result = pc.Left(long.Parse(parts[0]), int.Parse(textBox_input.Text));
                    }
                }
                else if (code.Contains(">>"))
                {
                    var parts = code.Split(new[] { ">>" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        result = pc.Right(long.Parse(parts[0]), int.Parse(textBox_input.Text));
                    }
                }
                else if (code.Contains("%"))
                {
                    var parts = code.Split('%');
                    if (parts.Length == 2)
                    {
                        result = pc.Percent(UserInput(parts[0]));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            // 결과 표시
            textBox_input.Text = result.ToString();
            pc.AddToHistory(code + " = " + result.ToString());
            textBox_preview.Text = ""; // 연산 완료 후 preview 초기화

        }





        //테마 ---------------------
        public void ChangeTheme(AppTheme theme)
        {
            if (theme == AppTheme.Light)
            {

                // 테마를 적용하는 함수 호출
                LightTheme();


            }
            else if (theme == AppTheme.Dark)
            {

                // 테마를 적용하는 메서드 호출
                DarkTheme();
            }

            void LightTheme() { 
                
            }
            void DarkTheme() { 
                this.BackColor = Color.FromArgb(26, 34, 39);
                textBox_input.BackColor = Color.FromArgb(26, 34, 39);
                textBox_preview.BackColor = Color.FromArgb(26, 34, 39);
                textBox_HEX.BackColor = Color.FromArgb(26, 34, 39);
                textBox_DEC.BackColor = Color.FromArgb(26, 34, 39);
                textBox_BIN.BackColor = Color.FromArgb(26, 34, 39);
                textBox_OCT.BackColor = Color.FromArgb(26, 34, 39);
                btn_0.BackColor = Color.FromArgb(81, 78, 78);
                btn_1.BackColor = Color.FromArgb(81, 78, 78);
                btn_2.BackColor = Color.FromArgb(81, 78, 78);
                btn_3.BackColor = Color.FromArgb(81, 78, 78);
                btn_4.BackColor = Color.FromArgb(81, 78, 78);
                btn_5.BackColor = Color.FromArgb(81, 78, 78);
                btn_6.BackColor = Color.FromArgb(81, 78, 78);
                btn_7.BackColor = Color.FromArgb(81, 78, 78);
                btn_8.BackColor = Color.FromArgb(81, 78, 78);
                btn_9.BackColor = Color.FromArgb(81, 78, 78);
                btn_decimalPoint.BackColor = Color.FromArgb(81, 78, 78);
                btn_conversion.BackColor = Color.FromArgb(81, 78, 78);

                btn_leftShift.BackColor = Color.FromArgb(56, 48, 49);
                btn_rightShift.BackColor = Color.FromArgb(56, 48, 49);
                btn_clearAll.BackColor = Color.FromArgb(56, 48, 49);
                btn_back.BackColor = Color.FromArgb(56, 48, 49);
                btn_parenthesesEnd.BackColor = Color.FromArgb(56, 48, 49);
                btn_openParentheses.BackColor = Color.FromArgb(56, 48, 49);
                btn_percent.BackColor = Color.FromArgb(56, 48, 49);
                btn_sharing.BackColor = Color.FromArgb(56, 48, 49);
                btn_multiplication.BackColor = Color.FromArgb(56, 48, 49);
                btn_minus.BackColor = Color.FromArgb(56, 48, 49);
                btn_plus.BackColor = Color.FromArgb(56, 48, 49);

                btn_A.BackColor = Color.FromArgb(56, 48, 49);
                btn_B.BackColor = Color.FromArgb(56, 48, 49);
                btn_C.BackColor = Color.FromArgb(56, 48, 49);
                btn_D.BackColor = Color.FromArgb(56, 48, 49);
                btn_E.BackColor = Color.FromArgb(56, 48, 49);
                btn_F.BackColor = Color.FromArgb(56, 48, 49);
                panel_hr.BackColor = Color.FromArgb(26, 34, 39);

                textBox_BIN.ForeColor = Color.White;
                textBox_DEC.ForeColor = Color.White;
                textBox_HEX.ForeColor = Color.White;
                textBox_OCT.ForeColor = Color.White;
                textBox_input.ForeColor = Color.White;
                textBox_preview.ForeColor = Color.White;
                btn_BEX.ForeColor = Color.White;
                btn_BIN.ForeColor = Color.White;
                btn_DEC.ForeColor = Color.White;
                btn_OCT.ForeColor = Color.White;

                btn_0.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_1.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_2.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_3.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_4.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_5.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_6.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_7.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_8.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_9.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_conversion.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_decimalPoint.FlatAppearance.MouseOverBackColor = Color.Brown;

                btn_A.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_B.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_C.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_D.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_E.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_F.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_back.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_clearAll.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_leftShift.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_rightShift.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_percent.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_parenthesesEnd.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_sharing.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_multiplication.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_minus.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_plus.FlatAppearance.MouseOverBackColor = Color.Brown;
                btn_openParentheses.FlatAppearance.MouseOverBackColor = Color.Brown;


                btn_0.BackColor = Color.FromArgb(81, 78, 78);
                btn_1.BackColor = Color.FromArgb(81, 78, 78);
                btn_2.BackColor = Color.FromArgb(81, 78, 78);
                btn_3.BackColor = Color.FromArgb(81, 78, 78);
                btn_4.BackColor = Color.FromArgb(81, 78, 78);
                btn_5.BackColor = Color.FromArgb(81, 78, 78);
                btn_6.BackColor = Color.FromArgb(81, 78, 78);
                btn_7.BackColor = Color.FromArgb(81, 78, 78);
                btn_8.BackColor = Color.FromArgb(81, 78, 78);
                btn_9.BackColor = Color.FromArgb(81, 78, 78);
                btn_decimalPoint.BackColor = Color.FromArgb(81, 78, 78);
                btn_conversion.BackColor = Color.FromArgb(81, 78, 78);

                btn_leftShift.ForeColor = Color.White;
                btn_rightShift.ForeColor = Color.White;
                btn_clearAll.ForeColor = Color.White;
                btn_back.ForeColor = Color.White;
                btn_parenthesesEnd.ForeColor = Color.White;
                btn_openParentheses.ForeColor = Color.White;
                btn_percent.ForeColor = Color.White;
                btn_sharing.ForeColor = Color.White;
                btn_multiplication.ForeColor = Color.White;
                btn_minus.ForeColor = Color.White;
                btn_plus.ForeColor = Color.White;

                btn_A.ForeColor = Color.White;
                btn_B.ForeColor = Color.White;
                btn_C.ForeColor = Color.White;
                btn_D.ForeColor = Color.White;
                btn_E.ForeColor = Color.White;
                btn_F.ForeColor = Color.White;

                btn_0.ForeColor = Color.White;
                btn_1.ForeColor = Color.White;
                btn_2.ForeColor = Color.White;
                btn_3.ForeColor = Color.White;
                btn_4.ForeColor = Color.White;
                btn_5.ForeColor = Color.White;
                btn_6.ForeColor = Color.White;
                btn_7.ForeColor = Color.White;
                btn_8.ForeColor = Color.White;
                btn_9.ForeColor = Color.White;
                btn_conversion.ForeColor = Color.White;
                btn_decimalPoint.ForeColor = Color.White;


            }
        }





    }
}
