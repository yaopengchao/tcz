﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginFrame
{
    class ComboxItem
    {
        public string Text = "";

        public string Value = "";
        public ComboxItem(string _Text, string _Value)
        {
            Text = _Text;
            Value = _Value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
