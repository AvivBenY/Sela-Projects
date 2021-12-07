using System;

namespace עבודת_הגשה_3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exc1(args);
            //Exc2(args);
            //Exc3(args);
            //Exc4(args);
        }
        static void Exc4(string[] args)  //לקלוט 3 מספרים שלמים ולהדפיס את הערך האמצעי
        {
            int num1, num2, num3;

            Console.WriteLine("please insert your first number:  "); //פלט למשתמש לבחירת המספר הראשון
            string text = Console.ReadLine(); // הגדרת הקלט כטקסט
            num1 = int.Parse(text); // שינוי הקלט למספר ספרתי והגדרת המשתנה הראשון

            Console.WriteLine("please insert your second number:  "); //פלט למשתמש לבחירת המספר השני
            text = Console.ReadLine();  // הגדרת הקלט כטקסט
            num2 = int.Parse(text); //שינוי הקלט למספר ספרתי והגדרת המשתנה השני

            Console.WriteLine("please insert your third number:  ");  //פלט למשתמש לבחירת המספר השלישי
            text = Console.ReadLine();  //הגדרת הקלט כטקסט
            num3 = int.Parse(text);  //שינוי הקלט למספר ספרתי והגדרת המשתנה השלישי

            int tmp = 0, max = num1, mid = num2, min = num3; //הגדרת משתנים חדשים כולל משתמש שיעזור בהחלפה
            //החלפה בין כל האופציות כך שמשתנה המקסימום מינימום והאמצע והיו בסדר התואם את הערך שלהם                           
            if (max < mid)  //swap                                    
            {
                tmp = max;
                max = mid;
                mid = tmp;
            }

            if(max < min)   // swap
            {
                tmp = max;
                max = min;
                min = tmp;
            }
            if(mid < min)   //swap
            {
                tmp = mid;
                mid = min;
                min = tmp;
            }

            Console.WriteLine($"you chose 3 numbers, {num1}, {num2}, {num3}. the middle number is {mid}"); //פלט למשתמש המציג את המספרים ובנוסף מציג את המספר בעל ערך האמצע
            
        }

        static void Exc3(string[] args)
            //לקלוט 2 מספרים תלת-ספרתיים (כולל בדיקות נדרשות), ולבדוק האם סכום הספרות של מספר הראשון גדול \ קטן \שווה לסכום הספרות של מספר השני
        {
            int num1, num2;

            Console.WriteLine("please insert your first 3 digit number:  "); //פלט למשתמש לבחירת המספר הראשון
            string text = Console.ReadLine(); // הגדרת הקלט כטקסט
            num1 = int.Parse(text); // שינוי הקלט למספר ספרתי והגדרת המשתנה הראשון

            if (num1 > 999 || num1 < 100) //בדיקת על ידי שלילת המספרים הגדולים מ999 וקטנים מ99 כדי לוודא שהמספר הוא תלת ספרתי
            {
                Console.WriteLine("please check your number it doesnt have 3 digits"); //פלט המבקש מהמשתמש להזין מחדש
                return; //סגירת התוכנה על מנת שהמסתמש יזין מחדש בלי שיהיה כשל מערכת
            }

            Console.WriteLine("please insert your second 3 digit number:  "); //פלט למשתמש לבחירת המספר השני
            text = Console.ReadLine();  // הגדרת הקלט כטקסט
            num2 = int.Parse(text); //שינוי הקלט למספר ספרתי והגדרת המשתנה השני

            if (num2 > 999 || num2 < 100) //בדיקת על ידי שלילת המספרים הגדולים מ999 וקטנים מ99 כדי לוודא שהמספר הוא תלת ספרתי
            {
                Console.WriteLine("please check your number it doesnt have 3 digits"); //פלט המבקש מהמשתמש להזין מחדש
                return; //סגירת התוכנה על מנת שהמסתמש יזין מחדש בלי שיהיה כשל מערכת
            }
            
            //מספר ראשון
            int hnd1 = num1 / 100; //בדיקת ספרת מאות
            int ten1 = (num1 / 10) - (hnd1 * 10); 
            int one1 = num1 % 10; // בדיקת אחדות

            //מספר שני
            int hnd2 = num2 / 100; //בדיקת ספרת מאות
            int ten2 = (num2 / 10) - (hnd2 * 10); //בדיקת עשרות
            int one2 = num2 % 10; // בדיקת אחדות

            int sum1 = hnd1 + ten1 + one1; //הגדרת משתנה לחיבור כל הספרות שמהם מורכב מספר1
            int sum2 = hnd2 + ten2 + one2; //הגדרת משתנה לחיבור כל הספרות שמהם מורכב מספר2

            if (sum1 > sum2) Console.WriteLine($"the sum of the digits in your first number is {sum1} and its bigger then the other {sum2}"); // פלט למשתמש המשווה בין המשתנים ומראה האם גדול קטן שווה
            if (sum1 < sum2) Console.WriteLine($"the sum of the digits in your first number is {sum1} and its smaller then the other {sum2}");
            if (sum1 == sum2) Console.WriteLine($"the sum of the digits in your first number is {sum1} and its equal to the other {sum2}");
        }

        static void Exc2(string[] args)  
            //	לקלוט 4 מספרים למצוא ולספור כמה מתוכם זוגיים
        {
            int num1, num2, num3, num4; //הגדרת המשתנים כמספרים שלמים

            Console.WriteLine("please insert your first number:  "); //פלט למשתמש לבחירת המספר הראשון
            string text = Console.ReadLine(); // הגדרת הקלט כטקסט
            num1 = int.Parse(text); // שינוי הקלט למספר ספרתי והגדרת המשתנה הראשון

            Console.WriteLine("please insert your second number:  "); //פלט למשתמש לבחירת המספר השני
            text = Console.ReadLine();  // הגדרת הקלט כטקסט
            num2 = int.Parse(text); //שינוי הקלט למספר ספרתי והגדרת המשתנה השני

            Console.WriteLine("please insert your third number:  ");  //פלט למשתמש לבחירת המספר השלישי
            text = Console.ReadLine();  //הגדרת הקלט כטקסט
            num3 = int.Parse(text);  //שינוי הקלט למספר ספרתי והגדרת המשתנה השלישי

            Console.WriteLine("please insert your fourth number:  ");  //פלט למשתמש לבחירת המספר הרביעי
            text = Console.ReadLine(); // הגדרת הקלט כטקסט
            num4 = int.Parse(text); //שינוי הקלט למספר ספרתי והגדרת המשתנה הרביעי

            int evencnt = 0; // הגדרת משתנה ספירת מספרים זוגיים ואיפוס

            if (num1 % 2 == 0) evencnt += 1; // חישוב שארית 0 של הספרות שנבחרו (כך נבדוק אם המספר זוגי או שלילי) והעלאת הערך של המשתנה החדש בהתאם
            if (num2 % 2 == 0) evencnt += 1;
            if (num3 % 2 == 0) evencnt += 1;
            if (num4 % 2 == 0) evencnt += 1;

            Console.WriteLine($"you Chose 4 numbers, {evencnt} are even");    // פלט למשתמש המציין כמה מספרים זוגיים נבחרו בהצגת המשתנה החדש (evencnt)
        }

        static void Exc1(string[] args)
            //1.	לקלוט 2 מספרים , לחשב ולהציג:
            //a.תוצאות חלוקה שלמה של הערך הגדול בקטן יחד עם השארית
            //b.תוצאות חלוקה העשרונית של הערך הקטן בגדול

        {
            int num1, num2; //הגדרת המשתנים כמספרים שלמים

            Console.WriteLine("please insert your first number:  "); //בקשת מספר ראשון מהמשתמש
            string value = Console.ReadLine();  //קליטת המספר שהמשתמש רשם כטקסט
            num1 = int.Parse(value);  //המרת הטקסט לספרה

            Console.WriteLine("please insert your second number:  ");//בקשת מספר שני מהמשתמש
            value = Console.ReadLine();  //קליטת המספר שהמשתמש רשם כטקסט
            num2 = int.Parse(value); //המרת הטקסט לספרה

            int max = Math.Max(num1, num2); //מציאת המספר הגדול מן השניים
            int min = Math.Min(num1, num2);  //מציאת המספר הקטן מהשניים

            Console.WriteLine($"if we devide the {max} with the {min} we will have this number: {max / min} and have {max % min} left"); // First HomeWork Task חלוקת המספר הגדול בקטן וחישוב השארית
            Console.WriteLine($"if we divide the smaller number: {min} by the bigger number: {max} we will get this decimal number {(float)min / max}"); // Second HomeWork Task חלוקת המספר הקטן בגדול וקבלת מספר עשרוני
        }
    }
}    

