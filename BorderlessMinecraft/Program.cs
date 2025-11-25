//Copyright (C) 2019 Riley Nielsen

//This file is part of Borderless Minecraft.

//   Borderless Minecraft is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    Borderless Minecraft is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with Borderless Minecraft.  If not, see<https://www.gnu.org/licenses/>.


using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Management;

namespace BorderlessMinecraft
{
    static class Program
    {
        private const string TrayArgument = "--tray";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool runAsTray = args != null && args.Any(a => string.Equals(a, TrayArgument, StringComparison.OrdinalIgnoreCase));

            if (runAsTray)
            {
                // In tray mode we run an ApplicationContext instead of a Form.
                Application.Run(new TrayApplicationContext());
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}