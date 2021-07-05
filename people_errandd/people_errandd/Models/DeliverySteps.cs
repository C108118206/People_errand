﻿using System;
using System.Collections.Generic;

using System.Text;
using Xamarin.Forms;

namespace people_errandd.Models
{
    public class DeliverySteps
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string dateMon { get; set; }
        public string tim { get; set; }
        public Color colorFrame { get; set; }
        public Color colorTask { get; set; }

        public Color textcolorName { get; set; }
        public Color textcolorLocation { get; set; }
        public Color colorLine { get; set; }
    }
}