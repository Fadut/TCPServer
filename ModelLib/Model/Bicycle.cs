using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Bicycle
    {

        private string _id;
        private string _color;
        private double _price;
        private int _gear;

        public Bicycle(){}

        public Bicycle(string id, string color, double price, int gear)
        {
            _id = id;
            _color = color;
            _price = price;
            _gear = gear;
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                if (value.Length < 2) throw new ArgumentException();
                _color = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentException();
                _price = value;
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value <= 3 || value >= 32) throw new ArgumentOutOfRangeException();
                _gear = value;
            }
        }

        public override string ToString()
        {
            return $"Bicycle {nameof(Id)}: {Id}, {nameof(Color)}: {Color}, {nameof(Price)}: {Price}, {nameof(Gear)}: {Gear}";
        }
    }
}
