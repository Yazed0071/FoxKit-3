﻿using System;

namespace CityHash
{
    public struct UInt128
    {
        public UInt128(UInt64 low, UInt64 high)
        {
            Low = low;
            High = high;
        }

        public UInt64 Low { get; set; }
        public UInt64 High { get; set; }

        public bool Equals(UInt128 other)
        {
            return Low == other.Low && High == other.High;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != GetType()) return false;
            return Equals((UInt128) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Low.GetHashCode()*397) ^ High.GetHashCode();
            }
        }
    }
}