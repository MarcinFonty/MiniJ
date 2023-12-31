﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser.Helpers
{
    internal static class StringBuilderExtensions
    {
        public static StringBuilder AppendIndented(this StringBuilder sb, string textBlock, string indent = "")
        {
            foreach (var line in textBlock.TrimEnd().Split('\n'))
                if (!string.IsNullOrWhiteSpace(line))
                    sb.AppendLine(indent + $"\t{line}");
            return sb;
        }
    }
}
