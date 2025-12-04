using PiškvorkyConsole;
using System.Drawing;
using System.Drawing.Text;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        private GameBoard board = new GameBoard();
        private Button[,] buttons = new Button[3, 3];

        public Form1()
        {
            InitializeComponent();

            // Pøidání události Click pro herní tlaèítka
            foreach (Control c in this.Controls)
            {
                if (c is Button btn && btn.Name.StartsWith("B"))
                {
                    btn.Click += ButtonClick;
                }
            }
            // Pøidání události Click pro tlaèítko Restart
            btnRestart.Click += btnRestart_Click;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton == null)
            {
                MessageBox.Show("Nepodaøilo se získat tlaèítko.");
                return;
            }

            // Kontrola formátu jména tlaèítka
            if (clickedButton.Name.Length != 3 || !char.IsDigit(clickedButton.Name[1]) || !char.IsDigit(clickedButton.Name[2]))
            {
                MessageBox.Show("Nesprávný formát jména tlaèítka.");
                return;
            }

            try
            {
                int row = int.Parse(clickedButton.Name[1].ToString());
                int col = int.Parse(clickedButton.Name[2].ToString());

                if (board.MakeMove(row, col)) // Hráè provede tah
                {
                    clickedButton.Text = board.CurrentPlayer == 'X' ? "O" : "X";
                    clickedButton.Enabled = false;
                    this.ActiveControl = null;

                    if (board.CheckWin(board.CurrentPlayer == 'X' ? 'O' : 'X'))
                    {
                        MessageBox.Show("Vyhrál hráè " + (board.CurrentPlayer == 'X' ? 'O' : 'X'));
                        ResetGame();
                        return;
                    }
                    else if (board.IsBoardFull())
                    {
                        MessageBox.Show("Remíza");
                        ResetGame();
                        return;
                    }

                    // AI provede tah, pokud je zapnutý režim RBEasy
                    if (RBEasy.Checked)
                    {
                        Random rnd = new Random();
                        int aiRow, aiCol;
                        do
                        {
                            aiRow = rnd.Next(0, 3);
                            aiCol = rnd.Next(0, 3);
                        } while (!board.MakeMove(aiRow, aiCol));

                        string buttonName = $"B{aiRow}{aiCol}";
                        Button aiButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                        if (aiButton != null)
                        {
                            aiButton.Text = "O";
                            aiButton.Enabled = false;
                            this.ActiveControl = null;
                        }

                        if (board.CheckWin('O'))
                        {
                            MessageBox.Show("Vyhrálo AI");
                            ResetGame();
                            return;
                        }
                        else if (board.IsBoardFull())
                        {
                            MessageBox.Show("Remíza");
                            ResetGame();
                            return;
                        }
                    }

                    // AI provede tah, pokud je zapnutý režim RBHard
                    if (RBHard.Checked)
                    {
                        (int AiRow, int AiCol) = board.GetBestMove();
                        if (AiRow != -1 && AiCol != -1)
                        {
                            if (board.MakeMove(AiRow, AiCol))
                            {
                                string buttonName = $"B{AiRow}{AiCol}";
                                Button aiButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                                if (aiButton != null)
                                {
                                    aiButton.Text = "O";
                                    aiButton.Enabled = false;
                                    this.ActiveControl = null;
                                }

                                if (board.CheckWin('O'))
                                {
                                    MessageBox.Show("Vyhrálo AI");
                                    ResetGame();
                                    return;
                                }
                                else if (board.IsBoardFull())
                                {
                                    MessageBox.Show("Remíza");
                                    ResetGame();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Nesprávný formát jména tlaèítka.");
            }
        }

        private void ResetGame()
        {
            board.ResetBoard();
            board.historie.Clear();
            foreach (Control c in this.Controls)
            {
                if (c is Button btn && btn.Name.StartsWith("B") && btn.Name.Length == 3 && char.IsDigit(btn.Name[1]) && char.IsDigit(btn.Name[2]))
                {
                    btn.Text = "";
                    btn.Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializaèní kód pøi naètení formuláøe
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
            RBEasy.Checked = false;
            RBHard.Checked = false;
        }

        private void B00_Click(object sender, EventArgs e)
        {
            ButtonClick(sender, e);
        }

        private void RBEasy_CheckedChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnZpet_Click(object sender, EventArgs e)
        {
            if (board.historie.Count == 0)
            {
                ResetGame();
                return;
            }

            if (RBEasy.Checked || RBHard.Checked)
            {
                if (board.historie.Count >= 2) // Potøebujeme alespoò dva tahy (hráè a AI)
                {
                    // Vrátit tah AI
                    var aiMove = board.historie.Pop();
                    int aiRow = aiMove.Item1;
                    int aiCol = aiMove.Item2;
                    string aiButtonName = $"B{aiRow}{aiCol}";
                    Button aiZpetButton = this.Controls.Find(aiButtonName, true).FirstOrDefault() as Button;

                    if (aiZpetButton != null && board.UndoMove(aiRow, aiCol))
                    {
                        aiZpetButton.Text = " ";
                        aiZpetButton.Enabled = true;
                        board.CurrentPlayer = aiMove.Item3; // Aktualizujte CurrentPlayer na hráèe, který provedl vrácený tah
                    }

                    // Vrátit tah hráèe
                    var lastMove = board.historie.Pop();
                    int row = lastMove.Item1;
                    int col = lastMove.Item2;
                    string buttonName = $"B{row}{col}";
                    Button zpetButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                    if (zpetButton != null && board.UndoMove(row, col))
                    {
                        zpetButton.Text = " ";
                        zpetButton.Enabled = true;
                        board.CurrentPlayer = lastMove.Item3; // Aktualizujte CurrentPlayer na hráèe, který provedl vrácený tah
                    }
                }
                else
                {
                    ResetGame();
                }
            }
            else
            {
                // Vrátit tah hráèe (režim bez AI)
                var lastMove = board.historie.Pop();
                int row = lastMove.Item1;
                int col = lastMove.Item2;
                string buttonName = $"B{row}{col}";
                Button zpetButton = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                if (zpetButton != null && board.UndoMove(row, col))
                {
                    zpetButton.Text = " ";
                    zpetButton.Enabled = true;
                    board.CurrentPlayer = lastMove.Item3; // Aktualizujte CurrentPlayer na hráèe, který provedl vrácený tah
                }
            }
        }

        private void RBHard_CheckedChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void RBEasy_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void RBHard_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
