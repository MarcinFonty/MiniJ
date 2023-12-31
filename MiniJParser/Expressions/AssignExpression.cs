﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Expressions
{
    internal class AssignExpression : IExpression
    {
        private string _name {  get; }
        private IExpression _right { get; }
        public AssignExpression(string name, IExpression right)
        {
            _name = name;
            _right = right;
        }
        public void Print(StringBuilder sb, string indent = "")
        {
            sb.AppendLine("AssignExpression");
            sb.Append(indent).Append("- name " + _name);
            sb.AppendLine();

            sb.Append(indent).Append("- value ");
            _right.Print(sb, indent + "\t");
        }
    }
}
