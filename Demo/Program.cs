
using System.Text.RegularExpressions;

/// <summary>
/// 计算器类
/// </summary>
class Calculator
{
    public static double DoPerration(double num1, double num2, string op)
    {
        double reslut = double.NaN;


        switch (op)
        {
            case "a":
                reslut = num1 + num2;
                break;
            case "s":
                reslut = num1 - num2;
                break;
            case "m":
                reslut = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                {
                    reslut = num1 / num2;
                }
                break;
        }
        return reslut;
    }
}

/// <summary>
/// 入口类
/// </summary>
class Program
{
    static void Main(string[] args)
    {
       bool endApp = false;
        Console.WriteLine("测试C#计算机应用\r");
        Console.WriteLine("=====================\n");

        while(!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double reslut = 0;

            Console.Write("请用户输入第一个数字:");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while(!double.TryParse(numInput1,out cleanNum1))
            {
                Console.Write("这不是有效的输入，请输入数值！");
                numInput1 = Console.ReadLine();
            }

            Console.WriteLine("请用户输入第二个数字");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("这不是有效的输入，请输入数值！");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("请选择你的运算符：");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - SubTract");
            Console.WriteLine("\tm - Multply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("输入的值有误，请输入数值");

            }
            else
            {
                try
                {
                    reslut = Calculator.DoPerration(cleanNum1, cleanNum2, op);
                    if(double.IsNaN(reslut))
                    {
                        Console.Write("此操作将导致数学错误！\n");
                    }
                    else
                    {
                        Console.WriteLine("你的结果为：{0:0.##}\n", reslut);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("哦不，尝试进行运算时发送异常\n - 详细信息:"+ ex.Message);
                }
            }
            Console.WriteLine("======================\n");

            Console.WriteLine("如果按下N键，则退出应用程序");
            if (Console.ReadLine() == "n") endApp = true;
            Console.WriteLine("\n");
        }
        return;
    }
}