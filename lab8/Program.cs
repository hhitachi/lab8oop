using System;
class Calculator{
    private double result;
    private void SetResult(double value){
        result = value;
    }
    public double GetResult(){
        return result;
    }
    public void Add(double a, double b){
        SetResult(a + b);
    }
    public void Subtract(double a, double b){
        SetResult(a - b);
    }
    public void Multiply(double a, double b){
        SetResult(a * b);
    }
    public void Divide(double a, double b){
        if (b == 0){
            Console.Write("Не можна ділити на 0");
            SetResult(0);
        }
        SetResult(a / b);
    }
    public void Power(double a, double b){
        SetResult(Math.Pow(a, b));
    }
    public void Modulus(double a, double b){
        SetResult(a % b);
    }
}
class UserInterface{
    public double GetOperand(string abc){
        Console.Write("Введіть {0} число: ", abc);
        return Convert.ToDouble(Console.ReadLine());
    }
    public int GetChoice(){
        Console.Write("\nВведіть номер операції для взаємодії між числами: ");
        Console.Write("\n1. Додавання\n2. Віднімання\n3. Множення\n4. Ділення\n5. Підносити до степеня\n6. Остача\n");
        Console.Write("Ваш вибір: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice < 0 || choice > 6){
            Console.Clear();
            Console.Write("Неправильний вибір!\n");
            GetChoice();
        }
        return choice;
    }
    public static void ShowResult(double result){
        Console.WriteLine("\nРезультат: " + result);
    }
    public void PerformOperation(Calculator calculator){
        double operand1 = GetOperand("перший");
        double operand2 = GetOperand("другий");
        int choice = GetChoice();
        switch (choice){
            case 1:
                calculator.Add(operand1, operand2);
                break;
            case 2:
                calculator.Subtract(operand1, operand2);
                break;
            case 3:
                calculator.Multiply(operand1, operand2);
                break;
            case 4:
                calculator.Divide(operand1, operand2);
                break;
            case 5:
                calculator.Modulus(operand1, operand2);
                break;
            case 6:
                calculator.Power(operand1, operand2);
                break;
        }
        ShowResult(calculator.GetResult());
    }
}
class Program{
    static void Main(){
        Calculator calculator = new Calculator();
        UserInterface userInterface = new UserInterface();
        userInterface.PerformOperation(calculator);
        
        Console.ReadKey();
    }
}