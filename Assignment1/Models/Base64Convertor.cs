﻿using System;
using System.IO;
using System.Text;

namespace Assignment1.Models
{
    public class Base64Convertor
    {
        public  string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }

        public  string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }
    }
}
