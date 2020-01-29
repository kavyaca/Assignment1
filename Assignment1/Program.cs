using System;
using System.Linq;
using System.Text;
using Assignment1.Models;

namespace Assignment1
{
    class MainClass
    {

       
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");




           

            do
            {
                

                if (name.Length > 0)
                {

                    MyMenu(name);


                }

                else
                {
                    Console.WriteLine("Please enter your name first:");
                  

                    // Create a string variable and get user input from the keyboard and store it in the variable
                    name = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    if (name.Length > 0)
                    {

                        MyMenu(name);


                    }

                }



            } while (name.Length < 1);


           
            
            
            
        }



        private static bool MyMenu(String name)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Convert name to binary");
            Console.WriteLine("2) Convert binary version of name to ASCII ");
            Console.WriteLine("3) Convert name to Hexadecimal ");
            Console.WriteLine("4) Convert hexadecimal version of name to ASCII ");
            Console.WriteLine("5) Convert name to base64 ");
            Console.WriteLine("6) Convert base64 version of name to ASCII ");
            Console.WriteLine("7) Encrypt your name with depth of 20");
            Console.WriteLine("8) Decrypt your name with depth of 20");
            Console.WriteLine("9) Check All Convertions and Encrypt/Decrypt Your name");
            Console.WriteLine("10) Exit");

            Console.WriteLine("");
            Console.WriteLine("");

            switch (Console.ReadLine())
            {
                case "1":
                    StringToBinary(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);
                    return true;
                case "2":

                    BinaryToASCII(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);

                    return true;

                case "3":
                    StringToHex(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);
                    return true;
                case "4":

                    HexToASCII(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);

                    return true;

                case "5":
                    StringToBase64(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);
                    return true;
                case "6":

                    Base64ToASCII(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);

                    return true;

                case "7":
                    Encrypt(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);
                    return true;
                case "8":

                    Decrypt(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);

                    return true;

                case "9":

                    AllInONeConvertor(name);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    MyMenu(name);

                    return true;
                case "10":
                    return false;

                default:
                    MyMenu(name);
                    return true;
            }
        }



        private static string StringToBinary(String name)
        {
            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Binary: {binaryValue}");
        

            return binaryValue;
        }

        private static string BinaryToASCII(String name)
        {
            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
           
            Console.WriteLine($"{name} from Binary to ASCII: {binaryConverter.ConvertBinaryToString(binaryValue)}");
            String converted = binaryConverter.ConvertBinaryToString(binaryValue);



            return converted;
        }



        private static string StringToHex(String name)
        {

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Hexadecimal: {hexadecimalValue}");
           

            return hexadecimalValue;
        }

        private static string HexToASCII(String name)
        {

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
          
            Console.WriteLine($"{name} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            String converted = hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue);



            return converted;
        }


        private static string StringToBase64(String name)
        {
            Base64Convertor base64Converter = new Base64Convertor();
            string base64Value = base64Converter.StringToBase64(name);
            Console.WriteLine($"{name} as Base64: {base64Value}");

            return base64Value;
        }

        private static string Base64ToASCII(String name)
        {
            Base64Convertor base64Converter = new Base64Convertor();
            string base64Value = base64Converter.StringToBase64(name);

            Console.WriteLine($"{name} from base64 to ASCII: {base64Converter.Base64ToString(base64Value)}");

            String converted = base64Converter.Base64ToString(base64Value);



            return converted;
        }

        private static string Encrypt(String name)
        {

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(name, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(name, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");


            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(name, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

          

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {name} {encrypter.Base64}");


            String converted = nameDeepEncryptWithCipher;
            return nameDeepEncryptWithCipher;


        }

        private static string Decrypt(String name)
        {

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(name, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(name, cipher);
          

            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(name, cipher, encryptionDepth);
          

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            

            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");

            return nameDeepDecryptWithCipher;
        }



        private static void AllInONeConvertor(String name)
        {

            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Binary: {binaryValue}");
            Console.WriteLine($"{name} from Binary to ASCII: {binaryConverter.ConvertBinaryToString(binaryValue)}");

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Hexadecimal: {hexadecimalValue}");
            Console.WriteLine($"{name} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            Base64Convertor base64Converter = new Base64Convertor();
            string base64Value = base64Converter.StringToBase64(name);
            Console.WriteLine($"{name} as Base64: {base64Value}");
            Console.WriteLine($"{name} from base64 to ASCII: {base64Converter.Base64ToString(base64Value)}");

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            Encrypter encrypter = new Encrypter(name, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(name, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(name, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {name} {encrypter.Base64}");

            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");

        }
    }
}
