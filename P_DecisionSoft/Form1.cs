using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_DecisionSoft
{
    public partial class Form1 : Form
    {
        public Dictionary<string, cardsuit> dict = new Dictionary<string, cardsuit>();
        public List<Card> cards = new List<Card>();
        public List<Card> Hand = new List<Card>();
        public Form1()
        {
            InitializeComponent();
            dict.Add("H", cardsuit.Heart);
            dict.Add("C", cardsuit.Club);
            dict.Add("S", cardsuit.Spade);
            dict.Add("D", cardsuit.Diamond);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private List<Card> GetFlop()
        {
            List<Card> myCardList = new List<Card>();
            try
            {
                string suit1 = card1.Text.Last().ToString().ToUpper();
                int value1 = Convert.ToInt16(card1.Text.Remove(2));
                string suit2 = card2.Text.Last().ToString().ToUpper();
                int value2 = Convert.ToInt16(card2.Text.Remove(2));
                string suit3 = card3.Text.Last().ToString().ToUpper();
                int value3 = Convert.ToInt16(card3.Text.Remove(2));
                Card karta1 = new Card(value1, dict[suit1]);
                Card karta2 = new Card(value2, dict[suit2]);
                Card karta3 = new Card(value3, dict[suit3]);
                myCardList.Add(karta1);
                myCardList.Add(karta2);
                myCardList.Add(karta3);
                return myCardList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Niepoprawny format danych w FLOP!!");
                return null;
            }


            //richTextBox1.Text = suit + " " + value;
        }
        private Card GetTurn()
        {
            try
            {
                string suit4 = card4.Text.Last().ToString().ToUpper();
                int value4 = Convert.ToInt16(card4.Text.Remove(2));
                Card karta1 = new Card(value4, dict[suit4]);
                return karta1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Niepoprawny format danych w TURN!!");
                return null;
            }
        }
        private Card GetRiver()
        {
            try
            {
                string suit5 = card5.Text.Last().ToString().ToUpper();
                int value5 = Convert.ToInt16(card5.Text.Remove(2));
                Card karta1 = new Card(value5, dict[suit5]);
                return karta1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Niepoprawny format danych w RIVER!!");
                return null;
            }

        }
        private List<Card> GetHand()
        {
            List<Card> myCardList = new List<Card>();
            try
            {
                string suitH1 = cardH1.Text.Last().ToString().ToUpper();
                int valueH1 = Convert.ToInt16(cardH1.Text.Remove(2));
                string suitH2 = cardH2.Text.Last().ToString().ToUpper();
                int valueH2 = Convert.ToInt16(cardH2.Text.Remove(2));
                Card karta1 = new Card(valueH1, dict[suitH1]);
                Card karta2 = new Card(valueH2, dict[suitH2]);
                myCardList.Add(karta1);
                myCardList.Add(karta2);
            }
            catch (Exception e)
            {
                MessageBox.Show("Niepoprawny format danych w HAND!!");
                return null;
            }
            return myCardList;
        }
        private void CheckRadioButtons()
        {

            if (radioButton1.Checked) // Evaluate only hand
            {
                Hand = GetHand();
            }
            else if (radioButton2.Checked)
            {
                Hand = GetHand();
                cards = GetFlop();
            }
            else if (radioButton3.Checked)
            {
                Hand = GetHand();
                cards = GetFlop();
                cards.Add(GetTurn());
            }
            else if (radioButton4.Checked)
            {
                Hand = GetHand();
                cards = GetFlop();
                cards.Add(GetTurn());
                cards.Add(GetRiver());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckRadioButtons();
            if (radioButton1.Checked)
            {
                Game newGame = new Game(Hand);
                newGame.Players[0].HandEval();
                richTextBox1.Text = Convert.ToString(newGame.Players[0].Score);
            }
            else if (radioButton2.Checked)
            {
                Game newGame = new Game(cards, Hand);
                newGame.HandFlopEval(3);
                richTextBox1.Text = Convert.ToString(newGame.Players[0].ScoreAfterFlop);
            }
            else if(radioButton3.Checked)
            {
                Game newGame = new Game(cards, Hand);
                newGame.HandFlopEval(4);
                richTextBox1.Text = Convert.ToString(newGame.Players[0].ScoreAfterFlop);
            }else if (radioButton4.Checked)
            {
                Game newGame = new Game(cards, Hand);
                newGame.HandFlopEval(5);
                richTextBox1.Text = Convert.ToString(newGame.Players[0].ScoreAfterFlop);

            }

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            

        }

        private void card1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
