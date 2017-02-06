﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace P_DecisionSoft
{
    public enum cardsuit { Heart, Diamond, Spade, Club };
    public class Card
    {
        public cardsuit Suit { get; set; }

        public int Val { get; set; }

        public Card(int val, cardsuit suit)
        {
            Suit = suit;
            Val = val;
        }
        public string ShowCard()
        {
            WriteLine(Suit + " " + Val);
            return Suit + ":" + Val;
        }

    }
}
